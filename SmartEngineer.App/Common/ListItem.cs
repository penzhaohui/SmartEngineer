using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Common
{
    internal class ListItem : System.Object
    {
        public ListItem(string text, dynamic value)
        {
            this.Text = text;
            this.Value = value;
        }

        public string Text { get; set; }
        public dynamic Value { get; set; }
        public override string ToString()
        {
            return this.Text;
        }
    }
}
