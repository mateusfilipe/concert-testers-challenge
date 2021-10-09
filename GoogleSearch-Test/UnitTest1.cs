using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GoogleSearch_Test
{
    public class Tests
    {

        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setup");
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("https://google.com");

            Console.WriteLine("Test1");
            Assert.Pass();
        }
    }
}