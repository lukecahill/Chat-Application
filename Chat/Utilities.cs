using System.Diagnostics;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Chat {
	public class Utilities {
		/// <summary>
		/// Return the split IP and port from the string
		/// </summary>
		/// <param name="text">String containing the IP and port in the format 127.0.0.1:1024</param>
		/// <returns>String array containing IP and port</returns>
		public string[] ReturnParsedIpPort(string text) {
			var connectTo = text.Split(':');
			return connectTo;
		}

		/// <summary>
		/// Closes the socket connection if we are connected.
		/// </summary>
		/// <param name="client">The socket we want to close</param>
		public void CloseClient(Socket client) {
			if (client.Connected) {
				client.Close();
			}
		}

		/// <summary>
		/// Set the buttons on the form to be enabled or not depening on bool.
		/// </summary>
		/// <param name="enabled">Boolean of are we connected </param>
		/// <param name="connect">Button for connect button</param>
		/// <param name="disconnect">Button for disconnect button</param>
		/// <param name="sendMessage">Button to send message</param>
		public void SetButton(bool enabled, Button connect, Button disconnect, Button sendMessage) {
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

		/// <summary>
		/// Starts a new instance of the program. Therefore allowing multiple chat programs to be open at once.
		/// </summary>
		public void StartNew() {
			var info = new ProcessStartInfo(Application.ExecutablePath);
			Process.Start(info);
		}

		/// <summary>
		/// Create a new socket with "AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp"
		/// </summary>
		/// <returns>Socket create with the parameters "AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp"</returns>
		public Socket SocketStream() {
			return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}

	}
}
