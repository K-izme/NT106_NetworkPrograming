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
            button1 = new Button();
            button2 = new Button();
            grpb = new GroupBox();
            rtbHocVien = new RichTextBox();
            button3 = new Button();
            button4 = new Button();
            grpb.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(192, 34);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(135, 48);
            button1.TabIndex = 0;
            button1.Text = "Tính - in ra màn hình";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(356, 34);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(135, 48);
            button2.TabIndex = 1;
            button2.Text = "Lưu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // grpb
            // 
            grpb.Controls.Add(rtbHocVien);
            grpb.Location = new Point(27, 159);
            grpb.Margin = new Padding(2);
            grpb.Name = "grpb";
            grpb.Padding = new Padding(2);
            grpb.Size = new Size(468, 358);
            grpb.TabIndex = 2;
            grpb.TabStop = false;
            grpb.Text = "Danh sách học viên";
            // 
            // rtbHocVien
            // 
            rtbHocVien.AcceptsTab = true;
            rtbHocVien.Location = new Point(0, 20);
            rtbHocVien.Margin = new Padding(2);
            rtbHocVien.Name = "rtbHocVien";
            rtbHocVien.Size = new Size(457, 392);
            rtbHocVien.TabIndex = 0;
            rtbHocVien.Text = "";
            // 
            // button3
            // 
            button3.Location = new Point(23, 34);
            button3.Name = "button3";
            button3.Size = new Size(132, 48);
            button3.TabIndex = 3;
            button3.Text = "Ghi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(192, 103);
            button4.Name = "button4";
            button4.Size = new Size(135, 51);
            button4.TabIndex = 1;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 562);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(grpb);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BÀI 4";
            Load += Form5_Load;
            grpb.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox grpb;
        private System.Windows.Forms.RichTextBox rtbHocVien;
        private Button button3;
        private Button button4;
    }
}