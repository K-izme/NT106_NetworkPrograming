namespace Lab1
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Decimal", "Binary", "Hexadecimal" });
            comboBox1.Location = new Point(100, 118);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(93, 25);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Decimal", "Binary", "Hexadecimal" });
            comboBox2.Location = new Point(303, 118);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(81, 25);
            comboBox2.TabIndex = 1;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 122);
            label1.Name = "label1";
            label1.Size = new Size(29, 17);
            label1.TabIndex = 2;
            label1.Text = "Từ:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(255, 122);
            label2.Name = "label2";
            label2.Size = new Size(42, 17);
            label2.TabIndex = 3;
            label2.Text = "Sang:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 43);
            label3.Name = "label3";
            label3.Size = new Size(92, 17);
            label3.TabIndex = 4;
            label3.Text = "Nhập một số:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 311);
            label4.Name = "label4";
            label4.Size = new Size(55, 17);
            label4.TabIndex = 5;
            label4.Text = "Kết quả";
            label4.Click += label4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(100, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(284, 25);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(112, 308);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(284, 25);
            textBox2.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlText;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(112, 262);
            button1.Name = "button1";
            button1.Size = new Size(208, 26);
            button1.TabIndex = 8;
            button1.Text = "Thực hiện";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(112, 355);
            button2.Name = "button2";
            button2.Size = new Size(86, 26);
            button2.TabIndex = 9;
            button2.Text = "Thoát";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 203);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nhập thông tin";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 393);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "Form5";
            Text = "Bài 4";
            Load += Form5_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
    }
}