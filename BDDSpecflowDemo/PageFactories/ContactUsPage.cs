using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Plugins;

namespace BDDSpecflowDemo.PageFactories
{
    public class ContactUsPage:BasePage
    {
        public ContactUsPage()
            : base()
        {
            PageFactory.InitElements(Browser.Current, this);
            webDriver = Browser.Current;
        }
        #region Elements
        [FindsBy(How = How.Id, Using = "p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_FirstName_txtText")]
        private IWebElement firstnameInput { get; set; }

        [FindsBy(How = How.Id, Using = "p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_LastName_txtText")]
        private IWebElement lastnameInput { get; set; }

        [FindsBy(How = How.Id, Using = "p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_JobTitle_txtText")]
        private IWebElement jobtitleInput { get; set; }

        [FindsBy(How = How.Id, Using = "p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_Organisation_txtText")]
        private IWebElement organisationInput { get; set; }

        [FindsBy(How = How.Id, Using = "p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_State_txtText")]
        private IWebElement locationInput { get; set; }

        [FindsBy(How = How.Id, Using = "p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_Phone_txtText")]
        private IWebElement phoneInput { get; set; }

        [FindsBy(How = How.Id, Using = "p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_Email_txtText")]
        private IWebElement emailInput { get; set; }

        [FindsBy(How = How.Id, Using = "p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_btnOK")]
        private IWebElement submitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='EditingFormErrorLabel']")]
        private IWebElement locationErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='p_lt_ctl06_pageplaceholder_p_lt_ctl01_ContactForm_viewBiz_pM_lS']/h4")]
        private IWebElement contactUsMessage { get; set; }

        #endregion

        #region Methods
        public void FillInFirstName(string firstName)
        {

            WaitForPageElement(firstnameInput);
            firstnameInput.SendKeys(firstName);
        }
        public void FillInLastName(string lastName)
        {
            lastnameInput.SendKeys(lastName);
        }
        public void FillInJobTitle(string jobTitle)
        {
            jobtitleInput.SendKeys(jobTitle);
        }
        public void FillInOrganisation(string organisation)
        {
            organisationInput.SendKeys(organisation);
        }
        public void FillInPhone(int phoneNumber)
        {
            phoneInput.SendKeys(phoneNumber.ToString());
        }
        public void FillInEmail(string emailAddress)
        {
            emailInput.SendKeys(emailAddress);
        }
        public void FillInLocation(string location)
        {
            locationInput.SendKeys(location);
        }

        public void PressSubmitButton()
        {
            submitButton.Click();
        }
        public void VerifyLocationErrorMessage()
        {
            WaitForPageElement(locationErrorMessage);
            true.Equals(locationErrorMessage.Displayed);
        }
        public void VerifyContactUsMessageDisplay()
        {
            WaitForPageElement(contactUsMessage);
            true.Equals(contactUsMessage.Displayed);
        }
        #endregion
    }
}
