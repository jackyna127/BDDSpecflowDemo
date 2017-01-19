using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSpecflowDemo.PageFactories
{
    public class HomePage:BasePage
    {
        public HomePage()
            : base()            
        {
            PageFactory.InitElements(Browser.Current, this);
            var appSettings = ConfigurationManager.AppSettings;
            webDriver.Url = appSettings["BaseUrl"];          
        }
        #region Elements
        [FindsBy(How = How.LinkText,Using = "Contact Us")]
        private IWebElement ContactUs {get; set;}
        #endregion

        #region Methods
        public void GotoContactUsPage()
        {
            ContactUs.Click();
        }
        #endregion
    }
}
