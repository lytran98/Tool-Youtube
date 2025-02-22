using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YoutubeMultiManual
{
    public class ToggleSwitch : Control
    {
        private bool isOn = false;
        /// <summary>
        /// Trạng thái On/Off của ToggleSwitch.
        /// </summary>
        public bool IsOn
        {
            get => isOn;
            set
            {
                isOn = value;
                Invalidate();
                OnCheckedChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Sự kiện thay đổi trạng thái On/Off.
        /// </summary>
        public event EventHandler CheckedChanged;

        /// <summary>
        /// Gọi khi IsOn thay đổi.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }

        public ToggleSwitch()
        {
            // Kích thước mặc định
            this.Size = new Size(50, 25);
            this.DoubleBuffered = true;
        }

        protected override void OnClick(EventArgs e)
        {
            // Nhấn chuột => Đổi trạng thái
            IsOn = !IsOn;
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Khu vực vẽ chính (bo tròn viền)
            Rectangle rect = ClientRectangle;
            rect.Inflate(-1, -1);

            // Tính bán kính bo tròn (pill shape)
            int radius = rect.Height / 2;

            // Tạo GraphicsPath cho khung bo tròn
            using (GraphicsPath path = GetRoundedRectPath(rect, radius))
            {
                // Chọn màu nền dựa vào trạng thái On/Off
                // Bạn có thể thay đổi thành màu khác nếu muốn
                Color backColor = IsOn
                    ? Color.FromArgb(33, 150, 243) // xanh dương (On)
                    : Color.FromArgb(189, 189, 189); // xám (Off)

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Vẽ đường viền nhạt xung quanh
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            // Vẽ nút tròn (phần di chuyển)
            int circleDiameter = rect.Height - 4; // bớt 4px để có khoảng cách trên dưới
            int circleX = IsOn
                ? rect.Right - circleDiameter - 2  // nếu On => nút nằm bên phải
                : rect.Left + 2;                  // nếu Off => nút nằm bên trái
            int circleY = rect.Top + 2;

            Rectangle circleRect = new Rectangle(circleX, circleY, circleDiameter, circleDiameter);

            using (SolidBrush circleBrush = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(circleBrush, circleRect);
            }
        }

        /// <summary>
        /// Tạo GraphicsPath bo tròn 4 góc cho hình chữ nhật.
        /// </summary>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            // Góc trên trái
            path.AddArc(arcRect, 180, 90);

            // Góc trên phải
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // Góc dưới phải
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // Góc dưới trái
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
