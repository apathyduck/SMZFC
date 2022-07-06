using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMZ3FC
{
    public class AreaEditorLocationBuilder
    {

        private const string kArea = "Area";
        private const string kLoc = "Loc";
        private const string kSubLoc = "SubLoc";
        private const string kTab = "tab";
        private const string kName = "name";

        public string Name { get; set; }

        public string Tab { get; set; }

        public List<AreaEditorLocationBuilderLocation> Locations { get; private set; } = new List<AreaEditorLocationBuilderLocation>();

        public List<AreaEditorLocationBuilderLocation> SubLocations { get; private set; } = new List<AreaEditorLocationBuilderLocation>();

        public XElement XMLNode { get { return BuildXMLNode(); } }


        private XElement BuildXMLNode()
        {

            XElement element = new XElement(kArea);
            element.Add(new XAttribute(kName, Name));
            element.Add(new XAttribute(kTab, Tab));

            foreach(AreaEditorLocationBuilderLocation albl in Locations)
            {
                element.Add(new XElement(kLoc, albl.Name));
            }

            foreach (AreaEditorLocationBuilderLocation albl in SubLocations)
            {
                element.Add(new XElement(kSubLoc, albl.Name));
            }

            return element;
        }


    }
}
