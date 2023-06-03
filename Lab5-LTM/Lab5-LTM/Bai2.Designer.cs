namespace Lab5_LTM
{
    partial class Bai2
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
            label1 = new Label();
            label2 = new Label();
            mailBox = new TextBox();
            passBox = new TextBox();
            logBut = new Button();
            label3 = new Label();
            label4 = new Label();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 12);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 44);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // mailBox
            // 
            mailBox.Location = new Point(97, 9);
            mailBox.Name = "mailBox";
            mailBox.Size = new Size(172, 23);
            mailBox.TabIndex = 2;
            // 
            // passBox
            // 
            passBox.Location = new Point(97, 38);
            passBox.Name = "passBox";
            passBox.Size = new Size(172, 23);
            passBox.TabIndex = 3;
            // 
            // logBut
            // 
            logBut.Location = new Point(677, 24);
            logBut.Name = "logBut";
            logBut.Size = new Size(75, 23);
            logBut.TabIndex = 4;
            logBut.Text = "LOGIN";
            logBut.UseVisualStyleBackColor = true;
            logBut.Click += logBut_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 112);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 5;
            label3.Text = "Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(184, 112);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 6;
            label4.Text = "Recent:";
            // 
            // listView1
            // 
            listView1.Location = new Point(36, 156);
            listView1.Name = "listView1";
            listView1.Size = new Size(725, 266);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Bai2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(logBut);
            Controls.Add(passBox);
            Controls.Add(mailBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Bai2";
            Text = "Bai2";
            Load += Bai2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox mailBox;
        private TextBox passBox;
        private Button logBut;
        private Label label3;
        private Label label4;
        private ListView listView1;
    }
}