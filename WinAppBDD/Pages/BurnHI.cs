using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WinAppBDD.Utilities;

namespace WinAppBDD.Pages
{
    public class BurnHI 
    {
        private readonly BurnWireless burnwireless;
        public BurnHI()
        {
            burnwireless = new BurnWireless();
        }
        public void BurnHearingInstrument(string instrumentname, string device, int serialnumber, string devicetype)
        {
            if (devicetype == "Dooku3" || devicetype == "Dooku2")
            {
                burnwireless.Enterproductname(instrumentname);
            }


        }
    }
}
