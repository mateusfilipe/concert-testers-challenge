using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

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
        public void BarraDePesquisaTest()
        {
            Driver.Navigate().GoToUrl("https://google.com");
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies");
            Driver.FindElement(By.Name("q")).Submit();

            Assert.Pass();
        }

        [Test]
        public void PesquisaBtnTest()
        {
            Driver.Navigate().GoToUrl("https://google.com");
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies");
            IWebElement PesquisaBtn = Driver.FindElement(By.Name("btnK"));
            System.Threading.Thread.Sleep(2000);
            PesquisaBtn.Click();

            Assert.Pass();
        }

        [Test]
        public void EstouComSorteBtnTest()
        {
            Driver.Navigate().GoToUrl("https://google.com");
            //Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com/");
            //Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies");
            IWebElement EstouComSorteBtn = Driver.FindElement(By.Name("btnI"));
            System.Threading.Thread.Sleep(2000);
            EstouComSorteBtn.Click();

            Assert.Pass();
        }
    }
}