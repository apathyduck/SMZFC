using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMZ3PublishWizard
{
    class WizardBOM
    {
        internal List<BomFileInfo> BOM { get; private set; }
        internal FileInfo BOMFileInfo { get; private set; }
        internal XDocument BOMXML { get; private set; }
        internal DirectoryInfo RootDir { get; private set; }

        internal WizardBOM(FileInfo fi, DirectoryInfo di)
        {
            BOM = new List<BomFileInfo>();
            BOMFileInfo = fi;
            RootDir = di;
            if (!BOMFileInfo.Exists)
            {
                BOMXML = new XDocument();
            }
            else
            {

                BOMXML = XDocument.Load(BOMFileInfo.FullName);
                XElement root = BOMXML.Root;

                foreach (XElement file in root.Elements())
                {
                    string filename = file.Attribute("name").Value;
                    BomFileInfo xfi = new BomFileInfo(Path.Combine(RootDir.FullName, filename));
                    BOM.Add(xfi);
                }
            }
        }

        internal void WriteUpdatedXML()
        {
            List<BomFileInfo> notfound = (from nf in BOM where !nf.FoundInBuild select nf).ToList();


            foreach (BomFileInfo nfs in notfound)
            {
                BOM.Remove(nfs);
            }


            XElement newroot = new XElement("BOM");
            foreach (BomFileInfo bfi in BOM)
            {
                newroot.Add(new XElement("File", new XAttribute("name", bfi.Info.Name)));
            }

            BOMXML = new XDocument();
            BOMXML.Add(newroot);

            BOMXML.Save(BOMFileInfo.FullName);
        }
    }

    class BomFileInfo 
    {

        internal bool FoundInBuild { get; set; } = false;

        internal BomFileInfo(string path)
        {
            Info = new FileInfo(path);
        }

        internal FileInfo Info { get; set; }

        public override string ToString()
        {
            return Info.Name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BomFileInfo)) { return false; }
            return Info.FullName.Equals(((BomFileInfo)obj).Info.FullName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();

        }
    }
}
