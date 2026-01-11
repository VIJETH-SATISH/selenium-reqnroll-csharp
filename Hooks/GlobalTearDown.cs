using TestProject1.ExtentDriverFactory;
using NUnit.Framework;

namespace TestProject1.Hooks
{
    [SetUpFixture]
    public class GlobalTearDown
    {

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            // final cleanup / reporting
            try
            {
                Console.WriteLine("I am inside After Test Run!!");
                ReportFactory.Flush();
                ReportFactory.GenerateFailedOnlyReport();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("AfterTestRun failed: " + ex);
            }
        }
    }
}
