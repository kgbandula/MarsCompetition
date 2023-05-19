using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsCompetition.Utilities;

namespace MarsCompetition.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        public void CreateShareSkill(IWebDriver driver)
        {
            //Share skill button
            IWebElement shareSkill = driver.FindElement(By.XPath("//a[@class='ui basic green button']"));
            shareSkill.Click();
            //Thread.Sleep(2000);

            //Title explain
            IWebElement titleTextbox = driver.FindElement(By.XPath("//input[@type='text'and@placeholder='Write a title to describe the service you provide.'and@name='title']"));
            titleTextbox.Click();
            titleTextbox.SendKeys("I am a service provider that make sure the customer satisfied by the services");

            //Description text
            IWebElement descriptionTextbox = driver.FindElement(By.XPath("//textarea[@name='description'and@maxlength='600']"));
            descriptionTextbox.Click();
            descriptionTextbox.SendKeys("I enjoy playing Cricket, Martial arts and carrom. ");
            //Thread.Sleep(2000);

            //Click on category dropdown
            var category = driver.FindElement(By.Name("categoryId"));
            //Thread.Sleep(2000);
            //select category 1 Graphics & Design, 2 Digital Marketing, 3 Writing & Translation, 4 Video & Animation, 5 Music & Audio, 6 Programming & Tech, 7 Business, 8 Fun & Lifestyle
            var selectedCategory = new SelectElement(category);
            selectedCategory.SelectByText("Music & Audio");
            //Thread.Sleep(2000);

            //subcatory selection value "1 Graphics & Design" = 1 Logo Design, 2 Book & Album covers, 3 Flyers & Brochures, 4 Web & Mobile Design, 5 Search & Display Marketing
            //subcatory selection value "2 Digital Marketing" = 1 Social Media Marketing, 2 Content Marketing, 3 Video Marketing, 4 Email Marketing, 5 Search & Display Marketing
            //subcatory selection value "3 Writing & Translation" = 1 Resumes & Cover Letters, 2 Proof Reading & Editing, 3 Translation, 4 Creative Writing, 5 Business Copywriting
            //subcatory selection value "4 Video & Animation" = 1 Promotional Videos, 2 Editing & Post Production, 3 Lyric & Music Videos, 4 Other 
            //subcatory selection value "5 Music & Audio" = 1 Mixing & Mastering, 2 Voice Over, 3 Song Writers & Composers, 4 Other
            //subcatory selection value "6 Programming & Tech" = 1 WordPress, 2 Web & Mobile App, 3 Data Analysis & Reports, 4 QA, 5 Databases, 6 Other
            //subcatory selection value "7 Business" = 1 Business Tips, 2 Presentations, 3 Market Advice, 4 Legal Consulting, 5 Financial Consulting, 6 Other
            //subcatory selection value "8 Fun & Lifestyle" = 1 Online Lessons, 2 Relationship Advice, 3 Astrology, 4 Health, Nutrition & Fitness, 5 Gaming, 6 Other
            var subCategory = driver.FindElement(By.Name("subcategoryId"));
            var selectedSubCatogory = new SelectElement(subCategory);
            selectedSubCatogory.SelectByText("Song Writers & Composers");

            IWebElement tagsAddNewTag1 = driver.FindElement(By.XPath("//div[@class='form-wrapper field  ']//input[@placeholder='Add new tag']"));
            tagsAddNewTag1.Click();
            tagsAddNewTag1.SendKeys("Meditation Composer");

        }
    }
}