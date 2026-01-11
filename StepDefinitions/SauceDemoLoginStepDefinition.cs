using Reqnroll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.ExtentDriverFactory;
using TestProject1.PageObjectClasses;

namespace TestProject1.StepDefinitions
{
    [Binding]
    public class SauceDemoLoginStepDefinition
    {

        SauceDemoSecretLoginPageObject sauceDemoSecretLoginPageObj;
        public SauceDemoLoginStepDefinition()
        {
            sauceDemoSecretLoginPageObj = new SauceDemoSecretLoginPageObject();
        }


        [Given("I open the Sauce Demo login page")]
        public void IopentheSauceDemologinpage() { 
       
            DriverFactory.GetDriver().Navigate().GoToUrl("https://www.saucedemo.com/");
            
        }

        [When("I login with secret credentials")]
        public void Iloginwithsecretcredentials()
        {
            string username = Environment.GetEnvironmentVariable("SAUCEDEMO_USER_NAME");
            string password = Environment.GetEnvironmentVariable("SAUCEDEMO_USER_PWD");
            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("SauceDemo credentials are not set in environment variables");
            }
            sauceDemoSecretLoginPageObj.EnterTheUserNameAndPwdToLogin(username, password);
        }

    }
}
