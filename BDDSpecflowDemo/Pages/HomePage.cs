using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSpecflowDemo.Pages
{
    public class HomePage : BasePage
    {
        public HomePage()
            : base()
        {
            var appSettings = ConfigurationManager.AppSettings;
            webDriver.Url = appSettings["BaseUrl"];

        }
        #region Elements

        private By contactUs = By.LinkText("Contact Us");

        #endregion

        #region Methods
        public void GotoContactUsPage()
        {
            webDriver.FindElement(contactUs).Click();
        }

        #endregion
    }
}

