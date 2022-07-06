using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SMZ3FC
{
    public static class AreaEditorXMLBuilder
    {
        private const string kAreas = "Areas";
        private const string kName = "name";
        private const string kHelp = "Help";

        public static XDocument GenerateXML(TreeNode top, string helptext)
        {

            XDocument doc = new XDocument();
            XElement root = new XElement(kAreas);
            doc.Add(root);
            root.Add(new XAttribute(kName, top.Text));

            root.Add(new XElement(kHelp, helptext));

            foreach(TreeNode tag in top.Nodes)
            {
                foreach(TreeNode loc in tag.Nodes)
                {

                    var alb = (AreaEditorLocationBuilder) loc.Tag;
                    root.Add(alb.XMLNode);
                }
            }


           
            return doc;
        }

    }
}
