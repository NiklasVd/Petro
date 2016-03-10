using Petro;
using Petro.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetroExampleChat
{
    public partial class MainForm : Form
    {
        private const int standardClientPort = 30300;

        private Participant myself;
        private CryptoClient client;

        public MainForm()
        {
            InitializeComponent();

            myself = new Participant("Myself");
            client = new CryptoClient(myself, standardClientPort);
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            var ipEndPointTextSplitted = txtConnectIPEndpoint.Text.Split(':');
            var ip = IPAddress.Parse(ipEndPointTextSplitted[0]);
            var port = int.Parse(ipEndPointTextSplitted[1]);

            client.Connect(new IPEndPoint(ip, port));
        }

        private void cmdHost_Click(object sender, EventArgs e)
        {

        }

        private void cmdSendMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
