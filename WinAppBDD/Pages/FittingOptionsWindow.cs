using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppBDD.Utilities;

namespace WinAppBDD.Pages
{
    public class FittingOptionsWindow : ControlHelpers
    {
        private readonly By OKButton = MobileBy.Name("Fitting options");
        private readonly By targetrule  = MobileBy.Name("NAL - NL3");
        private readonly By fittingoptions = MobileBy.AccessibilityId("fittingoptionsdialog-button-targetrule");
        private readonly By cancelbutton = MobileBy.Name("Cancel");
        private readonly By closebutton = MobileBy.AccessibilityId("wpfdialogcontent-button-close");
        private readonly By savechangesbutton = MobileBy.Name("Save Changes");

        public void ClickOKButton()
        {
            Click(OKButton);
        }

        public void clickTargetruleButton() 
        { 
            Click(targetrule); 
        }

        public void clickFittingOptionsButton()
        {
            Click(fittingoptions);
        }

        public void clickCancelButton()
        {
            Click(cancelbutton);
        }
        public void clickCloseButton() {
            Click(closebutton);
        }

        public void clickSaveChangesbutton()
        {
            Click(savechangesbutton);
        }
    }
}
