using Reqnroll;
using WinAppBDD.Utilities;

namespace WinAppBDD.Hooks
{
    [Binding]
    public sealed class ReportHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ReportRunManager.Initialize();

            // Initialize Extent report
            _ = ExtentReportManager.Extent;

            Console.WriteLine(
                $"Report directory: {ReportRunManager.ReportsDirectory}");

            Console.WriteLine(
                $"Extent report: {ReportRunManager.ExtentReportPath}");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine(
                "Test run completed. Flushing Extent report...");

            ExtentReportManager.Flush();

            Console.WriteLine(
                $"Extent report generated at:");

            Console.WriteLine(
                ReportRunManager.ExtentReportPath);
        }
    }
}