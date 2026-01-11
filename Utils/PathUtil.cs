using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utils
{
    public class PathUtil
    {
       
        public static string RepoRoot
        {
            get
            {
                // GitHub Actions
                var ghWorkspace = Environment.GetEnvironmentVariable("GITHUB_WORKSPACE");
                //if (!string.IsNullOrEmpty(ghWorkspace))
                    return ghWorkspace;

                // Local fallback
                //return Directory.GetCurrentDirectory();
            }
        }
    }

}
