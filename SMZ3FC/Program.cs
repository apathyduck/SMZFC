using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Globalization;

namespace SMZ3FC
{
    static class Program
    {




        private static ItemCountViewer mainForm;
        private static SMZ3FCManager aiManager;
        private static SMZ3FCSettings smz3Set;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           //Application.ThreadException += Application_ThreadException;

           // var ass = Assembly.GetCallingAssembly();
                       
            smz3Set = new SMZ3FCSettings();

            aiManager = new SMZ3FCManager(smz3Set);
            if(aiManager.IsErrored)
            {
                MessageBox.Show(aiManager.ErrorMessages, "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FCAutoUpdate.InitUpdater(smz3Set);
           

            Application.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new ItemCountViewer(aiManager, smz3Set);

            Application.Run(mainForm);
            
        }

        
    }
}
