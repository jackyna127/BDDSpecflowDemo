//using BDDSpecflowDemo.Pages;
using BDDSpecflowDemo.PageFactories;
using System;
using TechTalk.SpecFlow;

namespace BDDSpecflowDemo.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {

        public SearchPage searchPage;
        [Given(@"I have entered search content")]
        public void GivenIHaveEnteredSearchContent(Table table)
        {
            searchPage = new SearchPage();
            searchPage.EnterSearchContent(table.Rows[0]["searchcontent"]);
        }

        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {
            searchPage.PressSearchButton();
        }

        [Then(@"The result should be displayed on the screen")]
        public void ThenTheResultShouldBeDisplayedOnTheScreen()
        {
            searchPage.VerifySearchResult();
        }
    }
}
