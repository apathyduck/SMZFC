using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public static class FCAutoUpdate
    {
        public static string ServerVersion { get; private set; }
        public static bool UpdateAvailable { get; private set; }


        private static SMZ3FCSettings settings;
        private static UpdateInfoEventArgs cachedArgs;
        private static EventWaitHandle checkUpdateWait;

        public static void InitUpdater(SMZ3FCSettings set)
        {
            settings = set;
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.Mandatory = true;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.UpdateMode = Mode.Normal;
            AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
        
        }



        private static void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            cachedArgs = args;
            ServerVersion = args.CurrentVersion;           
            UpdateAvailable = args.IsUpdateAvailable;
            checkUpdateWait.Set();
          
        }

        public static bool CheckForUpdates()
        {
            checkUpdateWait = new EventWaitHandle(false, EventResetMode.AutoReset);
            Thread updatethread = new Thread(UpdateThread);
            updatethread.Start();
            checkUpdateWait.WaitOne();
            return UpdateAvailable;
        }

        public static void ShowUpdateForm()
        {
            if(cachedArgs == null)
            {
                return;
            }
            AutoUpdater.ShowUpdateForm(cachedArgs);
        }

        private static void UpdateThread()
        {
            AutoUpdater.Start(settings.UpdaterUrl);
        }


    }
}
