using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qaautomation_softek.Framework.Core;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
namespace Qaautomation_softek.Framework.UI.Controls
{
    public class Edit : Control
    {
        public new String Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                this.Click();
                this.Element.Clear();
                this.Element.SendKeys(value);
            }
        }
        public Edit(Page pageValue, By locatorValue) : base(pageValue, locatorValue)
        {
        }
    }
}
