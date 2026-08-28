using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WinAppBDD.Drivers;

namespace WinAppBDD.Utilities
{
    public static class WaitHelper
    {
        public static void WaitForElement(
            By locator,
            int timeout = 80)
        {
            var wait = new WebDriverWait(
                DriverManager.Driver ?? throw new InvalidOperationException("Windows application session has not been started."),
                TimeSpan.FromSeconds(timeout));

            wait.Until(
                drv => drv.FindElement(locator).Displayed);
        }
    }
}
