using MarsCompetition.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarsCompetition.Utilities
{
    public class CommonDriver
    {
        //driver = new ChromeDriver();
        
        public static IWebDriver driver;        
        [SetUp]
        public void JoinActions()
        {

            JoinPage joinPageObj = new JoinPage();
            joinPageObj.JoinActions(driver);
        }


        [SetUp]
        public void LoginActions()
        {

            //login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }    
                
        public void ProfileActions()
        {
            //Profile page object intiatlitation and definition
            ProfilePage profilePageObj = new ProfilePage();
            profilePageObj.ProfileActions(driver);
        }
        public static void Main() 
        { 
            
        }
    }
}







