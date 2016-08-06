using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Chat {
	public partial class chatForm : Form {

		private Utilities utilities = new Utilities();

		private byte[] data = new byte[1024];
		private byte[] receivedData = new byte[1024];
		private Socket client;
		private Socket server;
		private int wordCount = 0;

		/// <summary>
		/// Initialise the form.
		/// </summary>
		public chatForm() {
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
			stopListeningButton.Enabled = false;
		}

		/// <summary>
		/// Click event which starts the inital connection
		/// </summary>
		/// <param name="sender">Button Object</param>
		/// <param name="e">EventArgs arguments of the event</param>
		private void connect_Click(object sender, EventArgs e) {
			utilities.SetButton(true, connect, disconnect, sendMessage);
			try {

				if(!remoteIp.Text.Contains(":")) {
					MessageBox.Show("Please enter an IP using the following format:\n\n192.168.0.1:1024");
					return;
				}

				var parsed = utilities.ReturnParsedIpPort(remoteIp.Text);
				status.Visible = true;
				status.Text = $"Connecting to {remoteIp.Text}";

				var remote = parsed[0];
				var portString = parsed[1];
				int port;
				if (!int.TryParse(portString, out port)) {
					MessageBox.Show("Invalid port was entered.");
					return;
				}

				client = utilities.SocketStream();
				var remoteEndPoint = new IPEndPoint(IPAddress.Parse(remote), port);
				client.BeginConnect(remoteEndPoint, new AsyncCallback(OnConnected), null);

			} catch (SocketException) {
				CloseConnection();
			}
		}

		/// <summary>
		/// Starts the server to accept the incoming client for messaging.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void startServer_Click(object sender, EventArgs e) {
			server = utilities.SocketStream();
			if(Regex.IsMatch(localPort.Text, @"[^0-9]")) {
				MessageBox.Show("Local port must be numbers only!");
				return;
			}
			var port = int.Parse(localPort.Text);

			var localEndPoint = new IPEndPoint(0, port);
			server.Bind(localEndPoint);
			server.Listen(10);

			server.BeginAccept(new AsyncCallback(OnClientConnected), null);
			startServer.Enabled = false;
			stopListeningButton.Enabled = true;
			status.Visible = true;
			status.Text = $"Listenting for connections on port {port}";
		}

		/// <summary>
		/// Handler for the send message click
		/// </summary>
		/// <param name="sender">Button object</param>
		/// <param name="e">EventArgs of the button</param>
		private void sendMessage_Click(object sender, EventArgs e) {
			// Send the message here
			var message = Encoding.ASCII.GetBytes(Message.Text);
			client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnDataSent), null);

		}

		/// <summary>
		/// Button click handler for the disconnect button
		/// </summary>
		/// <param name="sender">Button Object</param>
		/// <param name="e">EventArgs of the button</param>
		private void disconnect_Click(object sender, EventArgs e) {
			CloseConnection();
			utilities.SetButton(false, connect, disconnect, sendMessage);
			status.Text = "Disconnected";
		}

		/// <summary>
		/// Only allow for numbers, full stop, colon, and backspaces to be entered into the remote IP.
		/// </summary>
		/// <param name="sender">Textarea object</param>
		/// <param name="e">KeyPressEventArgs arguments</param>
		private void remoteIp_KeyPress(object sender, KeyPressEventArgs e) {
			if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9.:\b]")) {
				e.Handled = true;
			}
		}

		/// <summary>
		/// Used to stop anything other than numbers being entered into the local port.
		/// </summary>
		/// <param name="sender">Textbox Object</param>
		/// <param name="e">KeyPressEventArgs of the last key press</param>
		private void localPort_KeyPress(object sender, KeyPressEventArgs e) {
			if(Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9\b]")) {
				e.Handled = true;
			}
		}

		/// <summary>
		/// Displays a message box of how to use the program.
		/// </summary>
		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("To use enter the IP, and port under the connect to header. This should be in the format of IPADDRESS:PORT; e.g. 127.0.0.1:1024.\n\nUnder the bind to port header enter the local port that the remote client should connect to, and the chat will then bind to that port and listen for incoming connections.", "Help");
		}

		/// <summary>
		/// Start a new instance of the chat.
		/// </summary>
		private void newToolStripMenuItem_Click(object sender, EventArgs e) {
			utilities.StartNew();
		}

		/// <summary>
		/// Exit the currect program
		/// </summary>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Environment.Exit(0);
		}

		/// <summary>
		/// Closes the socket.
		/// Resets the form, and displays that it is disconnected.
		/// </summary>
		private void CloseConnection() {
			if (client.Connected) {
				client.Close();
			}

			utilities.SetButton(false, connect, disconnect, sendMessage);
		}

		/// <summary>
		/// What happens after the client connects.
		/// </summary>
		/// <param name="result">IAsyncResult</param>
		private void OnClientConnected(IAsyncResult result) {
			try {
				client = server.EndAccept(result);
				status.Text = $"Connected to: {remoteIp.Text}";
				client.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
			} catch {
				// something here to handle
			}
		}

		/// <summary>
		/// What to do when the message is sent
		/// </summary>
		private void OnDataSent(IAsyncResult result) {
			try {
				// handle the success and display the message.
				var sent = client.EndReceive(result);
				client.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
				messageList.Items.Add(Message.Text);
			} catch (SocketException ex) {
				Debug.WriteLine(ex);
				status.Text = "There was an error while attempting to send the data.";
				CloseConnection();
			}
		}

		/// <summary>
		/// Handle the initial connection, sets the statusm and allows reciving to occur.
		/// </summary>
		/// <param name="result">IAsyncResult</param>
		private void OnConnected(IAsyncResult result) {
			try {
				client.EndConnect(result);
				status.Text = $"Connected to: {client.RemoteEndPoint}";
				client.BeginReceive(data, 0, 1024, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
			} catch (SocketException ex) {
				status.Text = $"Could not connect to {remoteIp.Text}";
				Debug.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Handle when data is recieved.
		/// </summary>
		/// <param name="result">IAsyncResult</param>
		private void OnDataReceived(IAsyncResult result) {
			try {
				// handle the recieved data
				var recieve = client.EndReceive(result);
				var message = Encoding.ASCII.GetString(data, 0, data.Length);
				messageList.Items.Add(message);
			} catch {
				// handle this
			}
		}

		private void Message_KeyUp(object sender, KeyEventArgs e) {
			if (wordCount > 1023) {
				MessageBox.Show("The maximum word count is 1024", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			wordCount++;
		}

		private void button1_Click(object sender, EventArgs e) {
			utilities.SetButton(false, connect, disconnect, sendMessage);
			startServer.Enabled = true;
			localPort.Enabled = true;
			stopListeningButton.Enabled = false;
			server.Dispose();
		}
	}
}
