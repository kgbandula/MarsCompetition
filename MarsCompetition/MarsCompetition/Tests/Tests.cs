using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2013.WebExtension;
using DocumentFormat.OpenXml.Wordprocessing;
using MarsCompetition.Pages;
using MarsCompetition.Utilities;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using MongoDB.Driver.Core.Operations;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.DOM;
using System.Data;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace MarsCompetition.Tests
{
    [TestFixture]
    [Parallelizable]  
    

    public class Tests : CommonDriver
    {
        ExtentReports extent = null;
        ExtentTest test = null;
       
               
        [OneTimeSetUp]
        public void ExtentStart()
        {

            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            var reportPath = projectPath + "Report\\";
            extent = new ExtentReports();
            //Directory.CreateDirectory(projectPath + "ExtentReports\\");
            ////Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var htmlReporter = new ExtentHtmlReporter(reportPath + "ExtentReports\\");
            extent.AttachReporter(htmlReporter);
        }


        
        public WebSite webSiteObj;
        public PageNavigation pageNavigationObj;
        public ShareSkillPage shareSkillPageObj;
        public ManageListingPage manageListingPageObj;
        public Tests()
        {
            //driver = new ChromeDriver();
            this.webSiteObj = new WebSite();
            this.pageNavigationObj = new PageNavigation();
            this.shareSkillPageObj = new ShareSkillPage();
            this.manageListingPageObj = new ManageListingPage();
        }
       


        [SetUp]
        public void SetUp()
        {

            try
            {
                ExtentTest test = extent.CreateTest("SetUP").Info("Test Started");

                
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                ExcelLib.PopulateInCollection(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\WebSite.xlsx", "JoinPage");
                webSiteObj.GoToUrl(ExcelLib.ReadData(1, "Url"));                             
                test.Log(Status.Pass, "Navigate to Url");
                webSiteObj.JoinButton();
                ExcelLib.PopulateInCollection(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Join.xlsx", "JoinPage");
                webSiteObj.JoinActions(ExcelLib.ReadData(1, "FirstName"), ExcelLib.ReadData(1, "LastName"), ExcelLib.ReadData(1, "EmailAddress"), ExcelLib.ReadData(1, "Password"), ExcelLib.ReadData(1, "ConfirmPassword"));
                test.Log(Status.Pass, "Signed up");                                
                //loginObj.signInButton();
                ExcelLib.PopulateInCollection(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\Login.xlsx", "LoginPage");
                webSiteObj.LoginActions(ExcelLib.ReadData(1, "EmailAddress"), ExcelLib.ReadData(1, "Password"));               
                test.Log(Status.Pass, "Signed in");
                test.Log(Status.Info, "User Signed up and Sign in completed.");
            }

            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.ToString());
                test.Log(Status.Fail, "Sign in failed");
                throw;
            }
        }        

        [Test, Order(1)]
        public void AddShareSkill()
        {
            try
            {

                ExtentTest test = extent.CreateTest("AddShareSkill").Info("Adding share skill Test Started");

                pageNavigationObj.GoToShareSkillPage();
                test.Log(Status.Pass, "Navigated to share skill.");
                ExcelLib.PopulateInCollection(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\ShareSkill.xlsx", "ShareSkillPage");
                shareSkillPageObj.CreateShareSkill(ExcelLib.ReadData(1, "Title"), ExcelLib.ReadData(1, "Description"), ExcelLib.ReadData(1, "Category6"), ExcelLib.ReadData(3, "SubCategory6"), ExcelLib.ReadData(3, "TagA6"));
                shareSkillPageObj.SelectServiceType(ExcelLib.ReadData(1, "ServiceType"));
                shareSkillPageObj.SelectLocationType(ExcelLib.ReadData(1, "LocationType"));
                shareSkillPageObj.StartDate(ExcelLib.ReadData(1, "StartDate"));
                shareSkillPageObj.EndDate(ExcelLib.ReadData(1, "EndDate"));
                shareSkillPageObj.SelectSunday(ExcelLib.ReadData(1, "Day"), ExcelLib.ReadData(1, "StartTime"), ExcelLib.ReadData(1, "EndTime"));
                shareSkillPageObj.SelectMonday(ExcelLib.ReadData(2, "Day"), ExcelLib.ReadData(2, "StartTime"), ExcelLib.ReadData(2, "EndTime"));
                shareSkillPageObj.SelectTuesday(ExcelLib.ReadData(3, "Day"), ExcelLib.ReadData(3, "StartTime"), ExcelLib.ReadData(3, "EndTime"));
                shareSkillPageObj.SelectWednesday(ExcelLib.ReadData(4, "Day"), ExcelLib.ReadData(4, "StartTime"), ExcelLib.ReadData(4, "EndTime"));
                shareSkillPageObj.SelectThursday(ExcelLib.ReadData(5, "Day"), ExcelLib.ReadData(5, "StartTime"), ExcelLib.ReadData(5, "EndTime"));
                shareSkillPageObj.SelectFriday(ExcelLib.ReadData(6, "Day"), ExcelLib.ReadData(6, "StartTime"), ExcelLib.ReadData(6, "EndTime"));
                shareSkillPageObj.SelectSaturday(ExcelLib.ReadData(7, "Day"), ExcelLib.ReadData(7, "StartTime"), ExcelLib.ReadData(7, "EndTime"));
                shareSkillPageObj.SkillTrade(ExcelLib.ReadData(1, "SkillTrade"), ExcelLib.ReadData(1, "Credit"), ExcelLib.ReadData(1, "SkillExchange"));
                shareSkillPageObj.WorkSampleUpload();
                test.Log(Status.Pass, "Work sample upload");
                shareSkillPageObj.SelectActiveStatus(ExcelLib.ReadData(1, "ActiveStatus"));
                shareSkillPageObj.SaveShareSkill();
                test.Log(Status.Pass, "Save share skill.");
                shareSkillPageObj.ValidateCreateShareSkill();                
                test.Log(Status.Pass, "Adding share skill");
                test.Log(Status.Info, "Share Skill Created");
            }

            catch (Exception ex)
            {
                //string ErrVal = ex.ToString();
                test.Log(Status.Fail, ex.ToString());
                test.Log(Status.Fail, "Adding share skill failed");
                throw;
            }
        }

        [Test, Order(2)]
        public void EditManageListings()
        {
            try
            {
                ExtentTest test = extent.CreateTest("EditManagteListings").Info("Editing manage listings started.");
                pageNavigationObj.GoToManageListingsPage();
                test.Log(Status.Pass, "Navigate to managelistings.");
                manageListingPageObj.EditIconClick();
                ExcelLib.PopulateInCollection(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\ManageListings.xlsx", "ManageListingsPage");
                manageListingPageObj.EditShareSkill(ExcelLib.ReadData(2, "Title"), ExcelLib.ReadData(2, "Description"), ExcelLib.ReadData(1, "Category4"), ExcelLib.ReadData(3, "SubCategory4"), ExcelLib.ReadData(3, "TagA4"));
                manageListingPageObj.SelectServiceType(ExcelLib.ReadData(2, "ServiceType"));
                manageListingPageObj.SelectLocationType(ExcelLib.ReadData(2, "LocationType"));
                manageListingPageObj.StartDate(ExcelLib.ReadData(2, "StartDate"));
                manageListingPageObj.EndDate(ExcelLib.ReadData(2, "EndDate"));
                manageListingPageObj.SelectSunday(ExcelLib.ReadData(1, "Day"), ExcelLib.ReadData(1, "StartTime"), ExcelLib.ReadData(1, "EndTime"));
                manageListingPageObj.SelectMonday(ExcelLib.ReadData(2, "Day"), ExcelLib.ReadData(2, "StartTime"), ExcelLib.ReadData(2, "EndTime"));
                manageListingPageObj.SelectTuesday(ExcelLib.ReadData(3, "Day"), ExcelLib.ReadData(3, "StartTime"), ExcelLib.ReadData(3, "EndTime"));
                manageListingPageObj.SelectWednesday(ExcelLib.ReadData(4, "Day"), ExcelLib.ReadData(4, "StartTime"), ExcelLib.ReadData(4, "EndTime"));
                manageListingPageObj.SelectThursday(ExcelLib.ReadData(5, "Day"), ExcelLib.ReadData(5, "StartTime"), ExcelLib.ReadData(5, "EndTime"));
                manageListingPageObj.SelectFriday(ExcelLib.ReadData(6, "Day"), ExcelLib.ReadData(6, "StartTime"), ExcelLib.ReadData(6, "EndTime"));
                manageListingPageObj.SelectSaturday(ExcelLib.ReadData(7, "Day"), ExcelLib.ReadData(7, "StartTime"), ExcelLib.ReadData(7, "EndTime"));
                manageListingPageObj.SkillTrade(ExcelLib.ReadData(2, "SkillTrade"), ExcelLib.ReadData(1, "SkillExchange"));
                manageListingPageObj.WorkSampleUpload();
                test.Log(Status.Pass, "Manage listings new work sample is uploaded.");
                manageListingPageObj.SelectActiveStatus(ExcelLib.ReadData(2, "ActiveStatus"));
                manageListingPageObj.SavingEditedShareSkill();
                test.Log(Status.Pass, "Edited manage listings is saved.");
                manageListingPageObj.validateEditManageListing();
                test.Log(Status.Pass, "Editing manage listings is passed");
                test.Log(Status.Info, "Manage listings edited");
            }
            catch (Exception ex)
            {
                //string ErrVal = ex.ToString();
                test.Log(Status.Fail, ex.ToString());
                test.Log(Status.Fail, "Edited manage listings was failed.");
                throw;
            }
        }
        
        [Test, Order(3)]
        public void SkillSearchManageListings() 
        {
            try
            {
                ExtentTest test = extent.CreateTest("SkillSearchManageListings").Info("Manage listings skill search started.");

                pageNavigationObj.GoToManageListingsPage();
                ExcelLib.PopulateInCollection(@"F:\Mars\MarsCompetition\MarsCompetition\MarsCompetition\ManageListingsRequests.xlsx", "ManageListingsRequest");
                manageListingPageObj.skillSearchManageListings(ExcelLib.ReadData(1, "SearchText"));
                manageListingPageObj.ComposeRequest(ExcelLib.ReadData(1, "WriteRequest"));
                manageListingPageObj.ClickOnRequestButton();
                manageListingPageObj.ConfirmTradeReques();
                manageListingPageObj.validateRequestSent();
                test.Log(Status.Info, "Manage listings skill searched.");
                test.Log(Status.Pass, "Skill search in manage listings passed");
            }
            catch (Exception ex)
            {                
                test.Log(Status.Fail, ex.ToString());
                test.Log(Status.Fail, "Skill search in manage listings failed.");
                throw;
            }
        }
        [Test, Order(4)]
        public void RemoveManageListings()
        {
            try
            {
                ExtentTest test = extent.CreateTest("RemoveManageListings").Info("Deleting manage listing started.");

                pageNavigationObj.GoToManageListingsPage();
                manageListingPageObj.RemoveManageListing();
                manageListingPageObj.ConfirmDelete();
                manageListingPageObj.ValidateDeletion();
                test.Log(Status.Info, "Manage listings skill deleted.");
                test.Log(Status.Pass, "Skill search in manage listings deleted.");
                
            }
            catch (Exception ex)
            {
                //string ErrVal = ex.ToString();
                test.Log(Status.Fail, ex.ToString());
                test.Log(Status.Fail, "Skill search deletion in in manage listings failed.");
                throw;
            }
        }

        [TearDown]
        public void EndTest()
        {            
            extent.Flush();
            driver.Quit();
        }

    }   

}
