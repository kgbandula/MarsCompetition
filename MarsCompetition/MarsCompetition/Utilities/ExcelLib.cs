using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DocumentFormat.OpenXml.Bibliography;
using ExcelDataReader;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;

        public CommonDriver()
        {

        }

       
       
    }

    public class ExcelLib 
    {
        static List<Datacollection> dataCol = new List<Datacollection>();
        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }
        public static void ClearData()
        {
            dataCol.Clear();
        }   
        private static DataTable ExcelToDataTable(string filename, string SheetName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Open excel file
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.ReadWrite);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            
            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table[SheetName];
            return resultTable;
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                
                var data = (from colData in dataCol
                            where colData.colName == columnName && colData.rowNumber == rowNumber
                            select colData.colValue).First().ToString();

                
                return data.ToString();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }

        }

        public static string WriteData(int rowNumber, string columnName)
        {
            try
            {
                
                var data = (from colData in dataCol
                            where colData.colName == columnName && colData.rowNumber == rowNumber
                            select colData.colValue).First().ToString();
                
                return data.ToString();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }

        }

        public static void PopulateInCollection(string filename, string SheetName)
        {
            
            DataTable table = ExcelToDataTable(filename, SheetName);
            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add details for each row
                    dataCol.Add(dtTable);
                }
            }
        }

    }
    public class GetScreenShot
    {
        public static IWebDriver driver;
        ExtentTest test;

        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots\\");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;

            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;


            DateTime time = DateTime.Now;
            string fileName = "Screenshot" + time.ToString("hh_mm_ss") + ".png";

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    String screenShotPath = Capture(driver, fileName);
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
        }
    }
}
