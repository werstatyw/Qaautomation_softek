using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using NUnit.Framework;
using Qaautomation_softek.Framework.Core;
using Qaautomation_softek.Framework.UI.Controls;
namespace Qaautomation_softek.Framework.UI
{
    public class Page
    {
        private IWebDriver driver;
        public IWebDriver Driver
            {
            get
            {
            return driver;
            }
}

       

        public Page(IWebDriver driverValue)
        {
            driver = driverValue;
        }
        public virtual Page Navigate()
        {
            return this;
        }
        public bool IsTextPresent(String text)
        {
            String locatorText = String.Format("//*[text()='{0} or contains(text(), '{1}')]", text, text);
            Control element = new Control(this, By.XPath(locatorText));
            return element.Exists();
        }
     public byte[] CaptureSceenShot()
        {
            Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
            return screen.AsByteArray;
        }
        public void  CaptureSceenShot(String path)
        {
            Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen.SaveAsFile(path, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }
    }
}
