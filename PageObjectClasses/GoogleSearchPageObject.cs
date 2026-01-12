using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject1.PageObjectClasses
{
    public class GoogleSearchPageObject: BasePage.BasePageObject
    {

        private IWebElement SearchBox => driver.FindElement(By.XPath("(//textareaaa)[1]"));
        private IWebElement SearchButton => driver.FindElement(By.XPath("(//input[@value='Google Search'])[2]"));

        public void EnterTheTextInSearchBox(string text)
        {     
            WaitUtils.WaitForElement(mediumWait.Value, SearchBox).SendKeys(text);
        }

        public void ClickOnSearchButton()
        {
            WaitUtils.WaitForElement(smallWait.Value, SearchBox).SendKeys(Keys.Enter);

        }
    }
}
