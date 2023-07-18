using MarsCompetition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MarsCompetition.Pages
{
    public class WebSite: CommonDriver
    {
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
            Wait.WaitToBeExists(driver, "Name", "email",  20);

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

        //Identify join button
        //[FindsBy(How = How.XPath, Using = "//button[text()='Join']")]
        //private IWebElement joinButton { get; set; }
        private IWebElement joinButton => driver.FindElement(By.XPath("//button[text()='Join']"));

        ////Identify first name textbox
        //[FindsBy(How = How.Name, Using = "firstName")]
        //private IWebElement firstName { get; set; }
        private IWebElement firstName => driver.FindElement(By.Name("firstName"));

        //Identify last name textbox
        //[FindsBy(How = How.Name, Using = "lastName")]
        //private IWebElement lastName { get; set; }
        private IWebElement lastName => driver.FindElement(By.Name("lastName"));

        //Identify email address textbox 
        //[FindsBy(How = How.Name, Using = "email")]
        //private IWebElement emailAddress { get; set; }
        private IWebElement emailAddress => driver.FindElement(By.Name("email"));

        //Identify password textbox and enter password        
        //[FindsBy(How = How.Name, Using = "password")]
        //private IWebElement password { get; set; }
        private IWebElement password => driver.FindElement(By.Name("password"));

        //Identify confirm password textbox        
        //[FindsBy(How = How.Name, Using = "confirmPassword")]
        //private IWebElement confirmPassword { get; set; }
        private IWebElement confirmPassword => driver.FindElement(By.Name("confirmPassword"));

        //Identify I agree check box         
        //[FindsBy(How = How.Name, Using = "terms")]
        //private IWebElement termsConditions { get; set; }
        private IWebElement termsConditions => driver.FindElement(By.Name("terms"));

        //Identify join button       
        //[FindsBy(How = How.Id, Using = "submit-btn")]
        //private IWebElement joinButton2 { get; set; }
        private IWebElement joinButton2 => driver.FindElement(By.Id("submit-btn"));

        //Identify email address text       
        //[FindsBy(How = How.XPath, Using = "//*[text()='This email has already been used to register an account.']")]
        //private IWebElement emailAddressText { get; set; }
        private IWebElement emailAddressText => driver.FindElement(By.XPath("//*[text()='This email has already been used to register an account.']"));

        //Identify Login link text
        //[FindsBy(How = How.XPath, Using = "//a[@class='pointerCursor']")]
        //private IWebElement loginLinkText { get; set; }
        private IWebElement loginLinkText => driver.FindElement(By.XPath("//a[@class='pointerCursor']"));




        //Find login button       
        //[FindsBy(How = How.XPath, Using = "//a[text()='Sign In']")]
        //private IWebElement signInButton { get; set; }
        private IWebElement signInButton => driver.FindElement(By.XPath("//a[text()='Sign In']"));

        //Find email address text box
        //[FindsBy(How = How.Name, Using = "email")]
        //private IWebElement loginEmail { get; set; }
        private IWebElement loginEmail => driver.FindElement(By.Name("email"));

        //Find password text box
        //[FindsBy(How = How.Name, Using = "password")]
        //private IWebElement loginPassword { get; set; }
        private IWebElement loginPassword => driver.FindElement(By.Name("password"));

        //Find remember me checkbox
        //[FindsBy(How = How.Name, Using = "rememberDetails")]
        //private IWebElement rememberMe { get; set; }
        private IWebElement rememberMe => driver.FindElement(By.Name("rememberDetails"));

        //Find login button
        //[FindsBy(How = How.XPath, Using = "//button[text()='Login']")]
        //private IWebElement loginButton { get; set; }
        private IWebElement loginButton => driver.FindElement(By.XPath("//button[text()='Login']"));

        //Login assertion
        //[FindsBy(How = How.XPath, Using = "//*[(text()=\"Bandula\")]")]
        //private IWebElement loginSuccessText { get; set; }
        private IWebElement loginSuccessText => driver.FindElement(By.XPath("//*[(text()=\"Bandula\")]"));

        //Goto share skill page
        //[FindsBy(How = How.XPath, Using = "//a[text()='Share Skill']")]
        //private IWebElement shareSkillText { get; set; }
        private IWebElement shareSkillText => driver.FindElement(By.XPath("//a[text()='Share Skill']"));

    }
}