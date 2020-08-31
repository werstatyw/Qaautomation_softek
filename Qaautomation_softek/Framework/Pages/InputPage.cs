using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using NUnit.Framework;
using Qaautomation_softek.Framework.Core;
using Qaautomation_softek.Framework.UI;
using Qaautomation_softek.Framework.UI.Controls;
namespace Qaautomation_softek.Framework.Pages
{
    public class InputPage : Page
    {
   //     [FindBy("promoCode")]
        public Edit editPromocode;
     //   [FindBy("firstName")]
        public Edit editFirstName;
      //  [FindBy("lastName")]
        public Edit editLastName;
       // [FindBy("cc_name")]
        public Edit editcardName;
       // [FindBy("cc-number")]
        public Edit editcardNumber;
       // [FindBy("cc-expiration")]
        public Edit editExpiraton;
       // [FindBy("cc-cvv")]
        public Edit editCvv;

     //   [FindBy("(//button[@type='submit'])[2]")]
        public Control buttonSubmit;
    //    [FindBy("(//button[@type='submit'])")]
        public Control buttonSubmitpromo;
        public InputPage(IWebDriver driver) : base(driver)
        {
            editPromocode = new Edit(this, By.Id("promoCode"));
            editFirstName = new Edit(this, By.Id("firstName"));
            editLastName = new Edit(this, By.Id("lastName"));
            editcardName = new Edit(this, By.Id("cc-name"));
            editcardNumber = new Edit(this, By.Id("cc-number"));
            editExpiraton = new Edit(this, By.Id("cc-expiration"));
            editCvv = new Edit(this, By.Id("cc-cvv"));

            buttonSubmit = new Control(this, By.XPath("(//button[@type='submit'])[2]"));
            buttonSubmitpromo = new Control(this, By.XPath("(//button[@type='submit'])"));
        }
        public override Page Navigate()
        {
            String baseURL = Configuration.Get("BaseURL");
            Driver.Navigate().GoToUrl(baseURL);
            return this;
        }
    }
}
