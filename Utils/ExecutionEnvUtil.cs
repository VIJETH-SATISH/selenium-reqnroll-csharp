using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utils
{
    public class ExecutionEnvUtil
    {
        public static bool IsGitHubActions =>
        Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";
        public static bool IsLocal => !IsGitHubActions;
    }
}
