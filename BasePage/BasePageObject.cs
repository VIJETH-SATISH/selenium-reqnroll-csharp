using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.ExtentDriverFactory;

namespace TestProject1.BasePage
{
    
    public class BasePageObject
    {

        public static readonly ThreadLocal<WebDriverWait> smallWait = new ThreadLocal<WebDriverWait>();
        public static readonly ThreadLocal<WebDriverWait> mediumWait = new ThreadLocal<WebDriverWait>();    
        public static readonly ThreadLocal<WebDriverWait> longWait = new ThreadLocal<WebDriverWait>();
        public IWebDriver driver;

        public BasePageObject()
        {
            driver = DriverFactory.GetDriver();
            
        }

    }
}
