namespace WinFormsApp1
{
    partial class Form5
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
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(206, 422);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 18;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(308, 307);
            button2.Name = "button2";
            button2.Size = new Size(134, 62);
            button2.TabIndex = 15;
            button2.Text = "Đọc file";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(56, 307);
            button1.Name = "button1";
            button1.Size = new Size(134, 62);
            button1.TabIndex = 16;
            button1.Text = "Ghi File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 43);
            label1.Name = "label1";
            label1.Size = new Size(206, 15);
            label1.TabIndex = 19;
            label1.Text = "Input (Các giá trị cách nhau bằng \",\" )";
            label1.Click += label1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(27, 78);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(450, 212);
            richTextBox1.TabIndex = 20;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 486);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form5";
            Text = "Bài 4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private Label label1;
        private RichTextBox richTextBox1;
    }
}