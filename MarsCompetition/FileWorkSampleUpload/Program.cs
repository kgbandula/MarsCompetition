using AutoItX3Lib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FileWorkSampleUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            //Open Chrome Browser
            IWebDriver driver = new ChromeDriver();

            //driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(30));

            //Launch local host 5000
            driver.Navigate().GoToUrl("http://localhost:5000/Home/ServiceListing");

            //Maximise the window
            driver.Manage().Window.Maximize();

            //File upload
            IWebElement workSamples = driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
            workSamples.Click();
            Thread.Sleep(5000);
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            autoIt.Send(@"F:\Mars\MarsCompetition\WorkSamples.txt");
            autoIt.Send("{Enter}");
        }
    }
}



