using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
			SetButtons(true, connect, disconnect, sendMessage);
			try {

				if(!remoteIp.Text.Contains(":")) {
					MessageBox.Show("Please enter an IP using the following format:\n\n192.168.0.1:1024");
					return;
				}

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

				client = CreateSocketStream();
				var remoteEndPoint = new IPEndPoint(IPAddress.Parse(remote), port);
				client.BeginConnect(remoteEndPoint, new AsyncCallback(OnConnected), null);

			} catch (SocketException) {
				CloseConnection();
			}
		}

		private void startServer_Click(object sender, EventArgs e) {
			server = CreateSocketStream();
			var port = int.Parse(localPort.Text);

			var localEndPoint = new IPEndPoint(0, port);
			server.Bind(localEndPoint);
			server.Listen(10);

			server.BeginAccept(new AsyncCallback(OnClientConnected), null);
			startServer.Enabled = false;
			status.Visible = true;
			status.Text = $"Listenting for connections on port {port}";
		}

		private void sendMessage_Click(object sender, EventArgs e) {
			// Send the message here
			var message = Encoding.ASCII.GetBytes(Message.Text);
			client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnDataSent), null);

		}

		private void disconnect_Click(object sender, EventArgs e) {
			CloseConnection();
			SetButtons(true, connect, disconnect, sendMessage);
			status.Text = "Disconnected";
		}

		private void remoteIp_KeyPress(object sender, KeyPressEventArgs e) {
			if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9.:\b]")) {
				e.Handled = true;
			}
		}

		private void localPort_KeyPress(object sender, KeyPressEventArgs e) {
			if(Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9\b]")) {
				e.Handled = true;
			}
		}

		private void CloseConnection() {
			if (client.Connected) {
				client.Close();
			}
		}

		private void OnClientConnected(IAsyncResult result) {
			client = server.EndAccept(result);
			status.Text = $"Connected to: {remoteIp.Text}";
			client.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
		}

		private void OnDataSent(IAsyncResult result) {
			try {
				// handle the success and display the message.
				var sent = client.EndReceive(result);
				client.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
				messageList.Items.Add(Message.Text);
			} catch (SocketException e) {
				System.Diagnostics.Debug.WriteLine(e);
				status.Text = "There was an error while attempting to send the data.";
				CloseConnection();
			}
		}

		private void OnConnected(IAsyncResult result) {
			try {
				client.EndConnect(result);
				status.Text = $"Connected to: {client.RemoteEndPoint}";
				client.BeginReceive(data, 0, 1024, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
			} catch (SocketException) {
				status.Text = $"Could not connect to {remoteIp.Text}";
			}
		}

		private void OnDataReceived(IAsyncResult result) {
			try {
				// handle the recieved data
				var recieve = client.EndReceive(result);
				var message = Encoding.ASCII.GetString(data, 0, data.Length);
				messageList.Items.Add(message);
			} catch {
				status.Text = $"There was an error while receiving the data.";
			}
		}

		private Socket CreateSocketStream() {
			return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}

		private void SetButtons(bool enabled, Button connect, Button disconnect, Button sendMessage) {
			if (enabled) {
				disconnect.Enabled = true;
				sendMessage.Enabled = true;
				connect.Enabled = false;
			} else {
				connect.Enabled = true;
				sendMessage.Enabled = false;
				disconnect.Enabled = false;
			}
		}
    }
}
