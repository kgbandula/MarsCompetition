using MarsCompetition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace MarsCompetition.Pages
{
    public class ManageListingPage : CommonDriver
    {
        #region Search skill  request
        private static IWebElement searchSkillTextBox => driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[1]"));
        private static IWebElement selectSkill => driver.FindElement(By.XPath("(//p[contains(text(),'Manual Testing')])[1]"));
        private static IWebElement writeRequest => driver.FindElement(By.XPath("//textarea[@placeholder='I am interested in trading my cooking skills with your coding skills..']"));
        private static IWebElement requestButton => driver.FindElement(By.XPath("//i[@class='send outline icon']"));
        private static IWebElement tradeRequestYes => driver.FindElement(By.XPath("//button[contains(text(),'Yes')]"));
        private static IWebElement requestSentMessage => driver.FindElement(By.XPath("//*[contains(text(),'Request sent')]"));
        #endregion Search skill request

        #region WebElementManagelistingsEdit
        private static IWebElement homePageManageListings => driver.FindElement(By.XPath("//a[text()='Manage Listings']"));
        private static IWebElement manageListingEditFirstIcon => driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));
        private static IWebElement titleText => driver.FindElement(By.Name("title"));
        private static IWebElement descriptionText => driver.FindElement(By.Name("description"));        
        private static IWebElement categoryDropdown => driver.FindElement(By.Name("categoryId"));
        private static IWebElement subCategoryDropdown => driver.FindElement(By.Name("subcategoryId"));
        private static IWebElement deleteTag => driver.FindElement(By.XPath("(//a[@class='ReactTags__remove'])[1]"));
        private static IWebElement addNewTag => driver.FindElement(By.XPath("//div[@class='form-wrapper field  ']//input[@aria-label='Add new tag']"));
        private static IWebElement serviceTypeHourly => driver.FindElement(By.XPath("//input[@name='serviceType'and@value='0']"));
        private static IWebElement serviceTypeOneOff => driver.FindElement(By.XPath("//input[@name='serviceType'and@value='1']"));
        private static IWebElement locationTypeOnSite => driver.FindElement(By.XPath("//input[@name='locationType'and@value='0']"));
        private static IWebElement locationTypeOnline => driver.FindElement(By.XPath("//input[@name='locationType'and@value='1']"));
        private static IWebElement startDate => driver.FindElement(By.Name("startDate"));
        private static IWebElement endDate => driver.FindElement(By.Name("endDate"));
        private static IWebElement dateSun => driver.FindElement(By.XPath("//input[@index='0'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private static IWebElement startTimeSun => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='0']"));
        private static IWebElement endTimeSun => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='0']"));
        private static IWebElement dateMon => driver.FindElement(By.XPath("//input[@index='1'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private static IWebElement startTimeMon => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='1']"));
        private static IWebElement endTimeMon => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='1']"));
        private static IWebElement dateTue => driver.FindElement(By.XPath("//input[@index='2'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private static IWebElement startTimeTue => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='2']"));
        private static IWebElement endTimeTue => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='2']"));
        private static IWebElement dateWed => driver.FindElement(By.XPath("//input[@index='3'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private static IWebElement startTimeWed => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='3']"));
        private static IWebElement endTimeWed => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='3']"));
        private static IWebElement dateThu => driver.FindElement(By.XPath("//input[@index='4'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private static IWebElement startTimeThu => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='4']"));
        private static IWebElement endTimeThu => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='4']"));
        private static IWebElement dateFri => driver.FindElement(By.XPath("//input[@index='5'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private static IWebElement startTimeFri => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='5']"));
        private static IWebElement endTimeFri => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='5']"));
        private static IWebElement dateSat => driver.FindElement(By.XPath("//input[@index='6'and@tabindex='0'and@name='Available'and@type='checkbox']"));
        private static IWebElement startTimeSat => driver.FindElement(By.XPath("//input[@name='StartTime'and@placeholder='Start time'and@index='6']"));
        private static IWebElement endTimeSat => driver.FindElement(By.XPath("//input[@name='EndTime'and@placeholder='End time'and@index='6']"));
        private static IWebElement skillTradeCredit => driver.FindElement(By.XPath("//input[@name='skillTrades'and@value='false']"));
        private static IWebElement creditAmount => driver.FindElement(By.XPath("//input[@name='charge'and@placeholder='Amount']"));
        private static IWebElement skillTradeSkillExchange => driver.FindElement(By.XPath("//input[@name='skillTrades'and@value='true']"));
        private static IWebElement addNewTag2 => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@aria-label='Add new tag']"));
        private static IWebElement workSampleUpload => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
        private static IWebElement activeActive => driver.FindElement(By.XPath("//input[@name=\"isActive\"and@value=\"true\"]"));
        private static IWebElement activeHidden => driver.FindElement(By.XPath("//input[@name=\"isActive\"and@value=\"false\"]"));
        private static IWebElement saveEditedShareSkill => driver.FindElement(By.XPath("//input[@value=\"Save\"and@type='button']"));
        private static IWebElement editedShareSkillMessage => driver.FindElement(By.XPath("//*[contains(text(),'Service Listing Updated successfully')]"));
        #endregion ManageListingEdit

        #region Delete share skill web elements
        private static IWebElement removeManageListing => driver.FindElement(By.XPath("(//i[@class='remove icon'])[1]"));
        private static IWebElement confirmationYes => driver.FindElement(By.XPath("(//button[@class='ui icon positive right labeled button'])[1]"));
        private static IWebElement deleteShareSkillMessage => driver.FindElement(By.XPath("//*[contains(text(),'has been deleted')]"));
        #endregion Delete share skill web element

        #region Edit Manage Listings
        public void EditIconClick()
        {
            //Click on First edit icon
            manageListingEditFirstIcon.Click();
        }
        public void EditShareSkill(string Title, string Description, string Category4, string SubCategory4, string TagA4)
        {
            //Title                        
            titleText.Click();
            titleText.Clear();
            titleText.SendKeys(Title);

            //Description             
            descriptionText.Click();
            descriptionText.Clear();
            descriptionText.SendKeys(Description);

            //Click on category dropdown            
            //select category 1 Graphics & Design, 2 Digital Marketing, 3 Writing & Translation, 4 Video & Animation, 5 Music & Audio, 6 Programming & Tech, 7 Business, 8 Fun & Lifestyle            
            categoryDropdown.Click();

            categoryDropdown.SendKeys(Category4 + Keys.Enter);

            //subcatory selection value "1 Graphics & Design" = 1 Logo Design, 2 Book & Album covers, 3 Flyers & Brochures, 4 Web & Mobile Design, 5 Search & Display Marketing
            //subcatory selection value "2 Digital Marketing" = 1 Social Media Marketing, 2 Content Marketing, 3 Video Marketing, 4 Email Marketing, 5 Search & Display Marketing
            //subcatory selection value "3 Writing & Translation" = 1 Resumes & Cover Letters, 2 Proof Reading & Editing, 3 Translation, 4 Creative Writing, 5 Business Copywriting
            //subcatory selection value "4 Video & Animation" = 1 Promotional Videos, 2 Editing & Post Production, 3 Lyric & Music Videos, 4 Other 
            //subcatory selection value "5 Music & Audio" = 1 Mixing & Mastering, 2 Voice Over, 3 Song Writers & Composers, 4 Other
            //subcatory selection value "6 Programming & Tech" = 1 WordPress, 2 Web & Mobile App, 3 Data Analysis & Reports, 4 QA, 5 Databases, 6 Other
            //subcatory selection value "7 Business" = 1 Business Tips, 2 Presentations, 3 Market Advice, 4 Legal Consulting, 5 Financial Consulting, 6 Other
            //subcatory selection value "8 Fun & Lifestyle" = 1 Online Lessons, 2 Relationship Advice, 3 Astrology, 4 Health, Nutrition & Fitness, 5 Gaming, 6 Other           
            subCategoryDropdown.SendKeys(SubCategory4 + Keys.Enter);

            //Add a new tag                        
            addNewTag.Click();
            addNewTag.SendKeys(TagA4 + Keys.Enter);
            deleteTag.Click();
            Thread.Sleep(1000);
        }
        public void SelectServiceType(string ServiceType)
        {            
            if (ServiceType == "One-off service")
            {
                //Service type one-off
                serviceTypeOneOff.Click();
            }
            else
            {
                //service Type hourly
                serviceTypeHourly.Click();
            }
        }
        public void SelectLocationType(string LocationType)
        {            
            if (LocationType == "Online")
            {
                //Location type on-line
                locationTypeOnline.Click();
            }
            else
            {
                //Location type on-site
                locationTypeOnSite.Click();
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
                ////select Day             
                //dateSun.Click();
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
                ////select Day             
                //dateMon.Click();
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
                ////select Day             
                //dateTue.Click();
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
                ////select Day             
                //dateWed.Click();
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
                ////select Day             
                //dateThu.Click();
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
                ////select Day             
                //dateFri.Click();
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
                ////select Day             
                //dateSat.Click();
                //Time start
                startTimeSat.Click();
                startTimeSat.SendKeys(StartTime);
                //Time end                
                endTimeSat.Click();
                endTimeSat.SendKeys(EndTime);
            }
        }
        public void SkillTrade(string SkillTrade,  string SkillExchange)
        {
            //Select skill trade Credit
            //skillTradeSkillExchange.Click(); ;
            if (SkillTrade == "Skill-exchange")
            {
                //Select skill trade skill exchange
                skillTradeSkillExchange.Click();
                addNewTag2.Click();
                addNewTag2.SendKeys(SkillExchange + Keys.Enter);                
            }
            else
            {
                //Enter credit amount
                creditAmount.Click();
                creditAmount.Clear();
                creditAmount.SendKeys("4");
            }
        }
        public void WorkSampleUpload()
        {
            //Work sample file upload
            workSampleUpload.Click();            
            Process.Start(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Upload\DogUpload.exe");
            Thread.Sleep(5000);
            Screenshot editedWorkSampleManagelistings = (driver as ITakesScreenshot).GetScreenshot();
            editedWorkSampleManagelistings.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\08 Edited work sample.png");


        }
        public void SelectActiveStatus(string ActiveStatus)
        {
            //Active type              
            //Active type hidden
            //activeHidden.Click();
            if (ActiveStatus == "Hidden")
            {
                ////Active type hidden                
                activeHidden.Click();
                ////Active type active
                //activeActive.Click();
            }
        }
        public void SavingEditedShareSkill()
        {            
            //Save the service
            saveEditedShareSkill.Click();  
        }

        public string validateEditManageListing()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement editedShareSkillMessage = wait.Until(e => e.FindElement(By.XPath("//*[contains(text(),'Service Listing Updated successfully')]")));

            if (editedShareSkillMessage.Text == "Service Listing Updated successfully")
            {
                Assert.That(editedShareSkillMessage.Text == "Service Listing Updated successfully", "Editing share skill is unsuccessful.");
                Console.WriteLine(editedShareSkillMessage.Text);
            }
            Screenshot saveEditedManagelistings = (driver as ITakesScreenshot).GetScreenshot();
            saveEditedManagelistings.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\09 Edited manage listing saved.png");
            
            //validate edit manage listings
            return editedShareSkillMessage.Text;
        }
        #endregion



        #region Remove Share skill
        //Remove Share Skill
        public void RemoveManageListing()
        {            
            //Remove manage listings
            removeManageListing.Click();            
        }
        public void ConfirmDelete()
        {            
            //Confirm share skill deletion
            confirmationYes.Click();
           
            if (deleteShareSkillMessage.Text == "has been deleted")
            {
                Assert.That(deleteShareSkillMessage.Text == "has been deleted", " Removing manage listing is unsuccessful.");
                Console.WriteLine(deleteShareSkillMessage.Text);
            }
            Screenshot manageListingsDeletion = (driver as ITakesScreenshot).GetScreenshot();
            manageListingsDeletion.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\12 Manage listings deletion.png");

        }
        public string ValidateDeletion()
        {            
            return deleteShareSkillMessage.Text;
        }
        #endregion Remove Share skill


        #region Create Requests
        //Create Requests
        public void skillSearchManageListings(string SearchText)
        {
            //Search on skill
            searchSkillTextBox.Click();
            searchSkillTextBox.SendKeys(SearchText + Keys.Enter);           
        }
       
        public void ComposeRequest(string WriteRequest)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //select skill manual testing
            selectSkill.Click();
            //Send a request
            writeRequest.Click();
            writeRequest.SendKeys(WriteRequest);
            Screenshot ComposeRequest = (driver as ITakesScreenshot).GetScreenshot();
            ComposeRequest.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\10 Compose Request.png");

        }
        public void ClickOnRequestButton()
        {
            //Request button click
            requestButton.Click();
        }
        public void ConfirmTradeReques()
        {
            //Confirmation yes
            tradeRequestYes.Click();
            if (requestSentMessage.Text == "Request sent")
            {
                Assert.That(requestSentMessage.Text == "Request sent", " Request sent was not successful");
                Console.WriteLine("Request sent successfully. ");
            }
            Screenshot tradeRequest = (driver as ITakesScreenshot).GetScreenshot();
            tradeRequest.SaveAsFile(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Report\Screenshots\11 TradeRequest.png");

        }
        //validate request sent
        public string validateRequestSent()
        {

            return requestSentMessage.Text;
        }
        #endregion Create requests

       
    }
}

