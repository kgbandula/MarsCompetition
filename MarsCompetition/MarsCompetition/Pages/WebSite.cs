using MarsCompetition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MarsCompetition.Pages
{
    public class WebSite : CommonDriver
    {
        #region Join Web Elements        
        private IWebElement joinButton => driver.FindElement(By.XPath("//button[text()='Join']"));
        private IWebElement firstName => driver.FindElement(By.Name("firstName"));
        private IWebElement lastName => driver.FindElement(By.Name("lastName"));
        private IWebElement emailAddress => driver.FindElement(By.Name("email"));
        private IWebElement password => driver.FindElement(By.Name("password"));
        private IWebElement confirmPassword => driver.FindElement(By.Name("confirmPassword"));
        private IWebElement termsConditions => driver.FindElement(By.Name("terms"));
        private IWebElement joinButton2 => driver.FindElement(By.Id("submit-btn"));
        private IWebElement emailAddressText => driver.FindElement(By.XPath("//*[text()='This email has already been used to register an account.']"));
        private IWebElement loginLinkText => driver.FindElement(By.XPath("//a[@class='pointerCursor']"));
        #region Join Web Elements

        #region Login Web Elements
        private IWebElement signInButton => driver.FindElement(By.XPath("//a[text()='Sign In']"));
        private IWebElement loginEmail => driver.FindElement(By.Name("email"));
        private IWebElement loginPassword => driver.FindElement(By.Name("password"));
        private IWebElement rememberMe => driver.FindElement(By.Name("rememberDetails"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//button[text()='Login']"));
        private IWebElement loginSuccessText => driver.FindElement(By.XPath("//*[(text()=\"Bandula\")]"));
        private IWebElement shareSkillText => driver.FindElement(By.XPath("//a[text()='Share Skill']"));
        #region Login Web Elements


        #region goto Url       
        public void GoToUrl(string Url)
        {
            driver.Navigate().GoToUrl(Url);
            Screenshot navigate = (driver as ITakesScreenshot).GetScreenshot();
            navigate.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\01 Navigation to localhost.png");

        }
        #endregion goto url

        #region Join
        public void JoinButton()
        {
            //Click on join button
            joinButton.Click();
        }


        public void JoinActions(string FirstName, string LastName, string EmailAddress, string Password, string ConfirmPassword)
        {

            //Enter first name            
            firstName.Click();
            firstName.SendKeys(FirstName);

            //Enter last name            
            lastName.Click();
            lastName.SendKeys(LastName);

            //Enter email address            
            emailAddress.Click();
            emailAddress.SendKeys(EmailAddress);

            //Enter password            
            password.Click();
            password.SendKeys(Password);

            //Enter confirm password
            confirmPassword.Click();
            confirmPassword.SendKeys(ConfirmPassword);

            //I agree check box click            
            termsConditions.Click();

            //Click on join button
            joinButton2.Click();

            //Implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //If email address exist text appears
            if (emailAddressText.Text == "This email has already been used to register an account.")
            {
                //Click on login link text
                loginLinkText.Click();
            }
            Screenshot joinedIn = (driver as ITakesScreenshot).GetScreenshot();
            joinedIn.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\02 Join completed.png");

        }
        #endregion Join

        #region Login
        public void LoginActions(string EmailAddress, string Password)
        {
            ////Click on sign in button
            //signInButton.Click();

            ////Implicit and explicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Wait.WaitToBeExists(driver, "Name", "email", 20);

            //enter email address            
            loginEmail.Click();
            loginEmail.SendKeys(EmailAddress);

            //enter password           
            loginPassword.Click();
            loginPassword.SendKeys(Password);

            //remember me checkbox            
            rememberMe.Click();

            //login button            
            loginButton.Click();

            //Implicit and explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement loginSuccessText = wait.Until(e => e.FindElement(By.XPath("//*[(text()=\"Bandula\")]")));
            Assert.That(loginSuccessText.Text == "Hi Bandula", "Login is unsuccessful");
            Console.WriteLine(loginSuccessText.Text + ", your login is successful.");

            Screenshot signedIn = (driver as ITakesScreenshot).GetScreenshot();
            signedIn.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\03 Signed in to homepage.png");
        }
        #endregion login
    }
}