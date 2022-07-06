using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;

namespace SMZ3FC
{
    static class Program
    {




        private static ItemCountViewer mainForm;
        private static AreaItemManager aiManager;
        private static SMZ3FCSettings smz3Set;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //LocationKeys.Initialize();
            //MajorKeys.Initialize();

            smz3Set = new SMZ3FCSettings();

         

            aiManager = new AreaItemManager(smz3Set);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new ItemCountViewer(aiManager, smz3Set);
          
            Application.Run(mainForm);
        }

       
    }
}
