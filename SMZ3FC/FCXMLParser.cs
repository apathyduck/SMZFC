using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace SMZ3FC
{
    public static class FCXMLParser
    {

        const string kAreas = "Areas";
        const string kArea = "Area";
        const string kLoc = "Loc";
        const string kSubLoc = "SubLoc";
        const string kTab = "tab";
        const string kName = "name";
        const string kMajors = "Majors";
        const string kItems = "Items";
        const string kItem = "Item";
        const string kHelp = "Help";

      

        public static Dictionary<string, SMZ3XMLFileInfo> WorldFiles;
        public static Dictionary<string, SMZ3XMLFileInfo> ItemFiles;
        public static List<FileInfo> UnparsedFiles;

        static public void DiscoverSMZ3DefinitionFiles()
        {
            WorldFiles = new Dictionary<string, SMZ3XMLFileInfo>();
            ItemFiles = new Dictionary<string, SMZ3XMLFileInfo>();
            UnparsedFiles = new List<FileInfo>();

            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
            foreach(FileInfo fi in di.EnumerateFiles())
            {
                if(fi.Extension.Equals(".xml"))
                {
                    DiscoverFileType(fi);
                }
            }
        }

        static private void DiscoverFileType(FileInfo fi)
        {
            XDocument doc = XDocument.Load(fi.FullName);
            XElement root = doc.Root;
            if ((root?.Name.ToString().Equals(kAreas) ?? false) && (root.FirstAttribute?.Name.ToString().Equals(kName) ?? false))
            {
                SMZ3XMLFileInfo xfi = new SMZ3XMLFileInfo();
                xfi.Name = root.Attribute(kName).Value;
                xfi.Path = fi.FullName;
                xfi.FileType = SMZ3XMLFileType.World;
                xfi.Contents = File.ReadAllText(fi.FullName);
                WorldFiles.Add(xfi.Name, xfi);
            }

            else if ((root?.Name.ToString().Equals(kMajors) ?? false) && (root.FirstAttribute?.Name.ToString().Equals(kName) ?? false))
            {
                SMZ3XMLFileInfo xfi = new SMZ3XMLFileInfo();
                xfi.Name = root.Attribute(kName).Value;
                xfi.Path = fi.FullName;
                xfi.FileType = SMZ3XMLFileType.Items;
                xfi.Contents = File.ReadAllText(fi.FullName);
                ItemFiles.Add(xfi.Name, xfi);
            }
            else
            {
                UnparsedFiles.Add(fi);
            }
        }

       
    }
}
