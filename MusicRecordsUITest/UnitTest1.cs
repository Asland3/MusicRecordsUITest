using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace MusicRecordsUITest
{
    [TestClass]
    public class Tests
    {
        private static readonly string DriverDirectory = "C:\\WebDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod()
        {
            _driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            string title = _driver.Title;
            Assert.AreEqual("Axios", title);

            IWebElement buttonElement = _driver.FindElement(By.Id("AddData"));
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement musicList = wait.Until(p => p.FindElement(By.Id("Record list")));
            Assert.IsTrue(musicList.Text.Contains("Kim Larsen"));


        }
    }

}