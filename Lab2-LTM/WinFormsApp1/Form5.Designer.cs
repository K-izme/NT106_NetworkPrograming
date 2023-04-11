namespace WinForms1App1
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
            title = new Label();
            groupBox1 = new GroupBox();
            tbVan = new TextBox();
            tbToan = new TextBox();
            tbSđt = new TextBox();
            tbHoTen = new TextBox();
            tbMssv = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            btnTinh = new Button();
            btnThoat = new Button();
            btnXoa = new Button();
            btnOpen = new Button();
            btnSave = new Button();
            btnThem = new Button();
            groupBox3 = new GroupBox();
            listView = new ListView();
            MSSV = new ColumnHeader();
            HoTen = new ColumnHeader();
            Sđt = new ColumnHeader();
            toan = new ColumnHeader();
            van = new ColumnHeader();
            rtbFile = new RichTextBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            title.ForeColor = Color.ForestGreen;
            title.Location = new Point(196, 37);
            title.Margin = new Padding(4, 0, 4, 0);
            title.Name = "title";
            title.Size = new Size(463, 25);
            title.TabIndex = 3;
            title.Text = "Bài 04: Đọc và ghi file sử dụng BinaryFormatter";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbVan);
            groupBox1.Controls.Add(tbToan);
            groupBox1.Controls.Add(tbSđt);
            groupBox1.Controls.Add(tbHoTen);
            groupBox1.Controls.Add(tbMssv);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(5, 87);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(929, 158);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nhập thông tin SV";
            // 
            // tbVan
            // 
            tbVan.Location = new Point(640, 76);
            tbVan.Margin = new Padding(4, 3, 4, 3);
            tbVan.Name = "tbVan";
            tbVan.Size = new Size(90, 23);
            tbVan.TabIndex = 9;
            // 
            // tbToan
            // 
            tbToan.Location = new Point(640, 30);
            tbToan.Margin = new Padding(4, 3, 4, 3);
            tbToan.Name = "tbToan";
            tbToan.Size = new Size(90, 23);
            tbToan.TabIndex = 8;
            // 
            // tbSđt
            // 
            tbSđt.Location = new Point(114, 122);
            tbSđt.Margin = new Padding(4, 3, 4, 3);
            tbSđt.Name = "tbSđt";
            tbSđt.Size = new Size(153, 23);
            tbSđt.TabIndex = 7;
            // 
            // tbHoTen
            // 
            tbHoTen.Location = new Point(114, 81);
            tbHoTen.Margin = new Padding(4, 3, 4, 3);
            tbHoTen.Name = "tbHoTen";
            tbHoTen.Size = new Size(258, 23);
            tbHoTen.TabIndex = 6;
            // 
            // tbMssv
            // 
            tbMssv.Location = new Point(114, 38);
            tbMssv.Margin = new Padding(4, 3, 4, 3);
            tbMssv.Name = "tbMssv";
            tbMssv.Size = new Size(153, 23);
            tbMssv.TabIndex = 5;
            tbMssv.TextChanged += tbMssv_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(572, 81);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 4;
            label5.Text = "Điểm Văn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(572, 33);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "Điểm Toán";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 126);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 2;
            label3.Text = "SĐT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 84);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Họ Tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "MSSV";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btnTinh);
            groupBox2.Controls.Add(btnThoat);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnOpen);
            groupBox2.Controls.Add(btnSave);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(5, 253);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(929, 99);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chức năng";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(801, 36);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(13, 15);
            label12.TabIndex = 12;
            label12.Text = "6";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(653, 36);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(13, 15);
            label11.TabIndex = 11;
            label11.Text = "5";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(501, 36);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(13, 15);
            label10.TabIndex = 10;
            label10.Text = "4";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(359, 36);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(13, 15);
            label9.TabIndex = 9;
            label9.Text = "3";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(214, 36);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 8;
            label8.Text = "2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(85, 36);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(13, 15);
            label7.TabIndex = 7;
            label7.Text = "1";
            // 
            // btnTinh
            // 
            btnTinh.Location = new Point(319, 54);
            btnTinh.Margin = new Padding(4, 3, 4, 3);
            btnTinh.Name = "btnTinh";
            btnTinh.Size = new Size(96, 27);
            btnTinh.TabIndex = 6;
            btnTinh.Text = "Tính TB";
            btnTinh.UseVisualStyleBackColor = true;
            btnTinh.Click += btnTinh_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(760, 54);
            btnThoat.Margin = new Padding(4, 3, 4, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(88, 27);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(617, 54);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(88, 27);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(461, 54);
            btnOpen.Margin = new Padding(4, 3, 4, 3);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(96, 27);
            btnOpen.TabIndex = 3;
            btnOpen.Text = "Mở File Ouput";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(181, 54);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 27);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu DS";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(47, 54);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 27);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm SV";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listView);
            groupBox3.Location = new Point(5, 360);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(528, 404);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách sinh viên";
            // 
            // listView
            // 
            listView.Columns.AddRange(new ColumnHeader[] { MSSV, HoTen, Sđt, toan, van });
            listView.Location = new Point(0, 24);
            listView.Margin = new Padding(4, 3, 4, 3);
            listView.Name = "listView";
            listView.Size = new Size(528, 379);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            // 
            // MSSV
            // 
            MSSV.Text = "MSSV";
            // 
            // HoTen
            // 
            HoTen.Text = "Họ Tên";
            HoTen.Width = 180;
            // 
            // Sđt
            // 
            Sđt.Text = "SĐT";
            Sđt.Width = 100;
            // 
            // toan
            // 
            toan.Text = "Điểm Toán";
            toan.Width = 100;
            // 
            // van
            // 
            van.Text = "Điểm Văn";
            van.Width = 100;
            // 
            // rtbFile
            // 
            rtbFile.Location = new Point(540, 384);
            rtbFile.Margin = new Padding(4, 3, 4, 3);
            rtbFile.Name = "rtbFile";
            rtbFile.Size = new Size(334, 379);
            rtbFile.TabIndex = 7;
            rtbFile.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(537, 366);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 8;
            label6.Text = "Đọc file output";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 749);
            Controls.Add(label6);
            Controls.Add(rtbFile);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(title);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form5";
            Text = "Bài 4";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbVan;
        private System.Windows.Forms.TextBox tbToan;
        private System.Windows.Forms.TextBox tbSđt;
        private System.Windows.Forms.TextBox tbHoTen;
        private System.Windows.Forms.TextBox tbMssv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader MSSV;
        private System.Windows.Forms.ColumnHeader HoTen;
        private System.Windows.Forms.ColumnHeader Sđt;
        private System.Windows.Forms.ColumnHeader toan;
        private System.Windows.Forms.ColumnHeader van;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}