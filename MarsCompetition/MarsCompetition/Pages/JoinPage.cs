using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Pages
{
    public class JoinPage
    {
        public void JoinActions(IWebDriver driver)
        {
           
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div / button")));//explicit wait
            //Maximise the browser window
            driver.Manage().Window.Maximize();
            //Open local host 
            driver.Navigate().GoToUrl("http://localhost:5000/");
            Thread.Sleep(10000);
            //Identify join button and click 
            IWebElement joinButton1 = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/button"));
            joinButton1.Click();
            try
            {
                //Identify first name textbox and enter first name
                IWebElement firstNameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/input"));
                firstNameTextbox.Click();
                firstNameTextbox.SendKeys("Bandula");
            }
            catch (Exception ex)
            {
                Assert.Fail("Local host was not launched.", ex.Message);
            }
            //Identify last name textbox and enter last name
            IWebElement lastNameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/input"));
            lastNameTextbox.Click();
            lastNameTextbox.SendKeys("Wimalasena");
            //Identify email address textbox and enter email address
            IWebElement emailAddressTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/input"));
            emailAddressTextbox.Click();
            emailAddressTextbox.SendKeys("kgbandula@gmail.com");
            //Identify password textbox and enter password
            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/input"));
            passwordTextbox.Click();
            passwordTextbox.SendKeys("bandu197");
            //Identify confirm password textbox and enter password
            IWebElement confirmPasswordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/input"));
            confirmPasswordTextbox.Click();
            confirmPasswordTextbox.SendKeys("bandu197");
            //Identify I agree check box and click on
            IWebElement termsConditionsCheckbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/div/input"));
            termsConditionsCheckbox.Click();
            //Identify join button
            IWebElement joinButton2 = driver.FindElement(By.Id("submit-btn"));
            joinButton2.Click();
            Thread.Sleep(5000);
        }
    }
}
