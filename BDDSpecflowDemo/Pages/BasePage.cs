
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BDDSpecflowDemo.Pages
{
   

    public class BasePage
    {
        protected int secondTimeOut;
        protected IWebDriver webDriver;
        public BasePage()
        {
            var appSettings = ConfigurationManager.AppSettings;

            Browser.Current.Manage().Window.Maximize();
            webDriver = Browser.Current;
            secondTimeOut = Convert.ToInt32(appSettings["TimeOut"]);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(secondTimeOut));
        }
        
        public void WaitForPageElement(By byElement)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(secondTimeOut));

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(byElement));
            }
            catch (WebDriverTimeoutException)
            {
                //add throw new exception message
            }

        }
    }
}
