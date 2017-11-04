using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartEngineer.OutlookBar
{
    public class PanelIcon : PictureBox
    {
        public int index;
        public IconPanel iconPanel;

        private Color bckgColor;
        private bool mouseEnter;

        public int Index
        {
            get
            {
                return index;
            }
        }

        public PanelIcon(IconPanel parent, Image image, int index, EventHandler onClickEvent)
        {
            this.index = index;
            this.iconPanel = parent;
            Image = image;
            Visible = true;
            Location = new Point(iconPanel.outlookBar.Size.Width / 2 - image.Size.Width / 2,
                            iconPanel.Margin + index * iconPanel.IconSpacing);
            Size = image.Size;
            Click += onClickEvent;
            Tag = this;

            MouseEnter += new EventHandler(OnMouseEnter);
            MouseLeave += new EventHandler(OnMouseLeave);
            MouseMove += new MouseEventHandler(OnMouseMove);

            bckgColor = iconPanel.BackColor;
            mouseEnter = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs args)
        {
            if ((args.X < Size.Width - 2) &&
                (args.Y < Size.Width - 2) &&
                (!mouseEnter))
            {
                BackColor = Color.LightCyan;
                BorderStyle = BorderStyle.FixedSingle;
                Location = Location - new Size(1, 1);
                mouseEnter = true;
            }
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (mouseEnter)
            {
                BackColor = bckgColor;
                BorderStyle = BorderStyle.None;
                Location = Location + new Size(1, 1);
                mouseEnter = false;
            }
        }
    }
}
