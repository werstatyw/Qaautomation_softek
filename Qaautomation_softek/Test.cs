using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Qaautomation_softek.Framework.Pages;
using Qaautomation_softek.Framework.Core;
using Qaautomation_softek.Framework.UI;
using Qaautomation_softek.Framework.UI.Controls;
namespace Qaautomation_softek
{
    [TestFixture]
    public class Qaatomation_softek
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private InputPage inputPage;
        private ResultsPage resultsPage;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            baseURL = Configuration.Get("BaseURL");
            ChromeOptions options = new ChromeOptions();
          // DesiredCapabilities capabilities = new DesiredCapabilities();
            //    Driver.Add(Configuration.Get("Browser"), Path.GetFullPath("/home/wers4/Projects/Qaautomation_softek/Qaautomation_softek"), capabilities);
                 driver = new ChromeDriver(Path.GetFullPath("/home/wers4/Projects/Qaautomation_softek/Qaautomation_softek"),options);
            inputPage = new InputPage(driver);
            inputPage.Navigate();
}

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
          catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());

        }
        static Object[] InputData =
        {
            new Object[] {"","","","","","",""},
            new Object[] {"xz","alex","g","alex g","1234567812345678","02/2024","345"},

        };

        [Test(), TestCaseSource("InputData")]
        public void TheOrderPlacedSoftekTest(String promoCode, String firstName, String lastName, String nameOnCard, String cardNumber, String expirationDate, String cvv )
        {

            //driver.Navigate().GoToUrl("https://qaautomation-test.s3-eu-west-1.amazonaws.com/index.html");
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1200);
           Thread.Sleep(3000);

            inputPage.editPromocode.Text = promoCode;
            inputPage.buttonSubmitpromo.Click();
            inputPage.buttonSubmit.Click();
            inputPage.editFirstName.Text = firstName;
            inputPage.editLastName.Text = lastName;
            inputPage.editcardName.Text = nameOnCard;
            inputPage.editcardNumber.Text = cardNumber;
            inputPage.editExpiraton.Text = expirationDate;
            inputPage.editCvv.Text = cvv;
            inputPage.buttonSubmit.Click();
            //        Assert.True(resultsPage.IsTextPresent("Valid first name is required."));
             inputPage.CaptureSceenShot(Path.GetFullPath("/home/wers4/Projects/Qaautomation_softek/Qaautomation_softek//image002.png"));

            resultsPage = new ResultsPage(driver);
           resultsPage.buttonSubmit.Click();
            Assert.True(resultsPage.IsTextPresent("Valid first name is required."));
            resultsPage.CaptureSceenShot(Path.GetFullPath("/home/wers4/Projects/Qaautomation_softek/Qaautomation_softek/image001.png"));
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
