using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.BasePage;

namespace TestProject1.ExtentDriverFactory
{
    public class DriverFactory
    {
        private DriverFactory instance = new DriverFactory();

        public DriverFactory getInstance()
        {
            return instance;
        }

        private static readonly ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public static void SetDriver(IWebDriver browserDriver)
        {
            driver.Value = browserDriver;
            BasePageObject.smallWait.Value = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(10));
            BasePageObject.mediumWait.Value = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(20));
            BasePageObject.longWait.Value = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(30));
        }

        public static IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public static void QuitDriver()
        { 
            driver.Value.Quit();
        }
    }
}
