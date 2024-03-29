﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMZ3PublishWizard
{
    class UpdateXMLConfig
    {
        internal string Version
        {
            get
            {
                return $"{Major}.{Minor}.{Patch}.{Build}";
            }
        }

        internal int Major { get; set; }

        internal int Minor { get; set; }

        internal int Patch { get; set; }

        internal int Build { get; set; }

        internal string AssetUrl { get; set; }

        internal string NotesUrl { get; set; }

        internal bool Mandatory { get; set; }

        internal string Contents { get; set; }

        internal string PathOrUrl { get; set; }

        internal XDocument XMLDoc { get; set; }


        internal void UpdateXML(UpdateXMLConfig newconfig)
        {
            Major = newconfig.Major;
            Minor = newconfig.Minor;
            Patch = newconfig.Patch;
            Build = newconfig.Build;
            AssetUrl = newconfig.AssetUrl;
            NotesUrl = newconfig.NotesUrl;
            Mandatory = newconfig.Mandatory;

            XElement root = new XElement("item");
            root.Add(new XElement("version", Version));
            root.Add(new XElement("url", AssetUrl));
            root.Add(new XElement("changelog", NotesUrl));
            root.Add(new XElement("mandatory", Mandatory));

            XMLDoc = new XDocument();
            XMLDoc.Add(root);

            Contents = XMLDoc.ToString();
          
        }

        internal void ParseContents()
        {

            //string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            //if (Contents.StartsWith(_byteOrderMarkUtf8))
            //{
            //    Contents = Contents.Remove(0, _byteOrderMarkUtf8.Length);
            //}
            Contents = Contents.Trim();

            XMLDoc = XDocument.Parse(Contents, LoadOptions.PreserveWhitespace);
            XElement root = XMLDoc.Root;
            string version = root.Element("version").Value;
            string[] versionarry = version.Split('.');
            Major = Convert.ToInt32(versionarry[0]);
            Minor = Convert.ToInt32(versionarry[1]);
            Patch = Convert.ToInt32(versionarry[2]);
            Build = Convert.ToInt32(versionarry[3]);
            AssetUrl = root.Element("url").Value;
            NotesUrl = root.Element("changelog").Value;
            Mandatory = Convert.ToBoolean(root.Element("mandatory").Value);
        }

        internal void CreateNewXML()
        {

        }

    }
}
