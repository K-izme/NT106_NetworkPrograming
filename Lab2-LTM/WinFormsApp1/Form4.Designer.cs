namespace WinFormsApp1
{
    partial class Form4
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
            button3 = new Button();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(72, 427);
            button3.Name = "button3";
            button3.Size = new Size(86, 23);
            button3.TabIndex = 14;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(177, 37);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(320, 413);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(13, 303);
            button2.Name = "button2";
            button2.Size = new Size(145, 62);
            button2.TabIndex = 7;
            button2.Text = "Ghi file";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(13, 73);
            button1.Name = "button1";
            button1.Size = new Size(145, 62);
            button1.TabIndex = 8;
            button1.Text = "Đọc FIle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 486);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form4";
            Text = "Bài 3";
            Load += Form4_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private RichTextBox richTextBox1;
        private Button button2;
        private Button button1;
    }
}