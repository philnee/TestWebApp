using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Xunit.Sdk;

namespace UITests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var driver = new ChromeDriver(currentDirectory);
            
            driver.Navigate().GoToUrl("https:/localhost:44305");

            driver.FindElement(By.CssSelector("a[href='/counter']")).Click();

            Assert.Equal("Counter", driver.FindElementByTagName("h1").Text);
            
            driver.FindElementById("increment-button").Click();
            driver.FindElementById("increment-button").Click();
            driver.FindElementById("increment-button").Click();
            driver.FindElementById("increment-button").Click();
            driver.FindElementById("increment-button").Click();
            
            Assert.Equal("5", driver.FindElement(By.TagName("strong")).Text);
            
            driver.Close();
            driver.Dispose();
        }
    }
}