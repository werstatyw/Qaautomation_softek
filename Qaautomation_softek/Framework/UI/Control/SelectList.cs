using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qaautomation_softek.Framework.Core;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
namespace Qaautomation_softek.Framework.UI.Controls
{
    public class SelectList : Control
    {
        public SelectElement Select
        {
            get
            {
                return new SelectElement(base.Element);
            }
        }
        public new String Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                this.Select.SelectByText(value);
            }
        }
        public SelectList(Page pageValue, By locatorValue) : base(pageValue,locatorValue)
        {
        }
    }
}
