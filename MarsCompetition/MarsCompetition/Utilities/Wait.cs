using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsCompetition.Utilities
{
    public class Wait : ExcelLib
    {
        //public static void ImplicitWait(int second)
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(second);
        //}
        public static void WaitToBeClickable(IWebDriver driver, string locatorValue, string locatorType, int seconds)
        {
            //static allows you to use without creating a object
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20000));
            
            if(locatorValue == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            }
            if (locatorValue == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
            }
            if (locatorValue == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            if (locatorValue == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            }
        }
        public static void WaitToBeExists(IWebDriver driver, string locatorValue, string locatorType, int seconds)
        {
            //static allows you to use without creating a object
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20000));

            if (locatorType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(locatorType)));
            }
            if (locatorType == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name(locatorType)));
            }
            if (locatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locatorType)));
            }
            if (locatorType == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(locatorType)));
            }
        }
        public static void WaitToBeVisible(IWebDriver driver, string locatorValue, string locatorType, int seconds)
        {
            //static allows you to use without creating a object
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20000));

            if (locatorType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorType)));
            }
            if (locatorType == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(locatorType)));
            }
            if (locatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorType)));
            }
            if (locatorType == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorType)));
            }
        }
    }
}
