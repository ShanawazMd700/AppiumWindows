using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace WinAppBDD.Utilities
{
    public static class ExtentReportManager
    {
        private static ExtentReports? _extent;

        public static ExtentReports Extent
        {
            get
            {
                if (_extent == null)
                {
                    InitializeReport();
                }

                return _extent;
            }
        }

        private static void InitializeReport()
        {
            ReportRunManager.Initialize();

            string reportPath =
                ReportRunManager.ExtentReportPath;

            var sparkReporter =
                new ExtentSparkReporter(reportPath);

            sparkReporter.Config.DocumentTitle =
                "WinAppBDD Automation Report";

            sparkReporter.Config.ReportName =
                "WinAppBDD Test Execution";

            _extent = new ExtentReports();

            _extent.AttachReporter(sparkReporter);

            _extent.AddSystemInfo(
                "Machine",
                Environment.MachineName);

            _extent.AddSystemInfo(
                "OS",
                Environment.OSVersion.ToString());

            _extent.AddSystemInfo(
                ".NET Version",
                Environment.Version.ToString());

            _extent.AddSystemInfo(
                "Run Timestamp",
                ReportRunManager.RunTimestamp);
        }

        public static void Flush()
        {
            _extent?.Flush();
        }
    }
}