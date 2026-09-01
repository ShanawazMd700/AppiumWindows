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


        // ============================================================
        // Reports
        // ============================================================

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


        // ============================================================
        // Extent
        // ============================================================

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


        // ============================================================
        // Allure
        // ============================================================

        // IMPORTANT:
        // Allure.Reqnroll writes the raw result files here.
        //
        // Example:
        // bin\Release\net9.0\allure-results
        //
        public static string AllureResultsDirectory
        {
            get
            {
                return Path.Combine(
                    AppContext.BaseDirectory,
                    "allure-results");
            }
        }


        // Final generated Allure HTML report.
        //
        // Example:
        // Reports\2026-09-01_11-10-09\Allure
        //
        public static string AllureDirectory
        {
            get
            {
                return Path.Combine(
                    ReportsDirectory,
                    "Allure");
            }
        }


        // ============================================================
        // Initialize
        // ============================================================

        public static void Initialize()
        {
            Directory.CreateDirectory(ReportsDirectory);

            Directory.CreateDirectory(ExtentDirectory);

            Directory.CreateDirectory(AllureDirectory);

            Directory.CreateDirectory(AllureResultsDirectory);
        }
    }
}

