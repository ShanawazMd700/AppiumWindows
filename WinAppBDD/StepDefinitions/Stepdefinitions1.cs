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
        public Stepdefinitions1() 
        {
            noahActions = new NOAHActions();
            fswOperations = new FSWOperations();
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



    }
}
