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

        public bool ActiveConnectionRepair
        {
            get { return client.ActiveConnectionRepair; }
            //set { client.ActiveConnectionRepair = value; }
        }

        public CryptoClient(Participant myself, int port)
        {
            this.myself = myself;

            client = new Client<CryptoClientPacket, CryptoServerPacket>(port);
            client.CommunicationModule = new CryptoCommunicationModule<CryptoServerPacket, CryptoClientPacket>();
            
            client.OnReceivePacket += OnReceivePacket;
            client.OnConnectionLost += OnConnectionLost;
        }

        public void Connect(IPEndPoint endPoint)
        {
            if (!isConnected)
            {
                communicationId = CommunicationID.Generate(myself);
                SendCryptoPacket(new HandshakeCryptoClientPacket(myself, communicationId));
            }
        }

        public void Disconnect()
        {
            if (isConnected)
            {
                SendCryptoPacket(new DisconnectCryptoClientPacket());
                DisconnectClient();
            }
        }

        private void SendCryptoPacket(CryptoClientPacket packet)
        {
            if (isConnected)
            {
                packet.Sign(communicationId);
                client.SendPacket(packet);
            }
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
                    serverCommunicationId = packet.SenderCommunicationID;
                    break;

                case AnswerHandshakeCryptoServerPacket.HandshakeStatus.Failure:
                    DisconnectClient();
                    break;
            }
        }

        private void ProcessAbortPacket(AbortConnectionCryptoServerPacket packet)
        {
            DisconnectClient();
        }

        private void OnReceivePacket(CryptoServerPacket packet)
        {
            switch (packet.Type)
            {
                case CryptoServerPacketType.AnswerHandshake:
                    ProcessAnswerHandshakePacket((AnswerHandshakeCryptoServerPacket)packet);
                    break;

                case CryptoServerPacketType.AbortConnection:
                    DisconnectClient();
                    break;
                case CryptoServerPacketType.AnswerRequest:
                    break;
            }
        }

        private void OnConnectionLost()
        {

        }
    }
}
