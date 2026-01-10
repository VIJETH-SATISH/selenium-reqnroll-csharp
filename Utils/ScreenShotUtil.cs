using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utils
{
    public class ScreenShotUtil
    {
        public static string CaptureBase64(IWebDriver driver)
        {
            return ((ITakesScreenshot)driver)
                .GetScreenshot()
                .AsBase64EncodedString;
        }
    }
}
