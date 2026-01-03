using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestProject1.ExtentDriverFactory
{
    public class ReportFactory
    {
        private static readonly ExtentReports _extent;
        private static readonly ThreadLocal<ExtentTest> _scenario = new ThreadLocal<ExtentTest>();


        static ReportFactory()
        {
            DateTime now = DateTime.Now;

            string year = now.ToString("yyyy"); // "2026"
            string month = now.ToString("MM");  // "01"
            string day = now.ToString("dd");

            var reportsDir = Path.Combine(AppContext.BaseDirectory, "Reports/"+year+"/"+month+"/"+day);
            Directory.CreateDirectory(reportsDir);

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            var htmlReporter = new ExtentSparkReporter(
                Path.Combine(reportsDir, $"ExtentReport_{timestamp}.html"));
            

            //var reportPath = Path.Combine(
            //                        AppContext.BaseDirectory,
            //                        "Reports",
            //                        "ExtentReports.html");
            //var htmlReporter = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            Console.WriteLine("Base Directory is "+AppContext.BaseDirectory);
        }

        public static ExtentTest CreateScenario(string scenarioName)
        {
            _scenario.Value = _extent.CreateTest(scenarioName);
            return _scenario.Value;
        }

        public static ExtentTest Scenario => _scenario.Value;

        public static void Flush() => _extent.Flush();
    }
}
