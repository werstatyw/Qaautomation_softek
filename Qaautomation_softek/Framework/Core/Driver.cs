using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
namespace Qaautomation_softek.Framework.Core
{
    public class Driver
    {
        private static IWebDriver driver;
      //  private static Dictionary<String, IWebDriver> driverThreadMap = new Dictionary<String, IWebDriver>();
        private static Dictionary<String, Type> driverMap = new Dictionary<String, Type>()
        {
             {"chrome", typeof(ChromeDriver)},
             {"firefox", typeof(FirefoxDriver)},
             {"ie", typeof(InternetExplorerDriver)},
             {"opera", typeof(OperaDriver)},
             {"safari", typeof(SafariDriver)}
        };
        private static Dictionary<String, Type> optionsMap = new Dictionary<String, Type>()
        {
             {"chrome", typeof(ChromeOptions)},
             {"firefox", typeof(FirefoxOptions)},
             {"ie", typeof(InternetExplorerOptions)},
             {"opera", typeof(OperaOptions)},
             {"safari", typeof(SafariOptions)}
        };
        private Driver()
        {
        }
      /*  private static String _getThreadName()
        {
            return Thread.CurrentThread.Name + Thread.CurrentThread.ManagedThreadId;
        }*/
        public static void Add(String browser, String path, ICapabilities capabilities)
        {
            Type driverType = driverMap[browser];
            DriverOptions options = (DriverOptions) optionsMap[browser].GetConstructor(new Type[] { }).Invoke(new Object[] { });
            //     IWebDriver driver;
            if (browser == "firefox")
            {
                driver = new FirefoxDriver((FirefoxOptions)options);
            }
            else if (browser == "chrome")
            {
                driver = new ChromeDriver(Path.GetFullPath("/home/wers4/Projects/Qaautomation_softek/Qaautomation_softek"));
            }
            else
            {
                 driver = (IWebDriver) driverType.GetConstructor(new Type[] { typeof(String), optionsMap[browser] }).Invoke(new Object[] { path, options });
                //driver = new ChromeDriver(Path.GetFullPath("/home/wers4/Projects/Qaautomation_softek/Qaautomation_softek"));
            }
         //   String threadName = _getThreadName();
           // driverThreadMap.Add(threadName, driver);
        }
        public static IWebDriver Current()
        {
            // String threadName = _getThreadName();
            //return driverThreadMap[threadName];
            return driver;
        }
        public static void Quit()
        {
           // String threadName = _getThreadName();
            Current().Quit();
            //driverThreadMap.Remove(threadName);
        }
    }
}
