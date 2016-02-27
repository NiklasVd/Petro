using Caseomatic.Net;
using Petro.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Net
{
    public class CryptoClient
    {
        private readonly Participant myself;
        private readonly Client<CryptoClientPacket, CryptoServerPacket> client;

        private CommunicationID communicationId, serverCommunicationId;

        private bool isConnected;
        public bool IsConnected
        {
            get { return isConnected; }
        }

        public CryptoClient(Participant myself, int port)
        {
            this.myself = myself;

            client = new Client<CryptoClientPacket, CryptoServerPacket>(port);
            client.CommunicationModule = new CryptoCommunicationModule();
            
            client.OnReceivePacket += OnReceivePacket;
            client.OnConnectionLost += OnConnectionLost;
        }

        public void Connect(IPEndPoint endPoint)
        {
            communicationId = CommunicationID.Generate(myself);
            var answerHandshakePacket = SendCryptoRequest<HandshakeCryptoClientPacket, AnswerHandshakeCryptoServerPacket>
                (new HandshakeCryptoClientPacket(myself, communicationId));

            ProcessAnswerHandshakePacket(answerHandshakePacket);
        }

        public void Disconnect()
        {
            SendCryptoPacket(new DisconnectCryptoClientPacket());
            DisconnectClient();
        }

        public void SendRequest() // TODO: Implement request
        {
            var answerRequestPacket = SendCryptoRequest<RequestCryptoClientPacket, AnswerRequestCryptoServerPacket>
                (new RequestCryptoClientPacket());
        }

        private void SendCryptoPacket(CryptoClientPacket packet)
        {
            packet.Sign(communicationId);
            client.SendPacket(packet);
        }
        private TServerAnswer SendCryptoRequest<TClientRequest, TServerAnswer>(TClientRequest packet)
            where TClientRequest : CryptoClientPacket, IPacketRequestable where TServerAnswer : CryptoServerPacket
        {
            packet.Sign(communicationId);
            return client.SendRequest<TClientRequest, TServerAnswer>(packet);
        }

        private void DisconnectClient()
        {
            client.Disconnect();
            isConnected = false;
        }

        private void ProcessAnswerHandshakePacket(AnswerHandshakeCryptoServerPacket packet)
        {
            switch (packet.Status)
            {
                case AnswerHandshakeCryptoServerPacket.HandshakeStatus.Success:
                    isConnected = true;
                    break;

                case AnswerHandshakeCryptoServerPacket.HandshakeStatus.Failure:
                    DisconnectClient();
                    break;
            }
        }

        private void ProcessAbortPacket(AbortCryptoServerPacket packet)
        {
            DisconnectClient();
        }

        private void OnReceivePacket(CryptoServerPacket packet)
        {
        }

        private void OnConnectionLost()
        {

        }
    }
}
