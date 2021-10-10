using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace GoogleSearch_Test
{
    public class Tests
    {
       
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(); //Definindo Chrome como driver para testes
            Driver.Navigate().GoToUrl("https://google.com"); //Acessando página do Google como padrão para os testes
        }

        [Test]
        public void BarraDePesquisaTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies"); //Definindo conteúdo da barra de pesquisa
            Driver.FindElement(By.Name("q")).Submit(); //Enviando comando para efetuar a busca

            /** 
             * Título da página esperado: CONCERT Technologies - Pesquisa Google
             * Caso a pesquisa ocorra de forma correta o título da página deverá contar por padrão
             * um título com o texto especificado.
             */
            Assert.IsTrue(Driver.Title.Equals("CONCERT Technologies - Pesquisa Google"));
        }

        [Test]
        public void PesquisaBtnTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies"); //Definindo conteúdo da barra de pesquisa
            IWebElement PesquisaBtn = Driver.FindElement(By.Name("btnK")); //Enviando comando para efetuar a busca
            System.Threading.Thread.Sleep(2000); //Espera para carregamento da página ocorrer por completo
            PesquisaBtn.Click(); //Clique no botão de Pesquisar

            /** 
             * Título da página esperado: CONCERT Technologies - Pesquisa Google
             * Caso a pesquisa ocorra de forma correta o título da página deverá contar por padrão
             * um título com o texto especificado.
             */
            Assert.IsTrue(Driver.Title.Equals("CONCERT Technologies - Pesquisa Google"));
        }

        [Test]
        public void TodosLinksTest()
        {
            int size = Driver.FindElements(By.TagName("a")).Count(); //Contando quantidade de links presentes na página
            
            for (int i = 0; i < size; i++) //Repetição para percorrer por todos os links da página
            {
                if (!Driver.FindElements(By.TagName("a"))[i].Text.Equals("")){ //Evitando entrada em links que não alteram a página
                    Driver.FindElements(By.TagName("a"))[i].Click();
                    System.Threading.Thread.Sleep(2000);
                    Driver.Navigate().Back(); //Voltando para a página inicial do Google
                }
            }

            /** 
             * Título da página esperado: Google
             * Caso a navegação por páginas seja feita de forma correta, é necessário que
             * todos os links sejam alterados e acessados, mas no final o título deve ser
             * o mesmo da página inicial.
             */
            Assert.IsTrue(Driver.Title.Equals("Google"));
        }

        [Test]
        public void EstouComSorteBtnTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("");
            IWebElement EstouComSorteBtn = Driver.FindElement(By.Name("btnI"));
            System.Threading.Thread.Sleep(2000);
            EstouComSorteBtn.Click();

            Assert.IsTrue(Driver.Title.Equals("Google Doodles"));
        }
    }
}