using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using WinAppBDD.AppsLaunch;
using WinAppBDD.Pages;

namespace WinAppBDD.StepDefinitions
{
    [Binding]
    public class Stepdefinitions1
    {
        private readonly NOAHActions noahActions;
        private readonly FSWOperations fswOperations;
        private readonly PhysicalProperties physicalProperties;
        private readonly FineTuningPage fineTuningPage;
        public Stepdefinitions1() 
        {
            noahActions = new NOAHActions();
            fswOperations = new FSWOperations();
            physicalProperties = new PhysicalProperties();
            fineTuningPage = new FineTuningPage();
        }

        [When("I click on the Audiogram tab")]
        public void WhenIClickOnTheAudiogramTab()
        {
            noahActions.openandDrawAudiogram();
            //noahActions.CaptureAppiumXml();
        }


        [When("I add new patient")]
        public void WhenIAddNewPatient()
        {
            noahActions.AddPatient();
        }

        [When("I launch FSW {string}")]
        public void WhenILaunchFSW(string brand)
        {
            noahActions.launchFSW(brand);
        }
        [When("I launch in Simulation")]
        public void WhenILaunchInSimulation()
        {
            fswOperations.ClickSimulate();
        }

        [When("I select the device {string}")]
        public void WhenISelectTheDevice(string productname)
        {
            fswOperations.SelectResoundItem(productname);
        }
        [When("I select the device {string} and devicename {string} with side {string}")]
        public void WhenISelectTheDeviceAndDevicenameWithSide(string productname, string p1, string left)
        {
            fswOperations.SelectResoundItem(productname);
            fswOperations.selectproductwithdirection(productname,p1, left);
            fswOperations.clicksimulate();
        }
        [When("I click {string} in Physical Properties window")]
        public void WhenIClickInPhysicalPropertiesWindow(string @continue)
        {
            physicalProperties.clickcontinue();
        }

        [When("I click {string} in side menu")]
        public void WhenIClickInSideMenu(string p0)
        {
            fswOperations.ClickSideMenuItem(p0);
        }

        [When("I add Programs {string} from programs")]
        public void WhenIAddProgramsFromPrograms(string program)
        {
            fineTuningPage.ChangePrograms(program);
        }

        [Then("I exit from FSW")]
        public void ThenIExitFromFSW()
        {
            fineTuningPage.clickSave();
            fineTuningPage.exitFSW();  
        }

    }
}
