using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartEngineer.OutlookBar
{
    public class OutlookBar : Panel
    {
        private int buttonHeight;
        private int selectedBand;
        private int selectedBandHeight;

        public int ButtonHeight
        {
            get
            {
                return buttonHeight;
            }

            set
            {
                buttonHeight = value;
                // do recalc layout for entire bar
            }
        }

        public int SelectedBand
        {
            get
            {
                return selectedBand;
            }
            set
            {
                SelectBand(value);
            }
        }

        public OutlookBar()
        {
            buttonHeight = 25;
            selectedBand = 0;
            selectedBandHeight = 0;
        }

        public void Initialize()
        {
            Parent.SizeChanged += new EventHandler(SizeChangedEvent);
        }

        public void AddBand(string caption, ContentPanel content)
        {
            content.outlookBar = this;
            int index = Controls.Count;
            BandTagInfo bti = new BandTagInfo(this, index);
            BandPanel bandPanel = new BandPanel(caption, content, bti);
            Controls.Add(bandPanel);
            UpdateBarInfo();
            RecalcLayout(bandPanel, index);
        }

        public void SelectBand(int index)
        {
            selectedBand = index;
            RedrawBands();
        }

        private void RedrawBands()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                BandPanel bp = Controls[i] as BandPanel;
                RecalcLayout(bp, i);
            }
        }

        private void UpdateBarInfo()
        {
            selectedBandHeight = ClientRectangle.Height - (Controls.Count * buttonHeight);
        }

        private void RecalcLayout(BandPanel bandPanel, int index)
        {
            int vPos = (index <= selectedBand) ? buttonHeight * index : buttonHeight * index + selectedBandHeight;
            int height = selectedBand == index ? selectedBandHeight + buttonHeight : buttonHeight;

            // the band dimensions
            bandPanel.Location = new Point(0, vPos);
            bandPanel.Size = new Size(ClientRectangle.Width, height);

            // the contained button dimensions
            bandPanel.Controls[0].Location = new Point(0, 0);
            bandPanel.Controls[0].Size = new Size(ClientRectangle.Width, buttonHeight);

            // the contained content panel dimensions
            bandPanel.Controls[1].Location = new Point(0, buttonHeight);
            bandPanel.Controls[1].Size = new Size(ClientRectangle.Width - 2, height - 8);
        }

        private void SizeChangedEvent(object sender, EventArgs e)
        {
            Size = new Size(Size.Width, ((Control)sender).ClientRectangle.Size.Height - 15);
            UpdateBarInfo();
            RedrawBands();
        }
    }
}
