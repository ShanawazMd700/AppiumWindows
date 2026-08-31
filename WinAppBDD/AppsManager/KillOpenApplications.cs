using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WinAppBDD.AppsManager
{
    public class KillOpenApplications
    {
        public static void KillAllApplications()
        {
            string[] processNames =
            {
                "ReSound Smart Fit",
                "Socket_Box1",
                "Medusa",
                "AlgoLabtest.Dooku",
                "SmartFitSA",
                "SolusMax",
                "Sentinel",
                "Athena",
                "Camelot.TestRuntimePC",
                "Camelot.SystemInfobar",
                "Camelot.WorkflowRuntime",
                "IntertonFitting",
                "BAXFitting",
                "HearingAU",
                "SmartFit",
                "Noah4"
            };

            foreach (var processName in processNames)
            {
                KillProcess(processName);
            }
        }

        private static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                    Thread.Sleep(4000);
                }
                catch
                {
                    // Add logging if required
                }
            }
            //add Delay
        }
    }
}
