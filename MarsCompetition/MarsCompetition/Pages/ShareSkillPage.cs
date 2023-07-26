using MarsCompetition.Utilities;
using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.PageObjects;

namespace MarsCompetition.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        #region shareskill web elements            
        private static IWebElement titleText => driver.FindElement(By.Name("title"));
        private static IWebElement descriptionText => driver.FindElement(By.Name("description"));
        private IWebElement categoryDropdown => driver.FindElement(By.Name("categoryId"));
        private IWebElement subCategoryDropdown => driver.FindElement(By.Name("subcategoryId"));
        private IWebElement addNewTag => driver.FindElement(By.XPath("//div[@class='form-wrapper field  ']//input[@aria-label='Add new tag']"));
        private IWebElement serviceTypeHourly => driver.FindElement(By.XPath("//input[@name='serviceType'and@value='0']"));
        private IWebElement serviceTypeOneOff => driver.FindElement(By.Name("serviceType"));
        private IWebElement locationTypeOnSite => driver.FindElement(By.XPath("//input[@name='locationType'and@value='0']"));
        private IWebElement locationTypeOnline => driver.FindElement(By.XPath("//input[@name='locationType'and@value='1']"));
        private IWebElement startDate => driver.FindElement(By.Name("startDate"));
        private IWebElement endDate => driver.FindElement(By.Name("endDate"));
        private IWebElement dateSun => driver.FindElement(By.XPath("//input[@index='0'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private IWebElement startTimeSun => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='0']"));
        private IWebElement endTimeSun => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='0']"));
        private IWebElement dateMon => driver.FindElement(By.XPath("//input[@index='1'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private IWebElement startTimeMon => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='1']"));
        private IWebElement endTimeMon => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='1']"));
        private IWebElement dateTue => driver.FindElement(By.XPath("//input[@index='2'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private IWebElement startTimeTue => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='2']"));
        private IWebElement endTimeTue => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='2']"));
        private IWebElement dateWed => driver.FindElement(By.XPath("//input[@index='3'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private IWebElement startTimeWed => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='3']"));
        private IWebElement endTimeWed => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='3']"));
        private IWebElement dateThu => driver.FindElement(By.XPath("//input[@index='4'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private IWebElement startTimeThu => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='4']"));
        private IWebElement endTimeThu => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='4']"));
        private IWebElement dateFri => driver.FindElement(By.XPath("//input[@index='5'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private IWebElement startTimeFri => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='5']"));
        private IWebElement endTimeFri => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='5']"));
        private IWebElement dateSat => driver.FindElement(By.XPath("//input[@index='6'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private IWebElement startTimeSat => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='6']"));
        private IWebElement endTimeSat => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='6']"));
        private IWebElement skillTradeCredit => driver.FindElement(By.XPath("//input[@name='skillTrades'and@value='false']"));
        private IWebElement creditAmount => driver.FindElement(By.XPath("//input[@name='charge'and@placeholder='Amount']"));
        private IWebElement skillTradeSkillExchange => driver.FindElement(By.XPath("//input[@name='skillTrades'and@value='true']"));
        private IWebElement addNewTag2 => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@aria-label='Add new tag']"));
        private IWebElement workSampleUpload => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
        private IWebElement activeActive => driver.FindElement(By.XPath("(//*[text()='Active'])[2]"));
        private IWebElement activeHidden => driver.FindElement(By.XPath("//*[text()='Hidden']"));
        private IWebElement saveService => driver.FindElement(By.XPath("//input[@value=\"Save\"and@type='button']"));
        private IWebElement saveShareSkillMessage => driver.FindElement(By.XPath("//*[contains(text(),'Service Listing Added successfully')]"));
        #region share skill web elements

        public void CreateShareSkill(string Title, string Description, string Category6, string SubCategory6, string TagA6 )
        {
            //Title                        
            titleText.Click();
            titleText.SendKeys(Title);

            //Description             
            descriptionText.Click();
            descriptionText.SendKeys(Description);

            //Click on category dropdown            
            //select category 1 Graphics & Design, 2 Digital Marketing, 3 Writing & Translation, 4 Video & Animation, 5 Music & Audio, 6 Programming & Tech, 7 Business, 8 Fun & Lifestyle            
            categoryDropdown.Click();
            categoryDropdown.SendKeys(Category6 + Keys.Enter);

            //subcatory selection value "1 Graphics & Design" = 1 Logo Design, 2 Book & Album covers, 3 Flyers & Brochures, 4 Web & Mobile Design, 5 Search & Display Marketing
            //subcatory selection value "2 Digital Marketing" = 1 Social Media Marketing, 2 Content Marketing, 3 Video Marketing, 4 Email Marketing, 5 Search & Display Marketing
            //subcatory selection value "3 Writing & Translation" = 1 Resumes & Cover Letters, 2 Proof Reading & Editing, 3 Translation, 4 Creative Writing, 5 Business Copywriting
            //subcatory selection value "4 Video & Animation" = 1 Promotional Videos, 2 Editing & Post Production, 3 Lyric & Music Videos, 4 Other 
            //subcatory selection value "5 Music & Audio" = 1 Mixing & Mastering, 2 Voice Over, 3 Song Writers & Composers, 4 Other
            //subcatory selection value "6 Programming & Tech" = 1 WordPress, 2 Web & Mobile App, 3 Data Analysis & Reports, 4 QA, 5 Databases, 6 Other
            //subcatory selection value "7 Business" = 1 Business Tips, 2 Presentations, 3 Market Advice, 4 Legal Consulting, 5 Financial Consulting, 6 Other
            //subcatory selection value "8 Fun & Lifestyle" = 1 Online Lessons, 2 Relationship Advice, 3 Astrology, 4 Health, Nutrition & Fitness, 5 Gaming, 6 Other           
            subCategoryDropdown.SendKeys(SubCategory6 + Keys.Enter);

            //Add a new tag
            addNewTag.Click();
            addNewTag.SendKeys(TagA6 + Keys.Enter);
        }       
        public void SelectServiceType(String ServiceType)
        {
            //service type 
            //service Type one-off
            //serviceTypeOneOff.Click();
            if (ServiceType == "Hourly basis service")
            {
                //service Type hourly
                serviceTypeHourly.Click();
            }
            else 
            {
                //service Type one-off
                serviceTypeOneOff.Click();
            }
        }
        public void SelectLocationType(string LocationType)
        {
            //location type              

            //locationTypeOnSite.Click();
            if (LocationType == "On-site")
            {
                //Location type on-site
                locationTypeOnSite.Click();                
            }
            else
            {
                //Location type on-line
                locationTypeOnline.Click();
            }
        }        
        public void StartDate(string StartDate)
        {
            startDate.Click();
            if (startDate != null)
            {
                //start date                
                startDate.SendKeys(StartDate);
            }        
        }
         public void EndDate(string EndDate) 
        {
            endDate.Click();
            if (endDate != null)
            {
                //end date                      
                endDate.SendKeys(EndDate);
            }
        }
        public void SelectSunday(string Day, string StartTime, string EndTime)
        {            
            if (Day == "Sunday")
            {
                //select Day             
                dateSun.Click();
                //Time start
                startTimeSun.Click();
                startTimeSun.SendKeys(StartTime);
                //Time end                
                endTimeSun.Click();
                endTimeSun.SendKeys(EndTime);                               
            }            
        }
        public void SelectMonday(string Day, string StartTime, string EndTime)
        {
            if (Day == "Monday")
            {
                //select Day             
                dateMon.Click();
                //Time start
                startTimeMon.Click();
                startTimeMon.SendKeys(StartTime);
                //Time end                
                endTimeMon.Click();
                endTimeMon.SendKeys(EndTime);
            }
        }
        public void SelectTuesday(string Day, string StartTime, string EndTime)
        {
            if (Day == "Tuesday")
            {
                //select Day             
                dateTue.Click();
                //Time start
                startTimeTue.Click();
                startTimeTue.SendKeys(StartTime);
                //Time end                
                endTimeTue.Click();
                endTimeTue.SendKeys(EndTime);
            }
        }
        public void SelectWednesday(string Day, string StartTime, string EndTime)
        {
            if (Day == "Wednesday")
            {
                //select Day             
                dateWed.Click();
                //Time start
                startTimeWed.Click();
                startTimeWed.SendKeys(StartTime);
                //Time end                
                endTimeWed.Click();
                endTimeWed.SendKeys(EndTime);

            }
        }
        public void SelectThursday(string Day, string StartTime, string EndTime)
        {
            if (Day == "Thursday")
            {
                //select Day             
                dateThu.Click();
                //Time start
                startTimeThu.Click();
                startTimeThu.SendKeys(StartTime);
                //Time end                
                endTimeThu.Click();
                endTimeThu.SendKeys(EndTime);

            }
        }
        public void SelectFriday(string Day, string StartTime, string EndTime)
        {
            if (Day == "Friday")
            {
                //select Day             
                dateFri.Click();
                //Time start
                startTimeFri.Click();
                startTimeFri.SendKeys(StartTime);
                //Time end                
                endTimeFri.Click();
                endTimeFri.SendKeys(EndTime);

            }
        }
        public void SelectSaturday(string Day, string StartTime, string EndTime)
        {
            if (Day == "Saturday")
            {
                //select Day             
                dateSat.Click();
                //Time start
                startTimeSat.Click();
                startTimeSat.SendKeys(StartTime);
                //Time end                
                endTimeSat.Click();
                endTimeSat.SendKeys(EndTime);

            }
        }
        public void SkillTrade(string SkillTrade, string Credit, string SkillExchange)
        {
            
            if (SkillTrade== "Credit")
            {
                //Select skill trade Credit
                skillTradeCredit.Click();
                //Enter credit amount
                creditAmount.Click();
                creditAmount.Clear();
                creditAmount.SendKeys(Credit);
            }
            else
            {
                //Select skill trade skill exchange
                skillTradeSkillExchange.Click();
                addNewTag2.Click();
                addNewTag2.SendKeys(SkillExchange + Keys.Enter);
            }
        }
        public void WorkSampleUpload()
        {
            //Work sample file upload
            workSampleUpload.Click();            
            Process.Start(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Upload\TreeUpload.exe");
            Thread.Sleep(5000);
            //Implicit and explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement activeActive = wait.Until(e => e.FindElement(By.XPath("//*[text()='Hidden']")));

            Screenshot workSample = (driver as ITakesScreenshot).GetScreenshot();
            workSample.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\05 Share skill work sample uploaded.png");

        }
        public void SelectActiveStatus(string ActiveStatus)
        {                        
            //Active type hidden
            //activeHidden.Click();
            if (ActiveStatus == "Hidden")
            {
                //Active type hidden
                activeHidden.Click();
                //Active type active
                //activeActive.Click();
            }           
        }
        public void SaveShareSkill()
        {
            //Save the service
            saveService.Click();
           
            if (saveShareSkillMessage.Text == "Service Listing Added successfully")
            {
                //Assert.That(saveShareSkillMessage.Text == "Service Listing Added successfully", "Adding share skill is unsuccessful.");
                Console.WriteLine(saveShareSkillMessage.Text);
            }          
            Screenshot saveSkill = (driver as ITakesScreenshot).GetScreenshot();
            saveSkill.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\06 Share skill saved.png");
        }
        public string ValidateCreateShareSkill()
        {           
            //validate create share skill
            return saveShareSkillMessage.Text;            
        }        
        
    }
}
