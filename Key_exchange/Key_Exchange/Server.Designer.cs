namespace Key_Exchange
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chatBoxServer = new TextBox();
            send = new Button();
            messBox = new RichTextBox();
            SuspendLayout();
            // 
            // chatBoxServer
            // 
            chatBoxServer.Location = new Point(25, 386);
            chatBoxServer.Name = "chatBoxServer";
            chatBoxServer.Size = new Size(632, 23);
            chatBoxServer.TabIndex = 0;
            // 
            // send
            // 
            send.Location = new Point(677, 386);
            send.Name = "send";
            send.Size = new Size(75, 23);
            send.TabIndex = 1;
            send.Text = "Send";
            send.UseVisualStyleBackColor = true;
            send.Click += send_Click;
            // 
            // messBox
            // 
            messBox.Location = new Point(25, 22);
            messBox.Name = "messBox";
            messBox.Size = new Size(727, 322);
            messBox.TabIndex = 2;
            messBox.Text = "";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(messBox);
            Controls.Add(send);
            Controls.Add(chatBoxServer);
            Name = "Server";
            Text = "Server";
            FormClosing += Server_FormClosing;
            Load += Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox chatBoxServer;
        private Button send;
        private RichTextBox messBox;
    }
}