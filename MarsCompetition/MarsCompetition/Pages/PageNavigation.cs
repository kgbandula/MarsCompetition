using MarsCompetition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MarsCompetition.Pages
{
    public class PageNavigation : CommonDriver
    {
        //public IWebDriver driver;
        //public PageNavigation()
        //{
        //    PageFactory.InitElements(driver, this);
        //}
        public void GoToShareSkillPage()
        {            
            //Navigate to share skill page            
            navigateToShareSkill.Click();

            //page navigation assertion
            Assert.That(title.Text == "Title", "Navigation to share skill is not successful.");
            if (title.Text == "Title")
            {
                Console.WriteLine("Navigation to Share skill is successful.");
            }
            Screenshot goToManagelistings = (driver as ITakesScreenshot).GetScreenshot();
            goToManagelistings.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\04 Navigate to share skill page.png");

        }
        public void GoToManageListingsPage()
        {
            //Navigate to manage listings page            
            navigateToManageListings.Click();

            //page navigation assertion
            Assert.That(imageText.Text == "Image", "Navigation to managelistings is not successful.");
            if (imageText.Text == "Image")
            {
                Console.WriteLine("Navigation to managelistings is successful."); 
            } 
            Screenshot goToManagelistings = (driver as ITakesScreenshot).GetScreenshot();
            goToManagelistings.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\07 Navigated to manage listings.png");
        }

        //Title explain            
        private static IWebElement title => driver.FindElement(By.XPath("//*[text()='Title']"));
        
        //Goto Share Skill page
        //[FindsBy(How= How.XPath, Using = "//a[text()='Share Skill']")]
        //private IWebElement navigateToShareSkill { get; set; }
        private IWebElement navigateToShareSkill => driver.FindElement(By.XPath("//a[text()='Share Skill']"));

        //Find image text
        private static IWebElement imageText = driver.FindElement(By.XPath("//th[text()='Image']"));


        //Goto manage listings page
        //[FindsBy(How = How.XPath, Using = "//a[text()='Manage Listings']")]
        //private IWebElement navigateToManageListings { get; set; }
        private IWebElement navigateToManageListings => driver.FindElement(By.XPath("//a[text()='Manage Listings']"));

    }
}
