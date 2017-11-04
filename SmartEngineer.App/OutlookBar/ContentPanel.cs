using System.Windows.Forms;

// Inheriting a Form from an Abstract Class (and Making it Work in the Designer) 
// https://www.codeproject.com/Articles/22788/Inheriting-a-Form-from-an-Abstract-Class-and-Makin
namespace SmartEngineer.OutlookBar
{
    public  
    #if RELEASE
        abstract
    #endif 
        class ContentPanel : Panel
    {
        public OutlookBar outlookBar;

        public ContentPanel()
        {
            // initial state
            Visible = true;
        }
    }
}
