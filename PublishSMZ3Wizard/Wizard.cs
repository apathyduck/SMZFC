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
using Octokit;

namespace PublishSMZ3Wizard
{
    public partial class Wizard : Form
    {
        private int repoid = 510945946;



        public Wizard()
        {
            InitializeComponent();

            GetRepoTags();
        }

        private async void GetRepoTags()
        {
            var httpClinet = new HttpClient();
            var gitClient = new GitHubClient(new ProductHeaderValue("SMZ3-Full-Countdown"));
            //var threadrepo = await gitClient.Repository.Content.GetAllContents(repoid);
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
            }
               

            

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
