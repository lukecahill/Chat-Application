namespace Chat {
	partial class chatForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.remoteIp = new System.Windows.Forms.TextBox();
			this.localPort = new System.Windows.Forms.TextBox();
			this.messageList = new System.Windows.Forms.ListBox();
			this.disconnect = new System.Windows.Forms.Button();
			this.sendMessage = new System.Windows.Forms.Button();
			this.Message = new System.Windows.Forms.TextBox();
			this.connect = new System.Windows.Forms.Button();
			this.status = new System.Windows.Forms.Label();
			this.startServer = new System.Windows.Forms.Button();
			this.localGroup = new System.Windows.Forms.GroupBox();
			this.remoteConnectGroup = new System.Windows.Forms.GroupBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopListeningButton = new System.Windows.Forms.Button();
			this.localGroup.SuspendLayout();
			this.remoteConnectGroup.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// remoteIp
			// 
			this.remoteIp.Location = new System.Drawing.Point(26, 25);
			this.remoteIp.Name = "remoteIp";
			this.remoteIp.Size = new System.Drawing.Size(100, 20);
			this.remoteIp.TabIndex = 0;
			this.remoteIp.Text = "127.0.0.1:10024";
			this.remoteIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.remoteIp_KeyPress);
			// 
			// localPort
			// 
			this.localPort.Location = new System.Drawing.Point(30, 25);
			this.localPort.Name = "localPort";
			this.localPort.Size = new System.Drawing.Size(100, 20);
			this.localPort.TabIndex = 1;
			this.localPort.Text = "1024";
			this.localPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.localPort_KeyPress);
			// 
			// messageList
			// 
			this.messageList.FormattingEnabled = true;
			this.messageList.Location = new System.Drawing.Point(9, 203);
			this.messageList.Name = "messageList";
			this.messageList.Size = new System.Drawing.Size(354, 160);
			this.messageList.TabIndex = 15;
			// 
			// disconnect
			// 
			this.disconnect.Enabled = false;
			this.disconnect.Location = new System.Drawing.Point(239, 369);
			this.disconnect.Name = "disconnect";
			this.disconnect.Size = new System.Drawing.Size(124, 23);
			this.disconnect.TabIndex = 14;
			this.disconnect.Text = "Disconnect from client";
			this.disconnect.UseVisualStyleBackColor = true;
			this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
			// 
			// sendMessage
			// 
			this.sendMessage.Enabled = false;
			this.sendMessage.Location = new System.Drawing.Point(288, 140);
			this.sendMessage.Name = "sendMessage";
			this.sendMessage.Size = new System.Drawing.Size(75, 43);
			this.sendMessage.TabIndex = 13;
			this.sendMessage.Text = "Send";
			this.sendMessage.UseVisualStyleBackColor = true;
			this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
			// 
			// Message
			// 
			this.Message.Location = new System.Drawing.Point(9, 142);
			this.Message.Multiline = true;
			this.Message.Name = "Message";
			this.Message.Size = new System.Drawing.Size(274, 41);
			this.Message.TabIndex = 12;
			this.Message.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Message_KeyUp);
			// 
			// connect
			// 
			this.connect.Location = new System.Drawing.Point(26, 51);
			this.connect.Name = "connect";
			this.connect.Size = new System.Drawing.Size(100, 23);
			this.connect.TabIndex = 6;
			this.connect.Text = "Connect";
			this.connect.UseVisualStyleBackColor = true;
			this.connect.Click += new System.EventHandler(this.connect_Click);
			// 
			// status
			// 
			this.status.AutoSize = true;
			this.status.Location = new System.Drawing.Point(9, 126);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(35, 13);
			this.status.TabIndex = 16;
			this.status.Text = "label1";
			this.status.Visible = false;
			// 
			// startServer
			// 
			this.startServer.Location = new System.Drawing.Point(6, 51);
			this.startServer.Name = "startServer";
			this.startServer.Size = new System.Drawing.Size(68, 23);
			this.startServer.TabIndex = 8;
			this.startServer.Text = "Listen";
			this.startServer.UseVisualStyleBackColor = true;
			this.startServer.Click += new System.EventHandler(this.startServer_Click);
			// 
			// localGroup
			// 
			this.localGroup.Controls.Add(this.stopListeningButton);
			this.localGroup.Controls.Add(this.startServer);
			this.localGroup.Controls.Add(this.localPort);
			this.localGroup.Location = new System.Drawing.Point(209, 27);
			this.localGroup.Name = "localGroup";
			this.localGroup.Size = new System.Drawing.Size(154, 87);
			this.localGroup.TabIndex = 18;
			this.localGroup.TabStop = false;
			this.localGroup.Text = "Bind to port";
			// 
			// remoteConnectGroup
			// 
			this.remoteConnectGroup.Controls.Add(this.connect);
			this.remoteConnectGroup.Controls.Add(this.remoteIp);
			this.remoteConnectGroup.Location = new System.Drawing.Point(12, 27);
			this.remoteConnectGroup.Name = "remoteConnectGroup";
			this.remoteConnectGroup.Size = new System.Drawing.Size(154, 87);
			this.remoteConnectGroup.TabIndex = 17;
			this.remoteConnectGroup.TabStop = false;
			this.remoteConnectGroup.Text = "Connect to";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(373, 24);
			this.menuStrip1.TabIndex = 19;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// stopListeningButton
			// 
			this.stopListeningButton.Location = new System.Drawing.Point(80, 51);
			this.stopListeningButton.Name = "stopListeningButton";
			this.stopListeningButton.Size = new System.Drawing.Size(68, 23);
			this.stopListeningButton.TabIndex = 9;
			this.stopListeningButton.Text = "Stop";
			this.stopListeningButton.UseVisualStyleBackColor = true;
			this.stopListeningButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// chatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 401);
			this.Controls.Add(this.messageList);
			this.Controls.Add(this.disconnect);
			this.Controls.Add(this.sendMessage);
			this.Controls.Add(this.Message);
			this.Controls.Add(this.status);
			this.Controls.Add(this.localGroup);
			this.Controls.Add(this.remoteConnectGroup);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "chatForm";
			this.Text = "Chat";
			this.localGroup.ResumeLayout(false);
			this.localGroup.PerformLayout();
			this.remoteConnectGroup.ResumeLayout(false);
			this.remoteConnectGroup.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox remoteIp;
		private System.Windows.Forms.TextBox localPort;
		private System.Windows.Forms.ListBox messageList;
		private System.Windows.Forms.Button disconnect;
		private System.Windows.Forms.Button sendMessage;
		private System.Windows.Forms.TextBox Message;
		private System.Windows.Forms.Button connect;
		private System.Windows.Forms.Label status;
		private System.Windows.Forms.Button startServer;
		private System.Windows.Forms.GroupBox localGroup;
		private System.Windows.Forms.GroupBox remoteConnectGroup;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.Button stopListeningButton;
	}
}

