using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Octokit;

namespace PublishSMZ3Wizard
{
    public partial class Wizard : Form
    {
        private int repoid = 510945946;
        XmlConfig myConfig;


        public Wizard()
        {
            InitializeComponent();

            GetRepoTags();
        }

        private async void GetRepoTags()
        {
            var httpClinet = new HttpClient();
            var gitClient = new GitHubClient(new ProductHeaderValue("SMZ3-Full-Countdown"));
            //var repo = await gitClient.Repository.Content.GetAllContents(repoid);

            //var smz3fold = (from dir in repo where dir.Name.Equals("SMZ3FC") select dir).First();

            var repo = await gitClient.Repository.Content.GetAllContents(repoid, @"SMZ3FC/UpdateConfig.xml");
            var releases = await gitClient.Repository.Release.GetAll(repoid);
            var latest = releases[0];

            foreach (var assest in latest.Assets)
            {
                ListBoxAssest lba = new ListBoxAssest()
                {
                    Assest = assest,
                    Name = assest.Name
                    
                };
                lbAssests.Items.Add(lba);

                myConfig = new XmlConfig();
                myConfig.Contents = repo[0].Content;
                myConfig.ParseContents();

                tbSerVersion.Text = myConfig.Version;
                tbMajor.Text = myConfig.Major.ToString();
                tbMInor.Text = myConfig.Minor.ToString();
                tbPatch.Text = myConfig.Patch.ToString();
                tbBuild.Text = myConfig.Build.ToString();

            }



    }


    struct ListBoxAssest
    {
        public ReleaseAsset Assest;
        public string Name;
        public override string ToString()
        {
            return Name;
        }
    }
}
