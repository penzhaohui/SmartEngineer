using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartEngineer.OutlookBar
{
    public class IconPanel : ContentPanel
    {
        protected int iconSpacing;
        protected int margin;

        public int IconSpacing
        {
            get
            {
                return iconSpacing;
            }
        }

        public int Margin
        {
            get
            {
                return margin;
            }
        }

        public IconPanel()
        {
            margin = 20;
            iconSpacing = 32 + 15 + 20; // icon height + text height + margin
            //BackColor = Color.LightBlue;
            AutoScroll = true;
        }

        public void AddIcon(string caption, Image image, EventHandler onClickEvent)
        {
            int index = Controls.Count / 2; // two entries per icon
            PanelIcon panelIcon = new PanelIcon(this, image, index, onClickEvent);
            Controls.Add(panelIcon);

            Label label = new Label();
            label.Text = caption;
            label.Visible = true;
            label.Location = new Point(0, margin + image.Size.Height + index * iconSpacing + 5);
            label.Size = new Size(Size.Width, 15);
            label.TextAlign = ContentAlignment.BottomCenter;
            label.Click += onClickEvent;
            label.Tag = panelIcon;
            Controls.Add(label);
        }
    }
}
