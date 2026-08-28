using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppBDD.Utilities;

namespace WinAppBDD.AppsManager
{
    public class AppWaitLaunch
    {
        private readonly By PatientDatabaseButton =
           MobileBy.AccessibilityId("fittingpath-button-patient-database");
        private readonly By OKButton = MobileBy.AccessibilityId("cmdOK");
        private readonly By fdtscontinue = MobileBy.AccessibilityId("buttonContinue");
        public void WaitForAppToLaunch(string app)
        {
            switch (app.Trim().ToLowerInvariant())
            {
                case "smartfit":
                    //Thread.Sleep(TimeSpan.FromSeconds(20));
                    WaitHelper.WaitForElement(PatientDatabaseButton);
                    break;

                case "solusmax":
                    throw new NotImplementedException(
                        "Solus Max launch path is not configured.");

                case "noah":
                    //Thread.Sleep(TimeSpan.FromSeconds(10));
                    WaitHelper.WaitForElement(OKButton);
                    break;

                case "fdts":
                case "camelot":
                    Thread.Sleep(TimeSpan.FromSeconds(20));
                    WaitHelper.WaitForElement(fdtscontinue);
                    break;

                default:
                    throw new ArgumentException(
                        $"Unsupported application: {app}",
                        nameof(app));
            }
        }
    }
}
