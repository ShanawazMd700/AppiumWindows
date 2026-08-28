using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppBDD.AppsManager
{
    internal class KillOpenApplications
    {
        public static void KillApplications()
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
                }
                catch
                {
                    // Add other handling logic if needed, such as logging the error or retrying.
                }
            }
        }
    }
}
