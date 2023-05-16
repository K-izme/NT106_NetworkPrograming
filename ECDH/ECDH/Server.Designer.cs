namespace ECDH
{
    partial class Server
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            ipBox = new ComboBox();
            portBox = new TextBox();
            rtbMes = new RichTextBox();
            rtbLog = new RichTextBox();
            messBox = new TextBox();
            sendButton = new Button();
            connectButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 26);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 63);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // ipBox
            // 
            ipBox.FormattingEnabled = true;
            ipBox.Location = new Point(106, 25);
            ipBox.Name = "ipBox";
            ipBox.Size = new Size(121, 23);
            ipBox.TabIndex = 2;
            // 
            // portBox
            // 
            portBox.Location = new Point(106, 63);
            portBox.Name = "portBox";
            portBox.Size = new Size(121, 23);
            portBox.TabIndex = 3;
            // 
            // rtbMes
            // 
            rtbMes.Location = new Point(317, 23);
            rtbMes.Name = "rtbMes";
            rtbMes.Size = new Size(446, 314);
            rtbMes.TabIndex = 4;
            rtbMes.Text = "";
            rtbMes.TextChanged += rtbMes_TextChanged;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(28, 193);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(255, 215);
            rtbLog.TabIndex = 5;
            rtbLog.Text = "";
            // 
            // messBox
            // 
            messBox.Location = new Point(317, 377);
            messBox.Name = "messBox";
            messBox.Size = new Size(365, 23);
            messBox.TabIndex = 6;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(688, 376);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 7;
            sendButton.Text = "SEND";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(128, 108);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 8;
            connectButton.Text = "CONNECT";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(connectButton);
            Controls.Add(sendButton);
            Controls.Add(messBox);
            Controls.Add(rtbLog);
            Controls.Add(rtbMes);
            Controls.Add(portBox);
            Controls.Add(ipBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Server";
            Text = "SERVER";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox ipBox;
        private TextBox portBox;
        private RichTextBox rtbMes;
        private RichTextBox rtbLog;
        private TextBox messBox;
        private Button sendButton;
        private Button connectButton;
    }
}