using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMZ3FC
{
    public class ItemEditorItemBuilderItem
    {
        const string kItem = "Item";

        public int Index { get; private set; }

        public string Name { get; private set; }

        public XElement XMLNode { get { return BuildXMLNode(); } }

        public override string ToString()
        {
            return Name;
        }

        public ItemEditorItemBuilderItem(string n, int i)
        {
            Name = n;
            Index = i;
        }

        private XElement BuildXMLNode()
        {
            XElement ele = new XElement(kItem, Name);

            return ele;

        }

    }
}
