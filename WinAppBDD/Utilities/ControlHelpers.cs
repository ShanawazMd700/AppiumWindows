using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using WinAppBDD.Drivers;

namespace WinAppBDD.Utilities
{
    public class ControlHelpers
    {
        protected WindowsDriver Driver =>
            DriverManager.Driver ?? throw new InvalidOperationException("Windows application session has not been started.");

        protected void Click(By locator)
        {
            WaitHelper.WaitForElement(locator);
            Driver.FindElement(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            WaitHelper.WaitForElement(locator);
            Driver.FindElement(locator).SendKeys(text);
        }

        protected string GetText(By locator)
        {
            WaitHelper.WaitForElement(locator);
            return Driver.FindElement(locator).Text;
        }

        protected bool IsDisplayed(By locator)
        {
            WaitHelper.WaitForElement(locator);
            return Driver.FindElement(locator).Displayed;
        }
    }
}