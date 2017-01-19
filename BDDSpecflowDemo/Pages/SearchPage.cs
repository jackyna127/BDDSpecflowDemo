using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSpecflowDemo.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage()
            : base()
        {
            searchResult = "";
            webDriver = Browser.Current;
        }

        #region Elements
        private By searchInput = By.Id("p_lt_ctl02_SmartSearchBox_txtWord");
        private By searchLink = By.XPath("//a[@class='header_search-btn js_header_search-btn']");
        private By searchButton = By.Id("p_lt_ctl02_SmartSearchBox_btnSubmit");
        private string searchResult { get; set; }
        #endregion

        #region Methods
        public void ClickSearchLink()
        {
            WaitForPageElement(searchLink);
            webDriver.FindElement(searchLink).Click();
        }
        public void EnterSearchContent(string searchText)
        {
            ClickSearchLink();
            WaitForPageElement(searchInput);
            webDriver.FindElement(searchInput).Clear();
            webDriver.FindElement(searchInput).SendKeys(searchText);
            searchResult = searchText;
            System.Console.WriteLine(searchText);

        }
        public void PressSearchButton()
        {
            webDriver.FindElement(searchButton).Click();
        }
        public void VerifySearchResult()
        {
            WaitForPageElement(By.PartialLinkText(searchResult));
            true.Equals(webDriver.FindElement(By.PartialLinkText(searchResult)).Displayed);
        }
        #endregion
    }
}
