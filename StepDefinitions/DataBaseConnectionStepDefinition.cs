using AventStack.ExtentReports.Gherkin.Model;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Utils;

namespace TestProject1.StepDefinitions
{
    [Binding]
    public class DataBaseConnectionStepDefinition
    {

        [Given("I connect to the MySql database")]
         public async Task GivenIConnectToTheMySqlDatabase()
        {

            DataBaseUtil db = new DataBaseUtil(ConfigurationUtil.GetConnectionString("MySqlDb"));
            ConfigurationUtil.GetValue();
            // SELECT
            System.Data.DataTable users = await db.ExecuteQueryAsync("select * from vijethdb.lisa_cuddy;");
            TestContext.WriteLine("Number of rows retrieved: " + users.Rows.Count);
            TestContext.WriteLine("Data from lisa_cuddy table:");
            foreach (System.Data.DataRow row in users.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    TestContext.Write(item + "\t");
                }
                TestContext.WriteLine();
            }
        }
    }
}
