using System.Drawing;
using System.Windows.Forms;

namespace TFG
{
    internal class ToolStripOverride : ToolStripProfessionalRenderer
    {
        public ToolStripOverride() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderButtonBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(1, 1, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                SolidBrush Brush = new SolidBrush(Color.FromArgb(80, 80, 80));
                e.Graphics.FillRectangle(Brush, rectangle);
                Brush.Dispose();
            }
        }
        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {

            if (!e.Item.Selected)
            {
                base.OnRenderDropDownButtonBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(2, 2, e.Item.Size.Width - 2, e.Item.Size.Height - 2);
                SolidBrush Brush = new SolidBrush(Color.FromArgb(80, 80, 80));
                e.Graphics.FillRectangle(Brush, rectangle);
                Brush.Dispose();
            }
        }
        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderItemBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(1, 1, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                SolidBrush Brush = new SolidBrush(Color.FromArgb(80, 80, 80));
                e.Graphics.FillRectangle(Brush, rectangle);
                Brush.Dispose();
            }
        }
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(1, 1, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                SolidBrush Brush = new SolidBrush(Color.FromArgb(80, 80, 80));
                e.Graphics.FillRectangle(Brush, rectangle);
                Brush.Dispose();
            }
        }
    }
}
