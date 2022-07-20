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
        
        WorldState state;
        public ReportViewer(WorldState ws)
        {
            InitializeComponent();

            state = ws;
            PopulateText();
        }

        private void PopulateText()
        {          
            foreach(ActiveArea area in state.Areas.Values)
            {
                rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                rtbReport.AppendText($"{area.Name} - {area.TotalItems}");

                rtbReport.AppendText(Environment.NewLine);
                rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                

                string currentheader = string.Empty;

                List<string> spoilerareas = (from loc in area.CurrentLocations select loc.Value.LogLocation.AreaName).Distinct().ToList();

                foreach (string spoilerarea in spoilerareas)
                {



                    List<ActiveLocation> locs = (from slocs in area.CurrentLocations where slocs.Value.LogLocation.AreaName.Equals(spoilerarea) select slocs.Value).ToList();
                    bool writeheader = false;
                    foreach (ActiveLocation actloc in locs)
                    {
                        if (cbMajorsOnly.Checked && actloc.IsMajor || !cbMajorsOnly.Checked)
                        {
                            if (!writeheader)
                            {

                                rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
                                rtbReport.AppendText(spoilerarea);
                                rtbReport.AppendText(Environment.NewLine);
                                writeheader = true;
                            }

                            rtbReport.SelectionFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                            rtbReport.AppendText("     ");
                            rtbReport.AppendText($"{actloc.Info.Name}: {actloc.LogLocation.FullLine}");
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
