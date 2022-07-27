using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;
using System.Net.Http;
using System.Threading;
using System.IO;

namespace SMZ3FC
{
    public partial class FormGitXML : Form
    {

        private int repoid = 511026164;
        GitHubClient gitClient;
        string kAreaFolderName = "Area Group Files";
        string kItemFolderName = "Item Files";
        public List<SMZ3XMLFileInfo> NewFiles { get; private set; }
        Thread loadthread;

       
        public FormGitXML()
        {
            InitializeComponent();
           
            gitClient = new GitHubClient(new ProductHeaderValue("SMZ3-Full-Countdown-XML-Files"));


            EnableAllControls(false);
           


           
        }


        void LoadFilesThread()
        {
         
                Action setpb = delegate { SetProgessValue(0); };
                pbSync.Invoke(setpb);

                var threadrepo = gitClient.Repository.Content.GetAllContents(repoid);
                threadrepo.Wait();

                setpb = delegate { SetProgessValue(33); };

                pbSync.Invoke(setpb);

                var repo = threadrepo.Result;
                int totalarea = 0;
                int totalitem = 0;



                foreach (var c in repo)
                {
                    if (c.Name.Equals(kAreaFolderName))
                    {
                        var threadfiles = gitClient.Repository.Content.GetAllContents(repoid, c.Name);
                        threadfiles.Wait();
                        var files = threadfiles.Result;
                        totalarea = files.Count;
                        foreach (var f in files)
                        {
                            SMZ3XMLFileInfo ni = new SMZ3XMLFileInfo()
                            {
                                Name = f.Name,
                                Path = f.Path,
                                Info = new FileInfo(f.Path),
                                FileType = SMZ3XMLFileType.World
                            };
                            Action addtolb = delegate { DelegateAddToLB(lbAreaDown, ni); };
                            lbAreaDown.Invoke(addtolb);
                            Action addprogress = delegate { UpdateProgressBar(totalarea, 1, 33); };
                            pbSync.Invoke(addprogress);
                        }
                    }
                    if (c.Name.Equals(kItemFolderName))
                    {
                        var threadfiles = gitClient.Repository.Content.GetAllContents(repoid, c.Name);
                        threadfiles.Wait();
                        var files = threadfiles.Result;
                        totalitem = files.Count;
                        foreach (var f in files)
                        {
                            SMZ3XMLFileInfo ni = new SMZ3XMLFileInfo()
                            {
                                Name = f.Name,
                                Path = f.Path,
                                Info = new FileInfo(f.Path),
                                FileType = SMZ3XMLFileType.Items
                            };
                            Action addtolb = delegate { DelegateAddToLB(lbItemsDown, ni); };
                            lbItemsDown.Invoke(addtolb);
                            Action addprogress = delegate { UpdateProgressBar(totalitem, 1, 33); };
                            pbSync.Invoke(addprogress);
                        }

                    }




                }

                setpb = delegate { SetProgessValue(100); };
                pbSync.Invoke(setpb);

                Action enablecntrls = delegate { EnableAllControls(true); };
                this.Invoke(enablecntrls);
        }
            
        

        private void EnableAllControls(bool enable)
        {
            lbAreaDown.Enabled = enable;
            lbItemsDown.Enabled = enable;
            btnDownload.Enabled = enable;
        }

        private void DelegateAddToLB(ListBox lb, SMZ3XMLFileInfo gi)
        {
            lb.Items.Add(gi);
        }

        private void UpdateProgressBar(int totalitems, int inc, int per)
        {
            int incperitem = (int)Math.Floor((decimal)per / (decimal)totalitems);
            pbSync.Value += inc * incperitem;

        }

        private void SetProgessValue(int p)
        {
            pbSync.Value = p;
           
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            List<SMZ3XMLFileInfo> downloadlist = new List<SMZ3XMLFileInfo>();
            NewFiles = new List<SMZ3XMLFileInfo>();

            foreach (SMZ3XMLFileInfo sel in lbAreaDown.SelectedItems)
            {
                downloadlist.Add(sel);
            }

            foreach (SMZ3XMLFileInfo sel in lbItemsDown.SelectedItems)
            {
                downloadlist.Add(sel);
            }

            foreach (SMZ3XMLFileInfo gfi in downloadlist)
            {
                var threadfile = gitClient.Repository.Content.GetAllContents(repoid, gfi.Path);
                threadfile.Wait();
                var file = threadfile.Result;
                gfi.Contents = file[0].Content;
                string path = Path.Combine(Environment.CurrentDirectory, gfi.Name);
                FileInfo fi = new FileInfo(path);
                if(fi.Exists)
                {
                    DialogResult res =  MessageBox.Show($"File {gfi.Name} Already Exists. Do You want to override the currently existing file?", "File Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(res == DialogResult.No)
                    {
                        continue;
                    }
                    fi.Delete();
                   
                        
                }



                using (FileStream stream = new FileStream(fi.FullName, System.IO.FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        sw.Write(gfi.Contents);
                    }
                }

                NewFiles.Add(gfi);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormGitXML_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void FormGitXML_Load(object sender, EventArgs e)
        {
            loadthread = new Thread(LoadFilesThread);
            loadthread.Start();
        }
    }
}
