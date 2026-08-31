using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppBDD.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace WinAppBDD.Pages
{
    public class PhysicalProperties : ControlHelpers
    {
        private readonly By continuebutton = MobileBy.Name("Continue");
        public void clickcontinue()
        {
            WaitHelper.WaitForElementEnabled(continuebutton);
            Click(continuebutton);
        }

    }
}
