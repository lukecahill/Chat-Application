using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Chat {
	public partial class chatForm : Form {

		private byte[] data = new byte[1024];
		private byte[] receivedData = new byte[1024];
		private Socket client;
		private Socket server;
		private Socket remoteClient;

		public chatForm() {
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
		}

		private void connect_Click(object sender, EventArgs e) {
			try {
				var parsed = remoteIp.Text.Split(':');
				status.Visible = true;
				status.Text = $"Connecting to {remoteIp.Text}";

				var remote = parsed[0];
				var portString = parsed[1];
				int port;
				if (!int.TryParse(portString, out port)) {
					MessageBox.Show("Invalid port was entered.");
					return;
				}

				client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				var remoteEndPoint = new IPEndPoint(IPAddress.Parse(remote), port);
				client.BeginConnect(remoteEndPoint, new AsyncCallback(OnConnected), null);

			} catch (SocketException) {
				CloseConnection();
			}
		}

		private void startServer_Click(object sender, EventArgs e) {

		}

		private void sendMessage_Click(object sender, EventArgs e) {
			// Send the message here
			var message = Encoding.ASCII.GetBytes(Message.Text);
			client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnDataSent), null);

		}

		private void disconnect_Click(object sender, EventArgs e) {
			CloseConnection();
		}

		private void remoteIp_KeyPress(object sender, KeyPressEventArgs e) {

		}

		private void localPort_KeyPress(object sender, KeyPressEventArgs e) {

		}

		private void CloseConnection() {
			if (client.Connected) {
				client.Close();
			}
		}

		private void OnDataSent(IAsyncResult result) {

		}

		private void OnConnected(IAsyncResult result) {

		}
    }
}
