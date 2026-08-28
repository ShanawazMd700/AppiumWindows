using Reqnroll;
using WinAppBDD.Drivers;
using WinAppBDD.AppsManager;

namespace WinAppBDD.Hooks
{
    [Binding]
    public sealed class TestHooks
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            //KillOpenApplications.KillApplications();
            SessionManager.StartSession();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            SessionManager.StopSession();
        }

    }
}
