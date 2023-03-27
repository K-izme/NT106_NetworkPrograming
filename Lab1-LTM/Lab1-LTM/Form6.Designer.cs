namespace Lab1
{
    partial class Form6
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
            textBox1 = new TextBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            listView1 = new ListView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button2 = new Button();
            button3 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 57);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Danh sách điểm";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(248, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(283, 83);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Xuất";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new Point(12, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 139);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách môn học và điểm";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // listView1
            // 
            listView1.BackColor = SystemColors.Window;
            listView1.Location = new Point(19, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(312, 102);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 254);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 0;
            label2.Text = "Điểm trung bình: ";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 291);
            label3.Name = "label3";
            label3.Size = new Size(133, 15);
            label3.TabIndex = 4;
            label3.Text = "Môn có điểm cao nhất: ";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 323);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 5;
            label4.Text = "Số môn đậu: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(205, 254);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 6;
            label5.Text = "Xếp loại học lực: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(205, 291);
            label6.Name = "label6";
            label6.Size = new Size(138, 15);
            label6.TabIndex = 7;
            label6.Text = "Môn có điểm thấp nhất: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(205, 323);
            label7.Name = "label7";
            label7.Size = new Size(114, 15);
            label7.TabIndex = 8;
            label7.Text = "Số môn không đậu: ";
            // 
            // button2
            // 
            button2.Location = new Point(202, 83);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Xoá";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(121, 83);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "Thoát";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 347);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form6";
            Text = "Phần mềm quản lý điểm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListView listView1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button2;
        private Button button3;
    }
}