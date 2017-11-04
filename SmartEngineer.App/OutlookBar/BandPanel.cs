using System.Windows.Forms;

namespace SmartEngineer.OutlookBar
{
    internal class BandPanel : Panel
    {
        public BandPanel(string caption, ContentPanel content, BandTagInfo bti)
        {
            BandButton bandButton = new BandButton(caption, bti);
            Controls.Add(bandButton);
            Controls.Add(content);
        }
    }
}
