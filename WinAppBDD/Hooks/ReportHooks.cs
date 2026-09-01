using System.Diagnostics;
using Reqnroll;
using WinAppBDD.Utilities;

namespace WinAppBDD.Hooks
{
    [Binding]
    public sealed class ReportHooks
    {
        private static readonly string AllureCommand =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "npm",
                "allure.cmd");


        // ============================================================
        // BEFORE TEST RUN
        // ============================================================

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Create timestamped report directories
            ReportRunManager.Initialize();

            // Make sure Allure results directory exists
            Directory.CreateDirectory(
                ReportRunManager.AllureResultsDirectory);

            // IMPORTANT:
            // Do NOT delete the allure-results directory itself.
            // Allure.Reqnroll uses this directory.

            _ = ExtentReportManager.Extent;

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("TEST RUN STARTED");
            Console.WriteLine("========================================");

            Console.WriteLine();
            Console.WriteLine("Report directory:");

            Console.WriteLine(
                ReportRunManager.ReportsDirectory);

            Console.WriteLine();
            Console.WriteLine("Allure results directory:");

            Console.WriteLine(
                ReportRunManager.AllureResultsDirectory);

            Console.WriteLine();
            Console.WriteLine("Allure command:");

            Console.WriteLine(AllureCommand);

            Console.WriteLine();
        }


        // ============================================================
        // AFTER TEST RUN
        // ============================================================

        [AfterTestRun]
        public static void AfterTestRun()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("TEST RUN COMPLETED");
                Console.WriteLine("========================================");


                // ====================================================
                // 1. Generate Extent
                // ====================================================

                Console.WriteLine();
                Console.WriteLine("Generating Extent report...");

                ExtentReportManager.Flush();

                Console.WriteLine();
                Console.WriteLine("Extent report:");

                Console.WriteLine(
                    ReportRunManager.ExtentReportPath);


                // ====================================================
                // 2. Generate Allure
                // ====================================================

                bool allureGenerated =
                    GenerateAllureReport();


                // ====================================================
                // 3. Open Extent
                // ====================================================

                OpenExtentReport();


                // ====================================================
                // 4. Open Allure
                // ====================================================

                if (allureGenerated)
                {
                    Thread.Sleep(4000);
                    OpenAllureReport();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "Allure report was not opened because " +
                        "generation failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "REPORT ERROR:");

                Console.WriteLine(ex);
            }
        }


        // ============================================================
        // GENERATE ALLURE REPORT
        // ============================================================

        private static bool GenerateAllureReport()
        {
            string allureResults =
                ReportRunManager.AllureResultsDirectory;

            string allureReport =
                ReportRunManager.AllureDirectory;


            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("GENERATING ALLURE REPORT");
            Console.WriteLine("========================================");

            Console.WriteLine();
            Console.WriteLine("Results:");

            Console.WriteLine(allureResults);

            Console.WriteLine();
            Console.WriteLine("Output:");

            Console.WriteLine(allureReport);


            // ========================================================
            // Check results directory
            // ========================================================

            if (!Directory.Exists(allureResults))
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR: Allure results directory does not exist.");

                return false;
            }


            // ========================================================
            // Check result files
            // ========================================================

            string[] resultFiles =
                Directory.GetFiles(
                    allureResults,
                    "*",
                    SearchOption.TopDirectoryOnly);


            Console.WriteLine();
            Console.WriteLine(
                $"Allure result files found: {resultFiles.Length}");


            if (resultFiles.Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR: No Allure result files were found.");

                return false;
            }


            // ========================================================
            // Check Allure CLI
            // ========================================================

            if (!File.Exists(AllureCommand))
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR: Allure CLI was not found:");

                Console.WriteLine(AllureCommand);

                return false;
            }


            // ========================================================
            // Create output directory
            // ========================================================

            Directory.CreateDirectory(allureReport);


            // ========================================================
            // Generate report
            // ========================================================

            ProcessStartInfo processInfo =
                new ProcessStartInfo
                {
                    FileName = AllureCommand,

                    Arguments =
                        $"generate " +
                        $"\"{allureResults}\" " +
                        $"-o " +
                        $"\"{allureReport}\" " +
                        $"--clean",

                    WorkingDirectory =
                        AppContext.BaseDirectory,

                    UseShellExecute = false,

                    RedirectStandardOutput = true,

                    RedirectStandardError = true,

                    CreateNoWindow = true
                };


            Console.WriteLine();
            Console.WriteLine(
                "Executing Allure CLI...");


            using Process? process =
                Process.Start(processInfo);


            if (process == null)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR: Could not start Allure CLI.");

                return false;
            }


            string output =
                process.StandardOutput.ReadToEnd();

            string error =
                process.StandardError.ReadToEnd();


            process.WaitForExit();


            Console.WriteLine();
            Console.WriteLine("Allure output:");

            Console.WriteLine(output);


            if (!string.IsNullOrWhiteSpace(error))
            {
                Console.WriteLine();
                Console.WriteLine("Allure error:");

                Console.WriteLine(error);
            }


            // ========================================================
            // Check exit code
            // ========================================================

            if (process.ExitCode != 0)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"ERROR: Allure exited with code " +
                    $"{process.ExitCode}");

                return false;
            }


            // ========================================================
            // Check generated index.html
            // ========================================================

            string indexPath =
                Path.Combine(
                    allureReport,
                    "index.html");


            if (!File.Exists(indexPath))
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR: Allure command completed but " +
                    "index.html was not created.");

                return false;
            }


            Console.WriteLine();
            Console.WriteLine(
                "========================================");

            Console.WriteLine(
                "ALLURE REPORT GENERATED SUCCESSFULLY");

            Console.WriteLine(
                "========================================");

            Console.WriteLine();

            Console.WriteLine(indexPath);

            return true;
        }


        // ============================================================
        // OPEN EXTENT
        // ============================================================

        private static void OpenExtentReport()
        {
            string reportPath =
                ReportRunManager.ExtentReportPath;


            if (!File.Exists(reportPath))
            {
                Console.WriteLine();
                Console.WriteLine(
                    "ERROR: Extent report was not found:");

                Console.WriteLine(reportPath);

                return;
            }


            Console.WriteLine();
            Console.WriteLine(
                "Opening Extent report...");


            Process.Start(
                new ProcessStartInfo
                {
                    FileName = reportPath,
                    UseShellExecute = true
                });
        }


        // ============================================================
        // OPEN ALLURE
        // ============================================================

        private static void OpenAllureReport()
        {
            string allureReport =
                ReportRunManager.AllureDirectory;

            if (!Directory.Exists(allureReport))
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Allure report directory was not found.");

                return;
            }

            string indexPath =
                Path.Combine(
                    allureReport,
                    "index.html");

            if (!File.Exists(indexPath))
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Allure index.html was not found.");

                return;
            }

            Console.WriteLine();
            Console.WriteLine(
                "Opening Allure report using local server...");

            Console.WriteLine(
                allureReport);

            try
            {
                ProcessStartInfo processInfo =
                    new ProcessStartInfo
                    {
                        FileName = AllureCommand,

                        Arguments = $"serve \"{allureReport}\"",

                        UseShellExecute = true,

                        CreateNoWindow = false
                    };

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start Allure serve: {ex.Message}");
                Console.WriteLine("Opening index.html directly in default browser.");
                // Open the index.html directly
                ProcessStartInfo fallbackInfo = new ProcessStartInfo
                {
                    FileName = indexPath,
                    UseShellExecute = true
                };
                Process.Start(fallbackInfo);
            }
        }
    }
}

