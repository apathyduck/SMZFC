using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMZ3FC
{
    public partial class ReportViewer : Form
    {
        AreaItemManager manager;
        public ReportViewer(AreaItemManager ai)
        {
            InitializeComponent();
            manager = ai;
            PopulateText();
        }

        private void PopulateText()
        {
            AreaGroupings ag = manager.CurrentGroup;


           
            foreach(CollatedLocationData cld in ag.Locations)
            {
                rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                rtbReport.AppendText($"{cld.Name} - {cld.TotalCount}");

                rtbReport.AppendText(Environment.NewLine);
                rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                

                string currentheader = string.Empty;
                foreach(LocationInfo li in cld.ItemLines)
                {
                

                    if ((cbMajorsOnly.Checked && li.IsMajor) || !cbMajorsOnly.Checked)
                    {
                        if (!li.SpoilerLocationHeader.Equals(currentheader))
                        {
                            currentheader = li.SpoilerLocationHeader;
                            rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
                            rtbReport.AppendText(currentheader);
                            rtbReport.AppendText(Environment.NewLine);
                        }

                        rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                        rtbReport.AppendText("     ");
                        rtbReport.AppendText(li.SpoilerLine);
                        rtbReport.AppendText(Environment.NewLine);
                    }
                  
                }
                foreach (ShiftedSubLocation ssl in ag.ShiftedLocations)
                {
                    if (ssl.ShiftToGroup.Equals(cld.Name))
                    {
                        if ((cbMajorsOnly.Checked && ssl.LocInfo.IsMajor) || !cbMajorsOnly.Checked)
                        {
                            if (!ssl.LocInfo.SpoilerLocationHeader.Equals(currentheader))
                            {
                                currentheader = ssl.LocInfo.SpoilerLocationHeader;
                                rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
                                rtbReport.AppendText(currentheader);
                                rtbReport.AppendText(Environment.NewLine);
                            }

                            rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                            rtbReport.AppendText("     ");
                            rtbReport.AppendText(ssl.LocInfo.SpoilerLine);
                            rtbReport.AppendText(Environment.NewLine);
                        }
                    }
                }


            }

            rtbReport.SelectionStart = 0;
            rtbReport.ScrollToCaret();
        }

        private void cbMajorsOnly_CheckedChanged(object sender, EventArgs e)
        {
            rtbReport.Text = string.Empty;
            PopulateText();
        }
    }
}
