using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppBDD.Utilities;

namespace WinAppBDD.Pages
{
    public class FSWOperations : ControlHelpers
    {
        private readonly By physicalConnect =
            MobileBy.AccessibilityId("fittingpath_button_connect");

        private readonly By simulatebutton =
            MobileBy.AccessibilityId("fittingpath_link_simulate");

        private readonly By simulatebutton2 = MobileBy.Name("Simulate");
        private readonly By continuebutton = MobileBy.Name("Continue");
        // Product
        private By GetResoundItem(string productName) =>
            MobileBy.XPath(
                $"//Window[@Name='ReSound Smart Fit 2.5']" +
                $"//Text[contains(@Name, 'ReSound {productName}')]"
            );
        private By SideMenuItems(string itemName) =>
            MobileBy.XPath($"//Button[contains(@Name, '{itemName}')]");

        // Device + Direction
        private By SelectDirectionOfProduct(
            string productName,
            string deviceName,
            string direction)
        {
            return MobileBy.XPath(
                $"//Window[@Name='ReSound Smart Fit 2.5']" +
                $"//Text[contains(@Name, '{deviceName}')]" +
                $"[preceding-sibling::Text[starts-with(@Name, 'ReSound ')][1]" +
                $"[contains(@Name, 'ReSound {productName}')]]" +
                $"/following-sibling::RadioButton" +
                $"[contains(translate(@Name, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{direction.ToLower()}')][1]"
            );
        }


        public void ClickPhysicalConnect()
        {
            WaitHelper.WaitForElement(physicalConnect);
            Click(physicalConnect);
        }


        public void ClickSimulate()
        {
            WaitHelper.WaitForElement(simulatebutton);
            Click(simulatebutton);
        }


        public void SelectResoundItem(string productName)
        {
            var resoundItem = GetResoundItem(productName);

            WaitHelper.WaitForElement(resoundItem);

            Click(resoundItem);
        }


        public void selectproductwithdirection(
            string productName,
            string deviceName,
            string direction)
        {
            var directionRadioButton =
                SelectDirectionOfProduct(
                    productName,
                    deviceName,
                    direction);

            WaitHelper.WaitForElement(directionRadioButton);

            Click(directionRadioButton);
        }

        public void clicksimulate()
        {
            Click(simulatebutton2);
        }

        public void clickcontinue()
        {
            Click(continuebutton);
        }

        public void ClickSideMenuItem(string itemName)
        {
            var sideMenuItem = SideMenuItems(itemName);
            WaitHelper.WaitForElement(sideMenuItem);
            Click(sideMenuItem);
        }
        
    }
}