using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Utils;

namespace TestProject1.PageObjectClasses
{
    public class SauceDemoSecretLoginPageObject: BasePage.BasePageObject
    {

        private IWebElement username_txt => driver.FindElement(By.Id("user-name"));
        private IWebElement password_txt => driver.FindElement(By.Id("password"));
        private IWebElement login_btn => driver.FindElement(By.Id("login-button"));

        public void EnterTheUserNameAndPwdToLogin(string username, string password)
        {
            WaitUtils.WaitForElement(mediumWait.Value, username_txt).SendKeys(username);
            WaitUtils.WaitForElement(mediumWait.Value, password_txt).SendKeys(password);
            WaitUtils.WaitForElement(mediumWait.Value, login_btn).Click();
        }
    }
}
