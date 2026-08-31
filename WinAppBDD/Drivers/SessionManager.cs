using System;
using System.Collections.Generic;
using System.Text;
using WinAppBDD.AppsManager;

namespace WinAppBDD.Drivers
{
    public static class SessionManager
    {
        public static void StartSession()
        {
            DriverManager.Driver =
                new WinAppDriverFactory().CreateDriver();
        }

        public static void StopSession()
        {
            DriverManager.Driver?.Quit();
            DriverManager.Driver = null;
        }

        public static void KillExistingApps()
        {
            KillOpenApplications.KillAllApplications();
        }
    }
}
