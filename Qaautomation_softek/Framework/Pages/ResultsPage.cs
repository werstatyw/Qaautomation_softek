using System;
using OpenQA.Selenium;
using Qaautomation_softek.Framework.UI;
using Qaautomation_softek.Framework.UI.Controls;
namespace Qaautomation_softek.Framework.Pages
{
    public class ResultsPage : Page
    {
        //  [FindBy("(//button[@type='submit'])[2]")]

        public Control buttonSubmit;
        public ResultsPage(IWebDriver driver) : base(driver)
        {
            buttonSubmit = new Control(this, By.XPath("(//button[@type='submit'])[2]"));
        }
    }
}
