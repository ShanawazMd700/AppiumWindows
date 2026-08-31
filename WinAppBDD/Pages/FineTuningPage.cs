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
    public class FineTuningPage : ControlHelpers
    {
        private readonly By addprograms = MobileBy.AccessibilityId("ProgramStripAutomationIds.AddProgramAction"); //AutomationId ProgramStripAutomationIds.AddProgramAction
        private By programOptions(string itemName) => MobileBy.Name(itemName);

        private readonly By leftAllButton =
    MobileBy.XPath("(//dataitem[contains(@Name, 'ReSound.Fuse2.GainAdjustment.ViewModels.Support.GainCellViewModel')])[1]");

        private readonly By rightAllButton =
            MobileBy.XPath("(//dataitem[contains(@Name, 'ReSound.Fuse2.GainAdjustment.ViewModels.Support.GainCellViewModel')])[2]");
        private readonly By increasegain3 = MobileBy.AccessibilityId("FittingAutomationIds.GainAutomationIds.AdjustmentItemsAutomationIds.3");
        private readonly By increasegain2 = MobileBy.AccessibilityId("FittingAutomationIds.GainAutomationIds.AdjustmentItemsAutomationIds.2");
        private readonly By increasegain1 = MobileBy.AccessibilityId("FittingAutomationIds.GainAutomationIds.AdjustmentItemsAutomationIds.1");
        private readonly By arrowup = MobileBy.AccessibilityId("FittingAutomationIds.GainAutomationIds.AdjustmentItemsAutomationIds.Increase"); // AutomationId	FittingAutomationIds.GainAutomationIds.AdjustmentItemsAutomationIds.Increase
        private readonly By arrowdown = MobileBy.AccessibilityId("FittingAutomationIds.GainAutomationIds.AdjustmentItemsAutomationIds.Decrease"); // AutomationId	FittingAutomationIds.GainAutomationIds.AdjustmentItemsAutomationIds.Decrease
        private readonly By saveButton = MobileBy.AccessibilityId("FittingAutomationIds.SaveAction"); // AutomationId	FittingAutomationIds.SaveAction
        private readonly By exitFSWbutton = MobileBy.Name("Exit ReSound Smart Fit"); // Name	Exit ReSound Smart Fit





        public void ChangePrograms(string programName)
        {
            Click(addprograms);
            //WaitHelper.WaitForElement(programOptions(programName));
            Click(programOptions(programName));
        }

        public void increasegains()
        {
            Click(leftAllButton);
            Click(increasegain3);
            for(int i = 0; i < 3; i++)
            {
                Click(arrowup);
            }
        }

        public void clickSave()
            { Click(saveButton); }

        public void exitFSW()
        {
            Click(exitFSWbutton);
        }
    }
}
