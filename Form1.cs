using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.VisualBasic;
using System.Drawing;

namespace YoutubeMultiManual
{
    public partial class Form1 : Form
    {
        private List<WebView2> webViews = new List<WebView2>();
        private int columns = 3; // Số cột mặc định

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Mặc định mở 6 tab khi chạy ứng dụng
            AddTabs(6);
        }

        /// <summary>
        /// Thêm một số lượng tab (WebView2) nhất định.
        /// </summary>
        private void AddTabs(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var wv = new WebView2();
                webViews.Add(wv);
            }
            RebuildLayout();
        }

        /// <summary>
        /// Xây dựng lại layout sau khi thêm hoặc xóa WebView2.
        /// </summary>
        private async void RebuildLayout()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            int total = webViews.Count;
            int rows = (total + columns - 1) / columns;

            tableLayoutPanel1.ColumnCount = columns;
            tableLayoutPanel1.RowCount = rows;

            for (int c = 0; c < columns; c++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f / columns));
            }
            for (int r = 0; r < rows; r++)
            {
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f / rows));
            }

            for (int i = 0; i < total; i++)
            {
                int row = i / columns;
                int col = i % columns;
                var wv = webViews[i];
                wv.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(wv, col, row);

                if (wv.CoreWebView2 == null)
                {
                    string folder = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "LyTranYT", "Profiles", $"Tab_{i}"
                    );
                    Directory.CreateDirectory(folder);

                    var env = await CoreWebView2Environment.CreateAsync(null, folder);
                    await wv.EnsureCoreWebView2Async(env);
                    wv.CoreWebView2.Navigate("https://www.youtube.com/");
                }
            }
        }

        /// <summary>
        /// Đổi IP (proxy) cho các tab (nếu có ProxyForm).
        /// </summary>
        private async void BtnChangeProxy_Click(object? sender, EventArgs e)
        {
            int tabCount = webViews.Count;
            using (var pf = new ProxyForm(tabCount))
            {
                if (pf.ShowDialog() == DialogResult.OK)
                {
                    var proxies = pf.ProxyList; // Danh sách ProxyInfo, độ dài = tabCount

                    for (int i = 0; i < tabCount; i++)
                    {
                        var p = proxies[i];
                        if (p != null)
                        {
                            // Hủy WebView2 cũ
                            var oldWv = webViews[i];
                            tableLayoutPanel1.Controls.Remove(oldWv);
                            oldWv.Dispose();

                            // Tạo WebView2 mới
                            var newWv = new WebView2();
                            webViews[i] = newWv;

                            string folder = Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                "LyTranYT", "Profiles", $"Tab_{i}_{Guid.NewGuid()}"
                            );
                            Directory.CreateDirectory(folder);

                            string proxyArg = $"--proxy-server={p.ToCommandArg()}";
                            var envOptions = new CoreWebView2EnvironmentOptions(proxyArg);
                            var env = await CoreWebView2Environment.CreateAsync(null, folder, envOptions);

                            newWv.Dock = DockStyle.Fill;
                            int row = i / columns;
                            int col = i % columns;
                            tableLayoutPanel1.Controls.Add(newWv, col, row);

                            await newWv.EnsureCoreWebView2Async(env);
                            newWv.CoreWebView2.Navigate("https://www.youtube.com/");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// "Reset" - Xoá tất cả tab, mở lại mặc định 6 tab.
        /// </summary>
        private void BtnReset_Click(object? sender, EventArgs e)
        {
            foreach (var wv in webViews)
            {
                tableLayoutPanel1.Controls.Remove(wv);
                wv.Dispose();
            }
            webViews.Clear();
            AddTabs(6);
        }

        /// <summary>
        /// "Thêm Tab" - cho phép người dùng nhập số tab cần thêm.
        /// </summary>
        private void BtnAddTabs_Click(object? sender, EventArgs e)
        {
            string input = Interaction.InputBox(
                "Nhập số tab cần mở thêm",
                "Thêm Tab",
                "1"
            );
            if (int.TryParse(input, out int num) && num > 0)
            {
                AddTabs(num);
            }
        }

        /// <summary>
        /// "Mở Video" - chuyển tất cả tab sang link YouTube mà người dùng nhập.
        /// </summary>
        private void BtnOpenVideo_Click(object? sender, EventArgs e)
        {
            string url = textBoxUrl.Text.Trim();

            if (!string.IsNullOrWhiteSpace(url))
            {
                // Chuyển đổi link thành dạng embed có autoplay
                string embedUrl = ConvertToEmbedUrl(url);

                foreach (var wv in webViews)
                {
                    if (wv.CoreWebView2 != null)
                    {
                        wv.CoreWebView2.Navigate(embedUrl);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập link video YouTube!", "Thiếu link",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ConvertToEmbedUrl(string url)
        {
            try
            {
                // Nếu đã là dạng embed, chỉ cần đảm bảo có autoplay
                if (url.Contains("youtube.com/embed/"))
                {
                    if (!url.Contains("autoplay="))
                    {
                        if (url.Contains("?"))
                            url += "&autoplay=1";
                        else
                            url += "?autoplay=1";
                    }
                    return url;
                }
                // Nếu là link watch (vd: https://www.youtube.com/watch?v=VIDEO_ID)
                if (url.Contains("youtube.com/watch"))
                {
                    Uri uri = new Uri(url);
                    var query = uri.Query;
                    var queryParts = query.TrimStart('?').Split('&');
                    string videoId = null;
                    foreach (var part in queryParts)
                    {
                        var kv = part.Split('=');
                        if (kv.Length == 2 && kv[0] == "v")
                        {
                            videoId = kv[1];
                            break;
                        }
                    }
                    if (!string.IsNullOrEmpty(videoId))
                    {
                        return $"https://www.youtube.com/embed/{videoId}?autoplay=1";
                    }
                }
                // Nếu không nhận dạng được, chỉ thêm autoplay=1 vào cuối link
                if (url.Contains("?"))
                    return url + "&autoplay=1";
                return url + "?autoplay=1";
            }
            catch (Exception)
            {
                // Nếu có lỗi thì fallback cách đơn giản
                if (url.Contains("?"))
                    return url + "&autoplay=1";
                return url + "?autoplay=1";
            }
        }


        /// <summary>
        /// Toggle Mute - Bật/tắt âm thanh toàn bộ tab (sử dụng ToggleSwitch).
        /// </summary>
        private void toggleMute_CheckedChanged(object sender, EventArgs e)
        {
            // Dùng thuộc tính IsOn của ToggleSwitch
            bool isMuted = toggleMute.IsOn;

            foreach (var wv in webViews)
            {
                if (wv.CoreWebView2 != null)
                {
                    wv.CoreWebView2.IsMuted = isMuted;
                }
            }
        }

        /// <summary>
        /// "Check IP" - Điều hướng tất cả các tab sang trang hiển thị IP.
        /// </summary>
        private void BtnCheckIp_Click(object? sender, EventArgs e)
        {
            string ipUrl = "https://api.ipify.org";
            foreach (var wv in webViews)
            {
                if (wv.CoreWebView2 != null)
                {
                    wv.CoreWebView2.Navigate(ipUrl);
                }
            }
        }

        /// <summary>
        /// "Info" - Mở form giới thiệu phần mềm và tác giả.
        /// </summary>
        private void BtnInfo_Click(object? sender, EventArgs e)
        {
            using (InfoForm infoForm = new InfoForm())
            {
                infoForm.ShowDialog();
            }
        }

        // Các sự kiện thay đổi màu nút khi hover/leave
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // Sử dụng màu sắc tối hơn khi hover
                btn.BackColor = Color.FromArgb(31, 97, 141);
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // Màu mặc định của các nút
                btn.BackColor = Color.FromArgb(41, 128, 185);
            }
        }
    }
}
