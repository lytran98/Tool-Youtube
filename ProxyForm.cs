using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YoutubeMultiManual
{
    public partial class ProxyForm : Form
    {
        private int _tabCount;
        public List<ProxyInfo?> ProxyList { get; private set; } = new List<ProxyInfo?>();

        public ProxyForm(int tabCount)
        {
            _tabCount = tabCount;
            InitializeComponent();
        }

        private void ProxyForm_Load(object sender, EventArgs e)
        {
            dgvProxies.ColumnCount = 4;
            // Cột 0: Tab #
            dgvProxies.Columns[0].Name = "Tab #";
            dgvProxies.Columns[0].ReadOnly = true;
            // Cột 1: IP
            dgvProxies.Columns[1].Name = "IP";
            // Cột 2: Port
            dgvProxies.Columns[2].Name = "Port";
            // Cột 3: Protocol
            dgvProxies.Columns[3].Name = "Protocol"; // HTTP, HTTPS, SOCKS4, SOCKS5

            // Tạo rowCount = _tabCount
            dgvProxies.RowCount = _tabCount;

            // Điền Tab #
            for (int i = 0; i < _tabCount; i++)
            {
                dgvProxies.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void btnApplyProxy_Click(object sender, EventArgs e)
        {
            ProxyList.Clear();

            for (int i = 0; i < _tabCount; i++)
            {
                var row = dgvProxies.Rows[i];
                string ip = row.Cells[1].Value?.ToString() ?? "";
                string portStr = row.Cells[2].Value?.ToString() ?? "";
                string protocol = row.Cells[3].Value?.ToString() ?? "";

                if (!string.IsNullOrWhiteSpace(ip) && !string.IsNullOrWhiteSpace(portStr))
                {
                    if (int.TryParse(portStr, out int port))
                    {
                        ProxyList.Add(new ProxyInfo
                        {
                            IP = ip,
                            Port = port,
                            Protocol = protocol
                        });
                    }
                    else
                    {
                        // Port không parse được => null
                        ProxyList.Add(null);
                    }
                }
                else
                {
                    // User để trống => không đổi
                    ProxyList.Add(null);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
