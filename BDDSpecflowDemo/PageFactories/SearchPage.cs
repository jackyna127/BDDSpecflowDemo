using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSpecflowDemo.PageFactories
{
    public class SearchPage : BasePage
    {
        public SearchPage()
            : base()
        {
            searchResult = "";
            PageFactory.InitElements(Browser.Current, this);

        }

        #region Elements
        [FindsBy(How = How.Id, Using = "p_lt_ctl02_SmartSearchBox_txtWord")]
        private IWebElement searchInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@class='header_search-btn js_header_search-btn']")]
        private IWebElement searchLink { get; set; }
        [FindsBy(How = How.Id, Using = "p_lt_ctl02_SmartSearchBox_btnSubmit")]
        private IWebElement searchButton { get; set; }
        private string searchResult { get; set; }
        #endregion

        #region Methods
        public void ClickSearchLink()
        {
            WaitForPageElement(searchLink);
            searchLink.Click();
        }
        public void EnterSearchContent(string searchText)
        {
            ClickSearchLink();
            WaitForPageElement(searchInput);
            searchInput.Clear();
            searchInput.SendKeys(searchText);
            searchResult = searchText;

        }
        public void PressSearchButton()
        {
            searchButton.Click();
        }
        public void VerifySearchResult()
        {
            //WaitForPageElement(webDriver.FindElement(By.PartialLinkText(searchResult)));
            true.Equals(webDriver.FindElement(By.PartialLinkText(searchResult)).Displayed);

        }

        #endregion
    }
}
