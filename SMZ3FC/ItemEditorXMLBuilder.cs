using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SMZ3FC
{
    public static class ItemEditorXMLBuilder
    {
        private const string kMajors = "Majors";
        private const string kName = "name";
        private const string kHelp = "Help";

        public static XDocument GenerateXML(string title, ListBox lb, string helptext)
        {

            XDocument doc = new XDocument();
            XElement root = new XElement(kMajors);
            doc.Add(root);
            root.Add(new XAttribute(kName, title));

            root.Add(new XElement(kHelp, helptext));

            foreach (ItemEditorItemBuilderItem item in lb.Items)
            {

                root.Add(item.XMLNode);

                
            }

            return doc;


        }


    }
}
