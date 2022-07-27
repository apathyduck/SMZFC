using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

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

           var ass = Assembly.GetCallingAssembly();
            
           
            smz3Set = new SMZ3FCSettings();

         

            aiManager = new SMZ3FCManager(smz3Set);
            FCAutoUpdate.InitUpdater(smz3Set);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new ItemCountViewer(aiManager, smz3Set);
          
            Application.Run(mainForm);
        }

       
    }
}
