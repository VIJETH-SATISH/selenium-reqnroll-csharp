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
