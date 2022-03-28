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

namespace MusicRecordsUITest;
[TestClass]
public class Tests
{
    private static readonly string DriverDirectory = "/Users/malthethomsen/Downloads";
    private static IWebDriver _driver;

    [ClassInitialize]
    public static void Setup()
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
    }
    
    
}