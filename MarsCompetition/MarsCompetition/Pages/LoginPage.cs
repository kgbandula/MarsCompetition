using MarsCompetition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Pages
{
    public class LoginPage : CommonDriver
    {
        public void LoginActions(IWebDriver driver)
        {
            //Click on link login
            IWebElement loginPointerCursor = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/a"));
            loginPointerCursor.Click();
            //enter email address
            IWebElement loginEmailTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            loginEmailTextbox.Click();
            loginEmailTextbox.SendKeys("kgbandula@gmail.com");
            //enter password
            IWebElement loginPasswordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            loginPasswordTextbox.Click();
            loginPasswordTextbox.SendKeys("bandu197");
            //remember me checkbox
            IWebElement rememberMeCheckbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input"));
            rememberMeCheckbox.Click();
            //login button
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Thread.Sleep(5000);
        }
    }
}
