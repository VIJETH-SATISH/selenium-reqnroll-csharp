using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TestProject1.Utils;

namespace TestProject1.ExtentDriverFactory
{
    public class ReportFactory
    {
        private static readonly ExtentReports _extentReport;
        private static readonly ThreadLocal<ExtentTest> _scenario = new ThreadLocal<ExtentTest>();
        private static readonly List<FailedScenario> _failedScenarios = new();
        public static DateTime now = DateTime.Now;
        static string year;
        static string month;
        static string day;
        static string timestamp;


        static ReportFactory()
        {
            year = now.ToString("yyyy"); // "2026"
            month = now.ToString("MM");  // "01"
            day = now.ToString("dd");

            var reportsDir = Path.Combine(AppContext.BaseDirectory, "Reports/"+year+"/"+month+"/"+day);
            Directory.CreateDirectory(reportsDir);

            timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            var htmlReporter = new ExtentSparkReporter(
                Path.Combine(reportsDir, $"ExtentReport_{timestamp}.html"));
            _extentReport = new ExtentReports();
            _extentReport.AttachReporter(htmlReporter);
            Console.WriteLine("Base Directory is "+AppContext.BaseDirectory);
        }

        public static ExtentTest CreateScenario(string scenarioName)
        {
            _scenario.Value = _extentReport.CreateTest(scenarioName);
            return _scenario.Value;
        }

        public static ExtentTest Scenario()
        {
           return _scenario.Value;
        }

        public static void Flush() => _extentReport.Flush();

        public static void RecordFailure(string scenarioName, Exception ex)
        {
            _failedScenarios.Add(new FailedScenario
            {
                Name = scenarioName,
                Error = ex.ToString()
            });
        }

        public static void GenerateFailedOnlyReport()
        {
            if (_failedScenarios.Count == 0)
                return;

            var failedReportsDir = Path.Combine(AppContext.BaseDirectory, "Reports/" + year + "/" + month + "/" + day + "/FailedOnly");
            Directory.CreateDirectory(failedReportsDir);

            //var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var reporter = new ExtentSparkReporter(
                Path.Combine(failedReportsDir, $"Failed_Scenarios_{timestamp}.html"));

            var failedExtent = new ExtentReports();
            failedExtent.AttachReporter(reporter);

            foreach (var failed in _failedScenarios)
            {
                failedExtent
                    .CreateTest(failed.Name)
                    .Fail(failed.Error);
            }

            failedExtent.Flush();
        }

    }
}
