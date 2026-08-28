using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppBDD.Drivers;
using static System.Net.Mime.MediaTypeNames;

namespace WinAppBDD.AppsLaunch
{
    public class AppLaunch
    {
        public void LaunchApps(string app)
        {
            switch (app.Trim().ToLowerInvariant())
            {
                case "smartfit":
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = @"C:\Program Files (x86)\ReSound\SmartFit\SmartFit.exe",
                        UseShellExecute = true
                    });

                    Thread.Sleep(TimeSpan.FromSeconds(20));
                    break;

                case "solusmax":
                    throw new NotImplementedException(
                        "Solus Max launch path is not configured.");

                case "noah":
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = @"C:\Program Files (x86)\HIMSA\Noah 4\Noah4.exe",
                        UseShellExecute = true
                    });

                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    break;

                case "fdts":
                case "camelot":
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = @"C:\Program Files (x86)\GN Hearing\Camelot\WorkflowRuntime\Camelot.WorkflowRuntime.exe",
                        UseShellExecute = true
                    });

                    Thread.Sleep(TimeSpan.FromSeconds(20));
                    break;

                default:
                    throw new ArgumentException(
                        $"Unsupported application: {app}",
                        nameof(app));
            }
        }
    }
}
