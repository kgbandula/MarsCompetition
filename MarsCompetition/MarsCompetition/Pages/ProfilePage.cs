using MarsCompetition.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Pages
{
    public class ProfilePage : CommonDriver
    {
        public void ProfileActions(IWebDriver driver)
        {
            Thread.Sleep(5000);
            //click on Hi User
            IWebElement userDropdownList = driver.FindElement(By.XPath("//span[@tabindex='0']"));
            userDropdownList.Click();
            Thread.Sleep(5000);
            //Click on goto profile
            IWebElement goToProfile = driver.FindElement(By.XPath("//a[contains(text(),'Go to Profile')]"));
            goToProfile.Click();
            //Click on profile
            IWebElement profile = driver.FindElement(By.XPath("(//a[@href='/Account/Profile'])[2]"));
            profile.Click();
        }
    }
}
