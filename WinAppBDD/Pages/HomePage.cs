using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using WinAppBDD.Utilities;

namespace WinAppBDD.Pages
{
    public class HomePage : ControlHelpers
    {
        private readonly By PatientDatabaseButton =
            MobileBy.AccessibilityId("fittingpath-button-patient-database");



        private readonly By addpatientbutton =
    MobileBy.XPath("//Button[contains(@Name,'Add Patient')]");

        private readonly By fittingoptionsbutton = MobileBy.Name("Fitting options");

        public void ClickPatientDatabase()
        {
            WaitHelper.WaitForElement(PatientDatabaseButton);
            Click(PatientDatabaseButton);
        }

        public void ClickAddPatient()
        {
            WaitHelper.WaitForElement(addpatientbutton);
            Click(addpatientbutton);
        }


    }
}
