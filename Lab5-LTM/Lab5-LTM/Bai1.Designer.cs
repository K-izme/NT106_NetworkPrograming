namespace Lab5_LTM
{
    partial class Bai1
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            fromBox = new TextBox();
            toBox = new TextBox();
            Password = new Label();
            passBox = new TextBox();
            Subject = new Label();
            label3 = new Label();
            subBox = new TextBox();
            rtbBody = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(702, 30);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "SEND";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 29);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 1;
            label1.Text = "From";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 69);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 2;
            label2.Text = "To";
            // 
            // fromBox
            // 
            fromBox.Location = new Point(118, 21);
            fromBox.Name = "fromBox";
            fromBox.Size = new Size(281, 23);
            fromBox.TabIndex = 3;
            // 
            // toBox
            // 
            toBox.Location = new Point(116, 62);
            toBox.Name = "toBox";
            toBox.Size = new Size(283, 23);
            toBox.TabIndex = 4;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(441, 21);
            Password.Name = "Password";
            Password.Size = new Size(57, 15);
            Password.TabIndex = 5;
            Password.Text = "Password";
            // 
            // passBox
            // 
            passBox.Location = new Point(515, 21);
            passBox.Name = "passBox";
            passBox.Size = new Size(100, 23);
            passBox.TabIndex = 6;
            // 
            // Subject
            // 
            Subject.AutoSize = true;
            Subject.Location = new Point(50, 140);
            Subject.Name = "Subject";
            Subject.Size = new Size(46, 15);
            Subject.TabIndex = 7;
            Subject.Text = "Subject";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 183);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 8;
            label3.Text = "Body";
            // 
            // subBox
            // 
            subBox.Location = new Point(118, 140);
            subBox.Name = "subBox";
            subBox.Size = new Size(100, 23);
            subBox.TabIndex = 9;
            // 
            // rtbBody
            // 
            rtbBody.Location = new Point(113, 190);
            rtbBody.Name = "rtbBody";
            rtbBody.Size = new Size(639, 167);
            rtbBody.TabIndex = 10;
            rtbBody.Text = "";
            // 
            // Bai1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbBody);
            Controls.Add(subBox);
            Controls.Add(label3);
            Controls.Add(Subject);
            Controls.Add(passBox);
            Controls.Add(Password);
            Controls.Add(toBox);
            Controls.Add(fromBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Bai1";
            Text = "Form1";
            Load += Bai1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox fromBox;
        private TextBox toBox;
        private Label Password;
        private TextBox passBox;
        private Label Subject;
        private Label label3;
        private TextBox subBox;
        private RichTextBox rtbBody;
    }
}