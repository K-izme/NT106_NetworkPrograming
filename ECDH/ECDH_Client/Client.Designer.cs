namespace ECDH_Client
{
    partial class Client
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
            ipBox = new TextBox();
            portBox = new TextBox();
            connectButton = new Button();
            rtbMess = new RichTextBox();
            rtbLog = new RichTextBox();
            messBox = new TextBox();
            sendButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 25);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 53);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // ipBox
            // 
            ipBox.Location = new Point(78, 17);
            ipBox.Name = "ipBox";
            ipBox.Size = new Size(100, 23);
            ipBox.TabIndex = 2;
            // 
            // portBox
            // 
            portBox.Location = new Point(78, 53);
            portBox.Name = "portBox";
            portBox.Size = new Size(100, 23);
            portBox.TabIndex = 3;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(78, 100);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 4;
            connectButton.Text = "CONNECT";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // rtbMess
            // 
            rtbMess.Location = new Point(301, 17);
            rtbMess.Name = "rtbMess";
            rtbMess.Size = new Size(466, 296);
            rtbMess.TabIndex = 5;
            rtbMess.Text = "";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(38, 177);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(177, 136);
            rtbLog.TabIndex = 6;
            rtbLog.Text = "";
            // 
            // messBox
            // 
            messBox.Location = new Point(301, 341);
            messBox.Name = "messBox";
            messBox.Size = new Size(100, 23);
            messBox.TabIndex = 7;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(624, 345);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 8;
            sendButton.Text = "SEND";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sendButton);
            Controls.Add(messBox);
            Controls.Add(rtbLog);
            Controls.Add(rtbMess);
            Controls.Add(connectButton);
            Controls.Add(portBox);
            Controls.Add(ipBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Client";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox ipBox;
        private TextBox portBox;
        private Button connectButton;
        private RichTextBox rtbMess;
        private RichTextBox rtbLog;
        private TextBox messBox;
        private Button sendButton;
    }
}