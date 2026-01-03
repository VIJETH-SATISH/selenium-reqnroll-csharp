using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utils
{
    public class WaitUtils
    {

        public static IWebElement WaitForElement(WebDriverWait wait, IWebElement ele)
        {
            if (wait == null)
            {
                throw new ArgumentNullException(nameof(wait), "mediumWait.Value cannot be null.");
            }
            var element = wait.Until(d =>
            {
               return ele.Displayed ? ele : null;
            });

            return element;
        }
    }
}
