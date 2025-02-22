namespace YoutubeMultiManual
{
    partial class InfoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.LinkLabel linkZalo;
        private System.Windows.Forms.PictureBox pictureBox;

        /// <summary>
        /// Giải phóng tài nguyên.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblAuthor = new Label();
            linkZalo = new LinkLabel();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(197, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(172, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tool Youtube Info";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAuthor.Location = new Point(160, 55);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(294, 63);
            lblAuthor.TabIndex = 1;
            lblAuthor.Text = "╰┈➤ Phần mềm tăng lượt xem, tăng like, \r\nbình luận của Youtube được phát triển \r\nbởi Lý Trần.";
            lblAuthor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // linkZalo
            // 
            linkZalo.AutoSize = true;
            linkZalo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkZalo.Location = new Point(160, 119);
            linkZalo.Name = "linkZalo";
            linkZalo.Size = new Size(157, 21);
            linkZalo.TabIndex = 2;
            linkZalo.TabStop = true;
            linkZalo.Text = "Zalo: +84876437046";
            linkZalo.LinkClicked += linkZalo_LinkClicked;
            // 
            // pictureBox
            // 
            pictureBox.ImageLocation = "lytran.jpg";
            pictureBox.Location = new Point(20, 20);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(120, 120);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 160);
            Controls.Add(pictureBox);
            Controls.Add(linkZalo);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "InfoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin phần mềm";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
            this.Icon = new System.Drawing.Icon("lytranYT.ico");
        }

        #endregion

        // Xử lý sự kiện click link Zalo
        private void linkZalo_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://zalo.me/+84876437046",
                UseShellExecute = true
            });
        }
    }
}
