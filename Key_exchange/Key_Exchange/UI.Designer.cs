namespace Key_Exchange
{
    partial class UI
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
            serverAdd = new TextBox();
            serverPort = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            pubPrime = new TextBox();
            pubBig = new TextBox();
            serverPrivate = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            clientAdd = new TextBox();
            clientPort = new TextBox();
            clientPrivate = new TextBox();
            gen_1 = new Button();
            gen_2 = new Button();
            gen_3 = new Button();
            helpProvider1 = new HelpProvider();
            serverOp = new Button();
            gen_priKey_client = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Server Part";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 243);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 1;
            label2.Text = "Client Part";
            // 
            // serverAdd
            // 
            serverAdd.Location = new Point(182, 38);
            serverAdd.Name = "serverAdd";
            serverAdd.Size = new Size(423, 23);
            serverAdd.TabIndex = 2;
            // 
            // serverPort
            // 
            serverPort.Location = new Point(182, 78);
            serverPort.Name = "serverPort";
            serverPort.Size = new Size(423, 23);
            serverPort.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 45);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 4;
            label3.Text = "IP Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 81);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 5;
            label4.Text = "Port";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 120);
            label5.Name = "label5";
            label5.Size = new Size(121, 15);
            label5.TabIndex = 6;
            label5.Text = "Public Prime Number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 157);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 7;
            label6.Text = "Public Big Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 192);
            label7.Name = "label7";
            label7.Size = new Size(65, 15);
            label7.TabIndex = 8;
            label7.Text = "Private Key";
            // 
            // pubPrime
            // 
            pubPrime.Location = new Point(181, 112);
            pubPrime.Name = "pubPrime";
            pubPrime.ReadOnly = true;
            pubPrime.Size = new Size(424, 23);
            pubPrime.TabIndex = 9;
            pubPrime.TextChanged += pubPrime_TextChanged;
            // 
            // pubBig
            // 
            pubBig.Location = new Point(181, 149);
            pubBig.Name = "pubBig";
            pubBig.ReadOnly = true;
            pubBig.Size = new Size(424, 23);
            pubBig.TabIndex = 10;
            pubBig.TextChanged += pubBig_TextChanged;
            // 
            // serverPrivate
            // 
            serverPrivate.Location = new Point(181, 184);
            serverPrivate.Name = "serverPrivate";
            serverPrivate.ReadOnly = true;
            serverPrivate.Size = new Size(424, 23);
            serverPrivate.TabIndex = 11;
            serverPrivate.TextChanged += serverPrivate_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 293);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 12;
            label8.Text = "IP Address";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(28, 327);
            label9.Name = "label9";
            label9.Size = new Size(29, 15);
            label9.TabIndex = 13;
            label9.Text = "Port";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(28, 362);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 14;
            label10.Text = "Private Key";
            // 
            // clientAdd
            // 
            clientAdd.Location = new Point(182, 290);
            clientAdd.Name = "clientAdd";
            clientAdd.Size = new Size(423, 23);
            clientAdd.TabIndex = 15;
            // 
            // clientPort
            // 
            clientPort.Location = new Point(181, 327);
            clientPort.Name = "clientPort";
            clientPort.Size = new Size(424, 23);
            clientPort.TabIndex = 16;
            // 
            // clientPrivate
            // 
            clientPrivate.Location = new Point(181, 362);
            clientPrivate.Name = "clientPrivate";
            clientPrivate.ReadOnly = true;
            clientPrivate.Size = new Size(424, 23);
            clientPrivate.TabIndex = 17;
            clientPrivate.TextChanged += clientPrivate_TextChanged;
            // 
            // gen_1
            // 
            gen_1.Location = new Point(637, 114);
            gen_1.Name = "gen_1";
            gen_1.Size = new Size(75, 23);
            gen_1.TabIndex = 18;
            gen_1.Text = "Generate";
            gen_1.UseVisualStyleBackColor = true;
            gen_1.Click += gen_1_Click;
            // 
            // gen_2
            // 
            gen_2.Location = new Point(637, 149);
            gen_2.Name = "gen_2";
            gen_2.Size = new Size(75, 23);
            gen_2.TabIndex = 19;
            gen_2.Text = "Generate";
            gen_2.UseVisualStyleBackColor = true;
            gen_2.Click += gen_2_Click;
            // 
            // gen_3
            // 
            gen_3.Location = new Point(637, 183);
            gen_3.Name = "gen_3";
            gen_3.Size = new Size(75, 23);
            gen_3.TabIndex = 20;
            gen_3.Text = "Generate";
            gen_3.UseVisualStyleBackColor = true;
            gen_3.Click += gen_3_Click;
            // 
            // serverOp
            // 
            serverOp.Location = new Point(341, 213);
            serverOp.Name = "serverOp";
            serverOp.Size = new Size(112, 23);
            serverOp.TabIndex = 22;
            serverOp.Text = "Open Server";
            serverOp.UseVisualStyleBackColor = true;
            serverOp.Click += serverOp_Click;
            // 
            // gen_priKey_client
            // 
            gen_priKey_client.Location = new Point(637, 362);
            gen_priKey_client.Name = "gen_priKey_client";
            gen_priKey_client.Size = new Size(75, 23);
            gen_priKey_client.TabIndex = 23;
            gen_priKey_client.Text = "Generate";
            gen_priKey_client.UseVisualStyleBackColor = true;
            gen_priKey_client.Click += gen_priKey_client_Click;
            // 
            // UI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gen_priKey_client);
            Controls.Add(serverOp);
            Controls.Add(gen_3);
            Controls.Add(gen_2);
            Controls.Add(gen_1);
            Controls.Add(clientPrivate);
            Controls.Add(clientPort);
            Controls.Add(clientAdd);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(serverPrivate);
            Controls.Add(pubBig);
            Controls.Add(pubPrime);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(serverPort);
            Controls.Add(serverAdd);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UI";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox serverAdd;
        private TextBox serverPort;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox pubPrime;
        private TextBox pubBig;
        private TextBox serverPrivate;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox clientAdd;
        private TextBox clientPort;
        private TextBox clientPrivate;
        private Button gen_1;
        private Button gen_2;
        private Button gen_3;
        private HelpProvider helpProvider1;
        private Button serverOp;
        private Button gen_priKey_client;
    }
}