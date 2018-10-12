using System.Drawing;
using System.Windows.Forms;

namespace YouTubeBrowserApp
{
    public partial class ToolStripSpringLabel : ToolStripLabel
    {
        public ToolStripSpringLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var flags = TextFormatFlags.EndEllipsis;
            var measuredSize = TextRenderer.MeasureText(e.Graphics, Text, Font);
            int x = 0, y = 0;

            switch (TextAlign)
            {
                default:
                case ContentAlignment.TopLeft:
                    break;
                case ContentAlignment.TopCenter:
                    x = Bounds.Width / 2 - measuredSize.Width / 2;
                    break;
                case ContentAlignment.TopRight:
                    x = Bounds.Width - measuredSize.Width;
                    break;
                case ContentAlignment.MiddleLeft:
                    y = Bounds.Height / 2 - measuredSize.Height / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                    x = Bounds.Width / 2 - measuredSize.Width / 2;
                    y = Bounds.Height / 2 - measuredSize.Height / 2;
                    break;
                case ContentAlignment.MiddleRight:
                    x = Bounds.Width - measuredSize.Width;
                    y = Bounds.Height / 2 - measuredSize.Height / 2;
                    break;
                case ContentAlignment.BottomLeft:
                    y = Bounds.Height - measuredSize.Height;
                    break;
                case ContentAlignment.BottomCenter:
                    x = Bounds.Width / 2 - measuredSize.Width / 2;
                    y = Bounds.Height - measuredSize.Height;
                    break;
                case ContentAlignment.BottomRight:
                    x = Bounds.Width - measuredSize.Width;
                    y = Bounds.Height - measuredSize.Height;
                    break;
            }

            var bounds = new Rectangle(x, y, Bounds.Width, Bounds.Height);
            TextRenderer.DrawText(e.Graphics, Text, Font, bounds, ForeColor, flags);
        }

        public override Size GetPreferredSize(Size constrainingSize)
        {
            if (IsOnOverflow || Owner.Orientation == Orientation.Vertical)
                return DefaultSize;

            int width = Owner.DisplayRectangle.Width;

            if (Owner.OverflowButton.Visible)
            {
                width = width - Owner.OverflowButton.Width -
                    Owner.OverflowButton.Margin.Horizontal;
            }

            int springBoxCount = 0;

            foreach (ToolStripItem item in Owner.Items)
            {
                if (item.IsOnOverflow)
                    continue;

                if (item is ToolStripSpringLabel)
                {
                    springBoxCount++;
                    width -= item.Margin.Horizontal;
                }
                else
                {
                    width = width - item.Width - item.Margin.Horizontal;
                }
            }

            if (springBoxCount > 1)
                width /= springBoxCount;

            if (width < DefaultSize.Width)
                width = DefaultSize.Width;

            Size size = base.GetPreferredSize(constrainingSize);
            size.Width = width;
            return size;
        }
    }
}
