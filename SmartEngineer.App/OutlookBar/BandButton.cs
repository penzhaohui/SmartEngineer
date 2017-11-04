using System;
using System.Windows.Forms;

namespace SmartEngineer.OutlookBar
{
    internal class BandButton : Button
    {
        private BandTagInfo bti;

        public BandButton(string caption, BandTagInfo bti)
        {
            Text = caption;
            FlatStyle = FlatStyle.Standard;
            Visible = true;
            this.bti = bti;
            Click += new EventHandler(SelectBand);
        }

        private void SelectBand(object sender, EventArgs e)
        {
            bti.outlookBar.SelectBand(bti.index);
        }
    }
}
