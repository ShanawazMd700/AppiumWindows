using Reqnroll;
using WinAppBDD.AppsLaunch;
using WinAppBDD.Pages;

namespace WinAppBDD.StepDefinitions
{
    [Binding]
    public class DemoSteps
    {
        private readonly HomePage _homePage;
        private readonly AppLaunch appLaunch;
        private readonly NOAHActions noahActions;
        private readonly FittingOptionsWindow fittingoptions;
        private readonly BurnHI burnhi;
        public DemoSteps() 
        {
            _homePage = new HomePage();
            appLaunch = new AppLaunch();
            noahActions = new NOAHActions();
            fittingoptions = new FittingOptionsWindow();
            burnhi = new BurnHI();
        }


        [When("Add or Select Patients is clicked")]
        public void WhenAddOrSelectPatientsIsClicked()
        {
            _homePage.ClickPatientDatabase();
        }

        //[Given("Launch FDTS in system")]
        //public void GivenLaunchFDTSInSystem()
        //{
        //    throw new PendingStepException();
        //}

        [Given("Launching {string} in the system")]
        public void GivenLaunchingInTheSystem(string app)
        {
            appLaunch.LaunchApps(app);
        }

        [When("The login password to NOAH {string} is entered")]
        public void WhenTheLoginPasswordToNOAHIsEntered(string p0)
        {
            noahActions.EnterPassword(p0);
        }

        [When("I click OK button in NOAH")]
        public void WhenIClickOKButtonInNOAH()
        {
            noahActions.ClickOKButton();
        }

        [Given("Click the fitting options on the fine tuning window")]
        public void GivenClickTheFittingOptionsOnTheFineTuningWindow()
        {
            fittingoptions.ClickOKButton();
        }

        [When("I select a new target rule")]
        public void WhenISelectANewTargetRule()
        {
            
            fittingoptions.clickFittingOptionsButton();
            fittingoptions.clickTargetruleButton();
        }
        [When("I click close button in fitting options window")]
        public void WhenIClickCloseButtonInFittingOptionsWindow()
        {
            //fittingoptions.clickCloseButton();
            fittingoptions.clickSaveChangesbutton();
        }
        [When("The product {string} is selected")]
        public void WhenTheProductIsSelected(string p0)
        {
            
        }


    }
}
