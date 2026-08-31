using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppBDD.Utilities
{
    public static class ReportRunManager
    {
        private static string? _runTimestamp;

        public static string RunTimestamp
        {
            get
            {
                if (_runTimestamp == null)
                {
                    _runTimestamp =
                        DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                }

                return _runTimestamp;
            }
        }

        // Reports will be created under the test execution directory
        // Example:
        // bin\Debug\net9.0\Reports\2026-08-31_17-30-15
        public static string ReportsDirectory
        {
            get
            {
                return Path.Combine(
                    AppContext.BaseDirectory,
                    "Reports",
                    RunTimestamp);
            }
        }

        public static string ExtentDirectory
        {
            get
            {
                return Path.Combine(
                    ReportsDirectory,
                    "Extent");
            }
        }

        public static string ExtentReportPath
        {
            get
            {
                return Path.Combine(
                    ExtentDirectory,
                    "ExtentReport.html");
            }
        }

        public static string AllureDirectory
        {
            get
            {
                return Path.Combine(
                    ReportsDirectory,
                    "Allure");
            }
        }

        public static void Initialize()
        {
            Directory.CreateDirectory(ReportsDirectory);
            Directory.CreateDirectory(ExtentDirectory);
            Directory.CreateDirectory(AllureDirectory);
        }
    }
}