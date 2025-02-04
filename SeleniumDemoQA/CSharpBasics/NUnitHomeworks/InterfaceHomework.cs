﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics.NUnitHomeworks
{
    public interface IMyWebDriver
    {
        // TODO: add methods here
        void Open(string url);
        void FindElement(string locator);
        void Close();

    }

    public interface IMyWindowsWebDriver
    {
        // TODO: add methods here
        string GetWindowsVersion();

    }



    public class CromeDriver: IMyWebDriver, IMyWindowsWebDriver  // TODO: add interfaces here
    {
        public static readonly string DriverName = "Chrome";
        public void Open(string url)
        {
            Console.WriteLine($"Opening {DriverName}");
        }

        public void FindElement(string locator)
        {
            Console.WriteLine($"Find {locator}");
        }

        public void Close()
        {
            Console.WriteLine($"Closing {DriverName}");
        }

        public string GetWindowsVersion()
        {
            return "Windows 10";
        }
    }

    public class SafariDriver: IMyWebDriver  // TODO: add interfaces here
    {
        public static readonly string DriverName = "Safari";
        public void Open(string url)
        {
            Console.WriteLine($"Opening {DriverName}");
        }

        public void Close()
        {
            Console.WriteLine($"Closing {DriverName}");
        }

        public void FindElement(string locator)
        {
            Console.WriteLine($"Find {locator}");
        }

    }

    public class FirefoxDriver: IMyWebDriver, IMyWindowsWebDriver  // TODO: add interfaces here
    {
        public static readonly string DriverName = "Firefox";

        public void FindElement(string locator)
        {
            Console.WriteLine($"Find {locator}");
        }

        public void Open(string url)
        {
            Console.WriteLine($"Opening {DriverName}");
        }

        public string GetWindowsVersion()
        {
            return "Windows 11";
        }

        public void Close()
        {
            Console.WriteLine($"Closing {DriverName}");
        }
    }
}
