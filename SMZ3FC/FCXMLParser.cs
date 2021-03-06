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

       // private static Dictionary<string, AreaGroupings> AreaGroups  = new Dictionary<string, AreaGroupings>();
        private static Dictionary<string, MajorItemsDefinition> ItemSets = new Dictionary<string, MajorItemsDefinition>();

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

        //static public (Dictionary<string,AreaGroupings>, Dictionary<string,MajorItemsDefinition>) LoadLocationData()
        //{
        //    DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);

        //    foreach(FileInfo fi in di.EnumerateFiles())
        //    {
        //        if(fi.Extension.Equals(".xml"))
        //        {
        //            ParseFile(fi);
        //        }
        //    }

        //    return (AreaGroups,ItemSets);

        //}


        //static public void LoadSingleFile(FileInfo fi)
        //{
        //    ParseFile(fi);
        //}

        //static private void ParseFile(FileInfo fi)
        //{
        //    XDocument doc = XDocument.Load(fi.FullName);
        //    XElement root = doc.Root;
        //    try
        //    {
        //        if ((root?.Name.ToString().Equals(kAreas) ?? false) && (root.FirstAttribute?.Name.ToString().Equals(kName) ?? false))
        //        {
        //            ParseLocations(root, fi);

        //        }
        //    }
        //    catch
        //    {
        //       //Bad XML?
        //    }
        //    try
        //    {
        //        if ((root?.Name.ToString().Equals(kMajors) ?? false) && (root.FirstAttribute?.Name.ToString().Equals(kName) ?? false))
        //        {
        //            ParseItems(root, fi);
        //        }
        //    }
        //    catch
        //    {
        //        //Bad XML?

        //    }
        //}

        //static private void ParseLocations(XElement root, FileInfo fi)
        //{
        //    try
        //    {

        //        string groupname = root.Attribute(kName).Value;
        //        List<CollatedLocationData> clds = new List<CollatedLocationData>();
        //        List<ShiftedSubLocation> ssloc = new List<ShiftedSubLocation>();

        //        foreach (XElement area in root.Elements(kArea))
        //        {

        //            string areaname = area.Attribute(kName).Value;
        //            string game = area.Attribute(kTab).Value;

        //            List<string> locnames = new List<string>();
        //            List<string> sublocs = new List<string>();



        //            foreach (XElement locs in area.Elements())
        //            {

        //                switch (locs.Name.ToString())
        //                {
        //                    case kLoc:
        //                        locnames.Add(locs.Value);
        //                        break;
        //                    case kSubLoc:
        //                        sublocs.Add(locs.Value);
        //                        ssloc.Add(new ShiftedSubLocation(locs.Value, areaname));
        //                        break;
        //                    default:
        //                        //Bad format abort
        //                        throw new Exception();

        //                }

        //            }



        //            clds.Add(new CollatedLocationData(areaname, game, locnames, sublocs));

        //        }

        //        string help = string.Empty;
        //        try
        //        {


        //            help = root.Elements(kHelp).First().Value;
        //        }
        //        catch
        //        {
        //            //Its fine if it doesnt have help. I assume theres a less stupid fucking way of doing this but ¯\_(ツ)_/¯ 

        //        }



        //        AreaGroups.Add(groupname, new AreaGroupings(groupname, fi, clds, ssloc, help));

        //    }
        //    catch
        //    {

        //        return;
        //    }

        //}



        //    static private void ParseItems(XElement root,FileInfo fi)
        //    {
        //        try
        //        {
        //            List<string> items = new List<string>();
        //            string ilname = root.Attribute(kName).Value;
        //            foreach (XElement itm in root.Elements())
        //            {
        //                items.Add(itm.Value);

        //            }

        //            string help = string.Empty;
        //            try
        //            {

        //                help = root.Elements(kHelp).First().Value;
        //            }
        //            catch
        //            {
        //                //Its fine if it doesnt have help. I assume theres a lead stupid fucking way of doing this but ¯\_(ツ)_/¯ 

        //            }

        //            ItemSets.Add(ilname, new MajorItemsDefinition(ilname,fi,items,help));
        //        }
        //        catch
        //        {
        //            return;
        //        }
        //    }
    }
}
