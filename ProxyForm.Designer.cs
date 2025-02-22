namespace YoutubeMultiManual
{
    partial class ProxyForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProxies;
        private System.Windows.Forms.Button btnApplyProxy;

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
            this.dgvProxies = new System.Windows.Forms.DataGridView();
            this.btnApplyProxy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProxies)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProxies
            // 
            this.dgvProxies.AllowUserToAddRows = false;
            this.dgvProxies.AllowUserToDeleteRows = false;
            this.dgvProxies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProxies.Location = new System.Drawing.Point(12, 12);
            this.dgvProxies.Name = "dgvProxies";
            this.dgvProxies.Size = new System.Drawing.Size(500, 360);
            this.dgvProxies.TabIndex = 0;
            // 
            // btnApplyProxy
            // 
            this.btnApplyProxy.Location = new System.Drawing.Point(12, 380);
            this.btnApplyProxy.Name = "btnApplyProxy";
            this.btnApplyProxy.Size = new System.Drawing.Size(120, 35);
            this.btnApplyProxy.TabIndex = 1;
            this.btnApplyProxy.Text = "Đổi IP";
            this.btnApplyProxy.UseVisualStyleBackColor = true;
            this.btnApplyProxy.Click += new System.EventHandler(this.btnApplyProxy_Click);
            // 
            // ProxyForm
            // 
            this.ClientSize = new System.Drawing.Size(530, 430);
            this.Controls.Add(this.btnApplyProxy);
            this.Controls.Add(this.dgvProxies);
            this.Name = "ProxyForm";
            this.Text = "Nhập Proxy";
            this.Load += new System.EventHandler(this.ProxyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProxies)).EndInit();
            this.ResumeLayout(false);
            this.Icon = new System.Drawing.Icon("lytranYT.ico");
        }

        #endregion
    }
}
