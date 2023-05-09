namespace Lab03_LTM
{
    partial class ex2
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
            startListen = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // startListen
            // 
            startListen.Location = new Point(696, 21);
            startListen.Name = "startListen";
            startListen.Size = new Size(75, 23);
            startListen.TabIndex = 0;
            startListen.Text = "LISTEN";
            startListen.UseVisualStyleBackColor = true;
            startListen.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(20, 83);
            listView1.Name = "listView1";
            listView1.Size = new Size(751, 251);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // ex2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(startListen);
            Name = "ex2";
            Text = "ex2";
            ResumeLayout(false);
        }

        #endregion

        private Button startListen;
        private ListView listView1;
    }
}