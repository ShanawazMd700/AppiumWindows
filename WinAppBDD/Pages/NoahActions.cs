using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using WinAppBDD.Utilities;

namespace WinAppBDD.Pages
{
    public class NOAHActions : ControlHelpers
    {
        private const byte TabVirtualKey = 0x09;
        private const uint KeyUp = 0x0002;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(
            byte virtualKey,
            byte scanCode,
            uint flags,
            UIntPtr extraInfo);

        private readonly By OKButton = MobileBy.AccessibilityId("cmdOK");
        private readonly By passwordfield = MobileBy.AccessibilityId("Password");
        private readonly By fileheader = MobileBy.XPath("//Window[@Name='Noah 4']//Menu//MenuItem[@Name='File']");
        private readonly By openoption = MobileBy.Name("Open");
        private readonly By addnewpatientoption = MobileBy.Name("Add New Patient");
        private readonly By lastname = MobileBy.AccessibilityId("LastName");
        private readonly By firstname = MobileBy.AccessibilityId("FirstName");
        private readonly By genderoption = MobileBy.Name("Male");
        private readonly By addpatientokbutton = MobileBy.Name("OK");
         private readonly By audiogrammodule = MobileBy.XPath("//MenuItem[contains(@Name, 'Audiogram Module')]");
        private readonly By audiogramwindowclose = MobileBy.Name("Close");
        private readonly By firstAudiogramCell = MobileBy.Name(
            "Item: Himsa.Noah.CommonControls.TestValuesViewModel, Column Display Index: 0");

        private readonly By audiogramCopyButton = MobileBy.XPath("//Button[@HelpText='Copy to opposite ear']");

        private readonly By firstAudiogramEditor = MobileBy.XPath(
            "//Custom[@Name='Item: Himsa.Noah.CommonControls.TestValuesViewModel, Column Display Index: 0']//Edit");

        private By openFSWbrand(string brand) => MobileBy.XPath($"//MenuItem[contains(@Name, '{brand}')]");
        private string GenerateRandomString(int length = 7)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        public void EnterPassword(string password)
        {
            EnterText(passwordfield, password);
        }

        public void ClickOKButton()
        {
            Click(OKButton);
        }


        public void AddPatient()
        {
            string patientName = GenerateRandomString(7);
            string firstname1 = GenerateRandomString(7);
            Click(fileheader);
            Click(addnewpatientoption);
            EnterText(lastname, patientName);
            EnterText(firstname, firstname1);
            Click(genderoption);
            Click(addpatientokbutton);
            Console.WriteLine($"Adding patient: Name={patientName}, FirstName={firstname1}");
        }

        public void drwaaudiogram()
        {
            EnterAudiogramValues("30", 1);
        }

        public void openandDrawAudiogram()
        {
            Click(fileheader);
            Click(openoption);
            Click(audiogrammodule);
            EnterAudiogramValues("30", 10);
            Click(audiogramCopyButton);
            Click(audiogramwindowclose);
            Click(addpatientokbutton);
        }

        private void EnterAudiogramValues(string value, int columnCount)
        {
            if (columnCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(columnCount));
            }

            // The Custom cell is only a display container. A double-click opens its
            // editable template, exposing an actual Edit element for column 0.
            Click(firstAudiogramCell);
            Click(firstAudiogramCell);

            // Column 0 is already editing, so replace its existing value first.
            EnterText(firstAudiogramEditor, Keys.Control + "a");
            EnterText(firstAudiogramEditor, Keys.Delete);
            EnterText(firstAudiogramEditor, value);

            // Tab selects the next grid cell but does not materialize an Edit
            // element until text is typed. WinAppDriver cannot send a second value
            // through the disposed first editor, so use native keyboard input for
            // the focused grid cell after each two-Tab navigation.
            for (int columnIndex = 1; columnIndex < columnCount; columnIndex++)
            {
                SendVirtualKey(TabVirtualKey);
                SendVirtualKey(TabVirtualKey);
                Thread.Sleep(150); // Allow the grid to finish applying its two-Tab focus change.
                SendValueWithKeyboard(value);
            }
        }

        private static void SendValueWithKeyboard(string value)
        {
            foreach (char character in value)
            {
                if (character is < '0' or > '9')
                {
                    throw new ArgumentException("Audiogram values must contain only digits.", nameof(value));
                }

                SendVirtualKey((byte)character);
            }
        }

        private static void SendVirtualKey(byte virtualKey)
        {
            keybd_event(virtualKey, 0, 0, UIntPtr.Zero);
            keybd_event(virtualKey, 0, KeyUp, UIntPtr.Zero);
        }

   

        public void launchFSW(string brand)
        {
            // Implement the logic to launch FSW based on the brand parameter
            // This could involve clicking on specific UI elements or executing commands
            Click(fileheader);
            Click(openoption);
            Click(openFSWbrand(brand));
            Console.WriteLine($"Launching FSW for brand: {brand}");
        }
    }
}
