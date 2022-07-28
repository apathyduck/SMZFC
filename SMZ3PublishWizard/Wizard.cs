using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMZ3FC;
using System.IO.Compression;
using System.Threading;

namespace SMZ3PublishWizard
{
    public partial class Wizard : Form
    {
        private int repoid = 510945946;
        private UpdateXMLConfig myLocalConfig;
        private UpdateXMLConfig myServerConfig;
        private UpdateXMLConfig myNewConfig;
        private string oauthtoken;
        private string releasePath;
        private string localXMLPath;
        private string serverXMLPath;
        private string initBomPath;
        private string updateBomPath;
        private string rootChangeUrl;
        private string initDirPath;
        private string updateDirPath;
        private GitHubClient gitClient;
        private  HttpClient httpClient;
        private DirectoryInfo releaseDirInfo;
        private DirectoryInfo initDirInfo;
        private DirectoryInfo updateDirInfo;
        private FileInfo initZipFileInfo;
        private FileInfo updateZIpFileInfo;
        private  WizardBOM initPackageBOM;
        private WizardBOM updatePackageBOM;
        Assembly smzAssembly;
       
        public Wizard()
        {
            InitializeComponent();

            lblUpdateStatus.Text = string.Empty;

            oauthtoken = ConfigurationManager.AppSettings["oauthtoken"];
            releasePath = ConfigurationManager.AppSettings["ReleasePath"];
            localXMLPath = ConfigurationManager.AppSettings["LocalXMLPath"];
            serverXMLPath = ConfigurationManager.AppSettings["ServerXMLPath"];
            rootChangeUrl = ConfigurationManager.AppSettings["ChangeLogUrlRoot"];
            initBomPath = ConfigurationManager.AppSettings["InitBOM"];
            updateBomPath = ConfigurationManager.AppSettings["UpdateBOM"];
            initDirPath = ConfigurationManager.AppSettings["InitDir"];
            updateDirPath = ConfigurationManager.AppSettings["UpdateDir"];


            releaseDirInfo = new DirectoryInfo(releasePath);
            initDirInfo = new DirectoryInfo(Path.Combine(releaseDirInfo.FullName, initDirPath));
            updateDirInfo = new DirectoryInfo(Path.Combine(releaseDirInfo.FullName, updateDirPath));


            gitClient = new GitHubClient(new ProductHeaderValue("SMZ3-Full-Countdown"));
            gitClient.Credentials = new Credentials(oauthtoken);

            GetLocalUpdateXML();
            GetServerUpdateXML();
            GetBoms();
            BuildNewUpdateXML();   
            GetReleaseDirFiles();
            
        }

        private void GetBoms()
        {
            initPackageBOM = new WizardBOM(new FileInfo(initBomPath), releaseDirInfo);
            updatePackageBOM = new WizardBOM(new FileInfo(updateBomPath), releaseDirInfo);
        }

        private void BuildNewUpdateXML()
        {
            smzAssembly = Assembly.GetAssembly(typeof(SMZ3FCManager));
            Version ver = smzAssembly.GetName().Version;
            myNewConfig = new UpdateXMLConfig();
            myNewConfig.Major = ver.Major;
            myNewConfig.Minor = ver.Minor;
            myNewConfig.Patch = ver.Revision;
            myNewConfig.Build = ver.Build;
            myNewConfig.NotesUrl = Path.Combine(rootChangeUrl, $"v{myNewConfig.Version}");

            tbNewVersion.Text = myNewConfig.Version;
            tbNewChange.Text = myNewConfig.NotesUrl;
        }

        private void GetReleaseDirFiles()
        {                  
            foreach (FileInfo fi in releaseDirInfo.GetFiles())
            {
                BomFileInfo bfi = new BomFileInfo(fi.FullName);
                clbReleaseDirItems.Items.Add(bfi);                     
            }
            foreach(DirectoryInfo di in releaseDirInfo.GetDirectories())
            {
                BomFileInfo bfi = new BomFileInfo(di.FullName);
                clbReleaseDirItems.Items.Add(bfi);
            }

            UpdateCheckedItems(rbNew.Checked);
        }

        

        private async void GetServerUpdateXML()
        {
            httpClient = new HttpClient();
            var result = await httpClient.GetAsync(serverXMLPath);
            myServerConfig = new UpdateXMLConfig();
            myServerConfig.PathOrUrl = serverXMLPath;
            myServerConfig.Contents = await result.Content.ReadAsStringAsync();
            
            myServerConfig.ParseContents();
            tbServerVer.Text = myServerConfig.Version;
            tbServerAsset.Text = myServerConfig.AssetUrl;
            tbServerChange.Text = myServerConfig.NotesUrl;
            cbServerMandatory.Checked = myServerConfig.Mandatory;
            
        }

        private void GetLocalUpdateXML()
        {
            myLocalConfig = new UpdateXMLConfig();
            myLocalConfig.Contents = File.ReadAllText(localXMLPath);
            myLocalConfig.PathOrUrl = Path.GetFullPath(localXMLPath);
            myLocalConfig.ParseContents();

            tbLocalVersion.Text = myLocalConfig.Version;
            tbLocalAsset.Text = myLocalConfig.AssetUrl;
            tbLocalChange.Text = myLocalConfig.NotesUrl;
            cbLocalMandatory.Checked = myLocalConfig.Mandatory;
        }

      

        private void rbNew_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckedItems(rbNew.Checked);
        }

        private void UpdateCheckedItems(bool newpackage)
        {
            WizardBOM bomtouse = null;
            if (newpackage)
            {
                bomtouse = initPackageBOM;
            }
            else
            {
                bomtouse = updatePackageBOM;
            }

            for(int n =0; n < clbReleaseDirItems.Items.Count; n++)
            {
                BomFileInfo fi = (BomFileInfo)clbReleaseDirItems.Items[n];
                clbReleaseDirItems.SetItemChecked(n, bomtouse.BOM.Contains(fi));
               
            }     
        }

        private void clbReleaseDirItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BomFileInfo bfi =  (BomFileInfo)clbReleaseDirItems.Items[e.Index];
            WizardBOM bom = null;
            
            if(rbNew.Checked)
            {
                bom = initPackageBOM;
            }
            else
            {
                bom = updatePackageBOM;
            }
            
            if(CheckState.Checked == e.NewValue)
            {
                if (!bom.BOM.Contains(bfi))
                {
                    bom.BOM.Add(bfi);
                }
            }
            else
            {
                if (bom.BOM.Contains(bfi))
                {
                    bom.BOM.Remove(bfi);
                }
            }

        }

        private void btnApplyUpdate_Click(object sender, EventArgs e)
        {
            CreateUpdate();
        }

        private async void CreateUpdate()
        {

            this.Enabled = false;
            lblUpdateStatus.Text = "Start";

            CreateUpdatePackages();
            lblUpdateStatus.Text = "Zips Created";

            await CreateRelease();
            lblUpdateStatus.Text = "Release Created";



            initPackageBOM.WriteUpdatedXML();
            updatePackageBOM.WriteUpdatedXML();

            myLocalConfig.UpdateXML(myNewConfig);
            myServerConfig.UpdateXML(myNewConfig);

            
            UpdateLocalXML();
            UpdateServerXML();
            lblUpdateStatus.Text = "Finished";
            this.Enabled = true;
           
        }

       

        private async Task CreateRelease()
        {
           

   
            var newRelease = new NewRelease($"v{myNewConfig.Version}");
            newRelease.Name = $"v{myNewConfig.Version}";
            newRelease.Body = rtbPatchNotes.Text;
            newRelease.Draft = false;
            newRelease.Prerelease = true;
            var release = await gitClient.Repository.Release.Create(repoid, newRelease);
            
            ReleaseAssetUpload iniras = CreateAsset(initZipFileInfo);
            var inires = await gitClient.Repository.Release.UploadAsset(release,iniras);


            ReleaseAssetUpload upras = CreateAsset(updateZIpFileInfo);
            var upres = await gitClient.Repository.Release.UploadAsset(release, upras);
            myNewConfig.AssetUrl = upres.BrowserDownloadUrl;
            tbNewAsset.Text = myNewConfig.AssetUrl;

        }

        private ReleaseAssetUpload CreateAsset(FileInfo initZipFileInfo)
        {
            ReleaseAssetUpload rau = new ReleaseAssetUpload();
            rau.FileName = initZipFileInfo.Name;
            rau.RawData = initZipFileInfo.OpenRead();
            rau.ContentType = @"application/zip";
            return rau;
        }

        private void CreateUpdatePackages()
        {
            if (initDirInfo.Exists) { initDirInfo.Delete(true); }
            if (updateDirInfo.Exists) { updateDirInfo.Delete(true); }

            initDirInfo.Create();
            updateDirInfo.Create();

            CopyBomFiles(initPackageBOM, initDirInfo);
            CopyBomFiles(updatePackageBOM, updateDirInfo);

            initZipFileInfo = CreateZipFiles(initDirInfo);
            updateZIpFileInfo = CreateZipFiles(updateDirInfo);

        }

       

        private void CopyBomFiles(WizardBOM wz, DirectoryInfo di)
        {
            foreach(BomFileInfo bfi in wz.BOM)
            {
                if (bfi.Info.Exists)
                {
                    bfi.FoundInBuild = true;
                    bfi.CopyTo(Path.Combine(di.FullName, bfi.Info.Name));
                }
                else
                {
                    bfi.FoundInBuild = false;
                }
            }
        }

        private FileInfo CreateZipFiles(DirectoryInfo zipDir)
        {
            FileInfo zfi = new FileInfo(Path.Combine(releaseDirInfo.FullName, $"{zipDir.Name}.zip"));
            if (zfi.Exists) { zfi.Delete(); }
            ZipFile.CreateFromDirectory(zipDir.FullName, Path.Combine(releaseDirInfo.FullName, $"{zipDir.Name}.zip"));
            return zfi;
        }

        private void UpdateLocalXML()
        {
            myLocalConfig.XMLDoc.Save(myLocalConfig.PathOrUrl);
        }

        private async void UpdateServerXML()
        {
            var updatefiles = await gitClient.Repository.Content.GetAllContents(repoid, @"SMZ3FC/UpdateConfig.xml");
            var updatefile = updatefiles[0];
           

            UpdateFileRequest ufr = new UpdateFileRequest("Autoupdater Config", myServerConfig.Contents, updatefile.Sha);
            var upres = await gitClient.Repository.Content.UpdateFile(repoid, @"SMZ3FC/UpdateConfig.xml", ufr);
        }
    }

}

