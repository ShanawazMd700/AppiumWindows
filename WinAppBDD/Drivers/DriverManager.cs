using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinAppBDD.Drivers
{
    public static class DriverManager
    {
        private static readonly AsyncLocal<WindowsDriver?> _driver
     = new();

        public static WindowsDriver? Driver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }
    }
}
