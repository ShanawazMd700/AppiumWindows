using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using WinAppBDD.Utilities;

namespace WinAppBDD.Pages
{
    public class BurnWireless : ControlHelpers
    {
        private readonly By textbox = MobileBy.AccessibilityId("textBoxFilter");
        private readonly Func<string, By> parentProduct =
            productName => MobileBy.XPath(
                $"//TreeItem[.//TreeItem[contains(@Name,'{productName}') and contains(@Name,'Final')]]");

        private readonly Func<string, By> finalProduct =
            productName => MobileBy.XPath(
                $"//TreeItem[contains(@Name,'{productName}') and contains(@Name,'Final')]");


        public void Enterproductname(string productName)
        {
            EnterText(textbox, productName);
            Click(parentProduct(productName));   // Clicks ReSound Vivia 9 / Nexia 9 dynamically
            Click(finalProduct(productName));    // Clicks VI962-DRW [10] (Final)
        }

    }
}
