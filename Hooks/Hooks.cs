using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.ExtentDriverFactory;



namespace TestProject1.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            string browser = TestContext.Parameters["Browser"] ?? "chrome";
            //it means is there "Browser" value if so use what ever used in yaml else if null use chrome
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");
            IWebDriver drive  = new ChromeDriver();
            DriverFactory.SetDriver(drive);
            ReportFactory.CreateScenario(context.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
                ReportFactory.Scenario.Pass("Step passed");
            else
                ReportFactory.Scenario.Fail(context.TestError);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ReportFactory.Flush();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverFactory.GetDriver().Quit();
        }
    }
}
