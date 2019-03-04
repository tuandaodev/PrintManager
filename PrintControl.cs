using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace PrintManager
{
    class PrintControl
    {
        public PrintControl()
        {
            Console.WriteLine("Start Print-Control");
        }

        public void getPrinters()
        {
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name");
                var status = printer.GetPropertyValue("Status");
                var isDefault = printer.GetPropertyValue("Default");
                var isNetworkPrinter = printer.GetPropertyValue("Network");

                Console.WriteLine("{0} (Status: {1}, Default: {2}, Network: {3}",
                            name, status, isDefault, isNetworkPrinter);
            }
        }
    }
}
