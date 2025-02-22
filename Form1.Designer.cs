namespace YoutubeMultiManual
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Các control
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnChangeProxy;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddTabs;
        private System.Windows.Forms.Button btnOpenVideo;
        private System.Windows.Forms.Button btnCheckIp;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        // Sử dụng custom control ToggleSwitch thay vì CheckBox
        private ToggleSwitch toggleMute;

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
            topPanel = new Panel();
            btnChangeProxy = new Button();
            btnReset = new Button();
            btnAddTabs = new Button();
            textBoxUrl = new TextBox();
            btnOpenVideo = new Button();
            btnCheckIp = new Button();
            btnInfo = new Button();
            toggleMute = new ToggleSwitch();
            tableLayoutPanel1 = new TableLayoutPanel();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(52, 152, 219);
            topPanel.Controls.Add(btnChangeProxy);
            topPanel.Controls.Add(btnReset);
            topPanel.Controls.Add(btnAddTabs);
            topPanel.Controls.Add(textBoxUrl);
            topPanel.Controls.Add(btnOpenVideo);
            topPanel.Controls.Add(btnCheckIp);
            topPanel.Controls.Add(btnInfo);
            topPanel.Controls.Add(toggleMute);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(10);
            topPanel.Size = new Size(1300, 60);
            topPanel.TabIndex = 1;
            // 
            // btnChangeProxy
            // 
            btnChangeProxy.BackColor = Color.FromArgb(41, 128, 185);
            btnChangeProxy.FlatStyle = FlatStyle.Flat;
            btnChangeProxy.ForeColor = Color.White;
            btnChangeProxy.Location = new Point(118, 13);
            btnChangeProxy.Name = "btnChangeProxy";
            btnChangeProxy.Size = new Size(80, 35);
            btnChangeProxy.TabIndex = 0;
            btnChangeProxy.Text = "Đổi Proxy";
            btnChangeProxy.UseVisualStyleBackColor = false;
            btnChangeProxy.Click += BtnChangeProxy_Click;
            btnChangeProxy.MouseEnter += Button_MouseEnter;
            btnChangeProxy.MouseLeave += Button_MouseLeave;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(41, 128, 185);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(386, 12);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(90, 35);
            btnReset.TabIndex = 1;
            btnReset.Text = "Khôi phục";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            btnReset.MouseEnter += Button_MouseEnter;
            btnReset.MouseLeave += Button_MouseLeave;
            // 
            // btnAddTabs
            // 
            btnAddTabs.BackColor = Color.FromArgb(41, 128, 185);
            btnAddTabs.FlatStyle = FlatStyle.Flat;
            btnAddTabs.ForeColor = Color.White;
            btnAddTabs.Location = new Point(290, 12);
            btnAddTabs.Name = "btnAddTabs";
            btnAddTabs.Size = new Size(90, 35);
            btnAddTabs.TabIndex = 2;
            btnAddTabs.Text = "Thêm Tab";
            btnAddTabs.UseVisualStyleBackColor = false;
            btnAddTabs.Click += BtnAddTabs_Click;
            btnAddTabs.MouseEnter += Button_MouseEnter;
            btnAddTabs.MouseLeave += Button_MouseLeave;
            // 
            // textBoxUrl
            // 
            textBoxUrl.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUrl.Location = new Point(725, 18);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.PlaceholderText = "Nhập link YouTube...";
            textBoxUrl.Size = new Size(400, 25);
            textBoxUrl.TabIndex = 3;
            // 
            // btnOpenVideo
            // 
            btnOpenVideo.BackColor = Color.FromArgb(41, 128, 185);
            btnOpenVideo.FlatStyle = FlatStyle.Flat;
            btnOpenVideo.ForeColor = Color.White;
            btnOpenVideo.Location = new Point(1132, 13);
            btnOpenVideo.Name = "btnOpenVideo";
            btnOpenVideo.Size = new Size(100, 35);
            btnOpenVideo.TabIndex = 4;
            btnOpenVideo.Text = "Mở Video";
            btnOpenVideo.UseVisualStyleBackColor = false;
            btnOpenVideo.Click += BtnOpenVideo_Click;
            btnOpenVideo.MouseEnter += Button_MouseEnter;
            btnOpenVideo.MouseLeave += Button_MouseLeave;
            // 
            // btnCheckIp
            // 
            btnCheckIp.BackColor = Color.FromArgb(41, 128, 185);
            btnCheckIp.FlatStyle = FlatStyle.Flat;
            btnCheckIp.ForeColor = Color.White;
            btnCheckIp.Location = new Point(12, 13);
            btnCheckIp.Name = "btnCheckIp";
            btnCheckIp.Size = new Size(100, 35);
            btnCheckIp.TabIndex = 5;
            btnCheckIp.Text = "Check IP";
            btnCheckIp.UseVisualStyleBackColor = false;
            btnCheckIp.Click += BtnCheckIp_Click;
            btnCheckIp.MouseEnter += Button_MouseEnter;
            btnCheckIp.MouseLeave += Button_MouseLeave;
            // 
            // btnInfo
            // 
            btnInfo.BackColor = Color.FromArgb(41, 128, 185);
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.ForeColor = Color.White;
            btnInfo.Location = new Point(204, 12);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(80, 35);
            btnInfo.TabIndex = 6;
            btnInfo.Text = "Info";
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Click += BtnInfo_Click;
            btnInfo.MouseEnter += Button_MouseEnter;
            btnInfo.MouseLeave += Button_MouseLeave;
            // 
            // toggleMute
            // 
            toggleMute.IsOn = false;
            toggleMute.Location = new Point(1238, 18);
            toggleMute.Name = "toggleMute";
            toggleMute.Size = new Size(50, 25);
            toggleMute.TabIndex = 7;
            toggleMute.CheckedChanged += toggleMute_CheckedChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 60);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Size = new Size(1300, 740);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1300, 800);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(topPanel);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            Text = "Tool Youtube";
            Load += Form1_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            this.Icon = new System.Drawing.Icon("lytranYT.ico");
        }

        #endregion
    }
}
