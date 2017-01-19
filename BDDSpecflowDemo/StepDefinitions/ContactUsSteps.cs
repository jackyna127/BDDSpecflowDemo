using BDDSpecflowDemo.Pages;
using System;
using TechTalk.SpecFlow;

namespace BDDSpecflowDemo.StepDefinitions
{
    [Binding]
    public class ContactUsSteps : Steps
    {
        HomePage homePage;
        ContactUsPage contactusPage;

        [Given(@"I am at the Home Page")]
        public void GivenIAmAtTheHomePage()
        {
            homePage = new HomePage();
        }

        [Given(@"I navigate to ContactUs Page")]
        public void GivenINavigateToContactUsPage()
        {
            homePage.GotoContactUsPage();
        }


        [When(@"I fill in First Name as (.*)")]
        public void WhenIFillInFirstNameAs(string p0)
        {
            contactusPage = new ContactUsPage();
            contactusPage.FillInFirstName(p0);
        }

        [When(@"I fill in Last Name as (.*)")]
        public void WhenIFillInLastNameAs(string p0)
        {
            contactusPage.FillInLastName(p0);
        }

        [When(@"I fill in Job Title as (.*)")]
        public void WhenIFillInJobTitleAs(string p0)
        {
            contactusPage.FillInJobTitle(p0);
        }

        [When(@"I fill in Organisation as (.*)")]
        public void WhenIFillInOrganisationAs(string p0)
        {
            contactusPage.FillInOrganisation(p0);
        }

        [When(@"I fill in Phone as (.*)")]
        public void WhenIFillInPhoneAs(int p0)
        {
            contactusPage.FillInPhone(p0);
        }

        [When(@"I fill in Email as (.*)")]
        public void WhenIFillInEmailAs(string p0)
        {
            contactusPage.FillInEmail(p0);
        }

        [When(@"I press Submit Button")]
        public void WhenIClickSubmitButton()
        {
            contactusPage.PressSubmitButton();
        }
        [Then(@"I can see Please enter your Location message display")]
        public void ThenICanSeePleaseEnterYourLocationMessageDisplay()
        {
            contactusPage.VerifyLocationErrorMessage();
        }


        [Then(@"I can see error message display")]
        public void ThenICanSeeErrorMessageDisplay()
        {
            Then("I can see Please enter your Location message display");
        }

        [When(@"I Fill the contact information form with correct information")]
        public void WhenIFillTheContactInformationFormWithCorrectInformation()
        {
            When(string.Format("I fill in First Name as {0}","Helen"));
            When(string.Format("I fill in Last Name as {0}","West"));
            When(string.Format("I fill in Job Title as {0}", "Test Analyst"));
            When(string.Format("I fill in Organisation as {0}", "Planit"));
            When(string.Format("I fill in Phone as {0}","0211569987"));
            When(string.Format("I fill in Email as {0}","test@test.com"));
        }

        [When(@"I Fill the contact information form with")]
        public void WhenIFillTheContactInformationFormWith(Table table)
        {
            contactusPage = new ContactUsPage();
            contactusPage.FillInFirstName(table.Rows[0]["firstname"]);
            contactusPage.FillInLastName(table.Rows[0]["lastname"]);
            contactusPage.FillInJobTitle(table.Rows[0]["jobtitle"]);
            contactusPage.FillInOrganisation(table.Rows[0]["organisation"]);
            contactusPage.FillInPhone(Convert.ToInt32(table.Rows[0]["phone"]));
            contactusPage.FillInEmail(table.Rows[0]["email"]);
        }    
        
    }
}
