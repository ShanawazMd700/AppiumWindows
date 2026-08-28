using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace WinAppBDD.Drivers
{
    public class WinAppDriverFactory
    {
        private const string WinAppDriverUrl = "http://127.0.0.1:4723";

        public WindowsDriver CreateDriver()
        {
            var options = new AppiumOptions();

            options.PlatformName = "Windows 11";
            options.AutomationName = "Windows";
            options.DeviceName = "WindowsPC";
            options.App = "Root";

            return new WindowsDriver(
                new Uri(WinAppDriverUrl),
                options);
        }
    }
}
