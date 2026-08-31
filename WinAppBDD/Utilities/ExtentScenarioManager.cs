using AventStack.ExtentReports;

namespace WinAppBDD.Utilities
{
    public static class ExtentScenarioManager
    {
        private static readonly AsyncLocal<ExtentTest?> _currentTest =
            new AsyncLocal<ExtentTest?>();

        public static ExtentTest? CurrentTest
        {
            get => _currentTest.Value;
            set => _currentTest.Value = value;
        }

        public static void LogInfo(string message)
        {
            CurrentTest?.Info(message);
        }

        public static void LogPass(string message)
        {
            CurrentTest?.Pass(message);
        }

        public static void LogFail(string message)
        {
            CurrentTest?.Fail(message);
        }

        public static void LogWarning(string message)
        {
            CurrentTest?.Warning(message);
        }
    }
}