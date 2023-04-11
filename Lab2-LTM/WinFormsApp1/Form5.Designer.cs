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
            groupBox3.SuspendLayout();
            SuspendLayout();
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
            groupBox1.Location = new Point(5, 12);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(583, 158);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nhập thông tin SV";
            // 
            // tbVan
            // 
            tbVan.Location = new Point(480, 46);
            tbVan.Margin = new Padding(4, 3, 4, 3);
            tbVan.Name = "tbVan";
            tbVan.Size = new Size(90, 23);
            tbVan.TabIndex = 9;
            // 
            // tbToan
            // 
            tbToan.Location = new Point(480, 17);
            tbToan.Margin = new Padding(4, 3, 4, 3);
            tbToan.Name = "tbToan";
            tbToan.Size = new Size(90, 23);
            tbToan.TabIndex = 8;
            // 
            // tbSđt
            // 
            tbSđt.Location = new Point(85, 83);
            tbSđt.Margin = new Padding(4, 3, 4, 3);
            tbSđt.Name = "tbSđt";
            tbSđt.Size = new Size(153, 23);
            tbSđt.TabIndex = 7;
            // 
            // tbHoTen
            // 
            tbHoTen.Location = new Point(85, 54);
            tbHoTen.Margin = new Padding(4, 3, 4, 3);
            tbHoTen.Name = "tbHoTen";
            tbHoTen.Size = new Size(258, 23);
            tbHoTen.TabIndex = 6;
            // 
            // tbMssv
            // 
            tbMssv.Location = new Point(85, 25);
            tbMssv.Margin = new Padding(4, 3, 4, 3);
            tbMssv.Name = "tbMssv";
            tbMssv.Size = new Size(153, 23);
            tbMssv.TabIndex = 5;
            tbMssv.TextChanged += tbMssv_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(397, 54);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 4;
            label5.Text = "Điểm Văn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(397, 25);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "Điểm Toán";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 91);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 2;
            label3.Text = "SĐT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 62);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Họ Tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "MSSV";
            // 
            // btnTinh
            // 
            btnTinh.Location = new Point(613, 78);
            btnTinh.Margin = new Padding(4, 3, 4, 3);
            btnTinh.Name = "btnTinh";
            btnTinh.Size = new Size(88, 27);
            btnTinh.TabIndex = 6;
            btnTinh.Text = "Tính TB";
            btnTinh.UseVisualStyleBackColor = true;
            btnTinh.Click += btnTinh_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(765, 42);
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
            btnXoa.Location = new Point(765, 9);
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
            btnOpen.Location = new Point(614, 111);
            btnOpen.Margin = new Padding(4, 3, 4, 3);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(87, 27);
            btnOpen.TabIndex = 3;
            btnOpen.Text = "Mở File Ouput";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(613, 45);
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
            btnThem.Location = new Point(613, 12);
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
            groupBox3.Location = new Point(13, 176);
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
            listView.Location = new Point(13, 22);
            listView.Margin = new Padding(4, 3, 4, 3);
            listView.Name = "listView";
            listView.Size = new Size(520, 294);
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
            rtbFile.Location = new Point(549, 198);
            rtbFile.Margin = new Padding(4, 3, 4, 3);
            rtbFile.Name = "rtbFile";
            rtbFile.Size = new Size(334, 294);
            rtbFile.TabIndex = 7;
            rtbFile.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(549, 176);
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
            ClientSize = new Size(891, 503);
            Controls.Add(btnThoat);
            Controls.Add(btnTinh);
            Controls.Add(btnXoa);
            Controls.Add(label6);
            Controls.Add(btnOpen);
            Controls.Add(rtbFile);
            Controls.Add(groupBox3);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Controls.Add(btnThem);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form5";
            Text = "Bài 4";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
    }
}