using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSpecflowDemo.PageFactories
{
     public class BasePage
    {
        protected int secondTimeOut;
        protected IWebDriver webDriver;
        public BasePage()
        {
            var appSettings = ConfigurationManager.AppSettings;
            secondTimeOut = Convert.ToInt32(appSettings["TimeOut"]);
            Browser.Current.Manage().Window.Maximize();
            webDriver = Browser.Current;
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(secondTimeOut));
    
        }
        public void WaitForPageElement(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(secondTimeOut));
            try
            {
                wait.Until(drv => webElement.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                //add throw new exception message
            }
        }
    }
}
