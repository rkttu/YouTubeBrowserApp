using System.Drawing;
using System.Windows.Forms;

namespace AccuRadioBrowserApp
{
    public partial class ToolStripSpringLabel : ToolStripLabel
    {
        public ToolStripSpringLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var flags = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine;
            var measuredSize = TextRenderer.MeasureText(e.Graphics, Text, Font);

            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    //x = Bounds.Width / 2 - measuredSize.Width / 2;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    //x = Bounds.Width - measuredSize.Width;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                default:
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
            }

            var bounds = new Rectangle(0, 0, Bounds.Width, Bounds.Height);
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
