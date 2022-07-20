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

        public static SMZ3XMLFileInfo GenerateXML(string title, ListBox lb, string helptext, SMZ3XMLFileInfo fi)
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

            fi.Name = title;
            fi.Path = fi.Info.FullName;
            fi.Contents = doc.ToString();
            fi.FileType = SMZ3XMLFileType.Items;

            return fi;


        }


    }
}
