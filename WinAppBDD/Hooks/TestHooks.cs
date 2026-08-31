using Reqnroll;
using WinAppBDD.AppsManager;
using WinAppBDD.Drivers;
using WinAppBDD.Utilities;

namespace WinAppBDD.Hooks
{
    [Binding]
    public sealed class TestHooks
    {

        [BeforeScenario(Order = 0)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            // Create Extent test for the scenario
            ExtentScenarioManager.CurrentTest =
                ExtentReportManager.Extent.CreateTest(
                    scenarioContext.ScenarioInfo.Title);

            ExtentScenarioManager.LogInfo(
                $"Scenario started: {scenarioContext.ScenarioInfo.Title}");

            ExtentScenarioManager.LogInfo(
                $"Start Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            // Start Appium session
            //KillOpenApplications.KillApplications();
            //KillOpenApplications.KillApplications();
            SessionManager.StartSession();
            ExtentScenarioManager.LogPass(
               "Application session started successfully.");
        }
        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            var step = scenarioContext.StepContext.StepInfo;

            ExtentScenarioManager.LogInfo(
                $"Executing: {step.StepDefinitionType} {step.Text}");
        }


        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var step = scenarioContext.StepContext.StepInfo;

            if (scenarioContext.TestError != null)
            {
                // Step failed
                ExtentScenarioManager.LogFail(
                    $"FAILED: {step.StepDefinitionType} {step.Text}");

                ExtentScenarioManager.LogFail(
                    $"Error: {scenarioContext.TestError.Message}");
            }
            else
            {
                // Step passed
                ExtentScenarioManager.LogPass(
                    $"PASSED: {step.StepDefinitionType} {step.Text}");
            }
        }
        [AfterScenario(Order = 100)]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext.TestError != null)
                {
                    ExtentScenarioManager.LogFail(
                        $"Scenario FAILED: {scenarioContext.TestError.Message}");

                    ExtentScenarioManager.LogFail(
                        $"Failure Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                }
                else
                {
                    ExtentScenarioManager.LogPass(
                        "Scenario PASSED.");

                    ExtentScenarioManager.LogInfo(
                        $"End Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                }
            }
            finally
            {
                SessionManager.StopSession();

                // DO NOT FLUSH HERE

                ExtentScenarioManager.CurrentTest = null;
            }
        }

    }
}
