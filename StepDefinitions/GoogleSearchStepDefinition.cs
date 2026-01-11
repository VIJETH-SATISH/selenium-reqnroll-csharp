using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.ExtentDriverFactory;
using TestProject1.PageObjectClasses;

namespace TestProject1.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinition
    {
        private GoogleSearchPageObject _googlePageObj;

        public GoogleSearchStepDefinition()
        {
            _googlePageObj = new GoogleSearchPageObject();
        }

        [Given("I open the Google homepage")]
        public void GivenIOpenGoogleHomepage()
        {
            DriverFactory.GetDriver().Navigate().GoToUrl("https://www.google.com");
           
        }

        [Then("the page title should contain {string}")]
        public void ThenThePageTitleShouldContain(string title)
        {
            _googlePageObj.EnterTheTextInSearchBox(title);
            _googlePageObj.ClickOnSearchButton();
        }
    }
}
