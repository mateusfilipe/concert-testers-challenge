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
            Driver.Navigate().GoToUrl("https://google.com"); //Acessando p�gina do Google como padr�o para os testes
        }

        [Test]
        public void BarraDePesquisaTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies"); //Definindo conte�do da barra de pesquisa
            Driver.FindElement(By.Name("q")).Submit(); //Enviando comando para efetuar a busca

            /** 
             * T�tulo da p�gina esperado: CONCERT Technologies - Pesquisa Google
             * Caso a pesquisa ocorra de forma correta o t�tulo da p�gina dever� contar por padr�o
             * um t�tulo com o texto especificado.
             */
            Assert.IsTrue(Driver.Title.Equals("CONCERT Technologies - Pesquisa Google"));
        }

        [Test]
        public void BarraDePesquisaListTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("selenium webdriver"); //Definindo conte�do da barra de pesquisa
            System.Threading.Thread.Sleep(10000); //Espera para garatir carregamento da p�gina
            Random rndElementoAClicar = new Random(); 
            int index = rndElementoAClicar.Next(0, 9); //Definindo intervalo para sele��o de n�mero aleat�rio a ser escolhido da lista
            
            IList<IWebElement> SearchList = Driver.FindElements(By.XPath("//*[@class='sbct']")); //Buscando elemento pelo XPath
            //SearchList.Add(Driver.FindElement(By.XPath("//*[@class='sbct sbre']")));
        

            SearchList[index].Click();


            /** 
             * A URL esperada: N�o � a URL do Google
             * Uma vez que ap�s fazer a pesquisa e selecionar uma das op��es da lista
             * que aparece depois de digitar, deve ser redirecionado para a p�gina
             * de pesquisa do item escolhido.
             */
            Assert.IsTrue(!Driver.Url.Equals("https://google.com"));
        }

        [Test]
        public void PesquisaBtnTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies"); //Definindo conte�do da barra de pesquisa
            IWebElement PesquisaBtn = Driver.FindElement(By.Name("btnK")); //Enviando comando para efetuar a busca
            System.Threading.Thread.Sleep(2000); //Espera para carregamento da p�gina ocorrer por completo
            PesquisaBtn.Click(); //Clique no bot�o de Pesquisar

            /** 
             * T�tulo da p�gina esperado: CONCERT Technologies - Pesquisa Google
             * Caso a pesquisa ocorra de forma correta o t�tulo da p�gina dever� contar por padr�o
             * um t�tulo com o texto especificado.
             */
            Assert.IsTrue(Driver.Title.Equals("CONCERT Technologies - Pesquisa Google"));
        }

        [Test]
        public void TodosLinksTest()
        {
            int size = Driver.FindElements(By.TagName("a")).Count(); //Contando quantidade de links presentes na p�gina
            
            for (int i = 0; i < size; i++) //Repeti��o para percorrer por todos os links da p�gina
            {
                if (!Driver.FindElements(By.TagName("a"))[i].Text.Equals("")){ //Evitando entrada em links que n�o alteram a p�gina
                    Driver.FindElements(By.TagName("a"))[i].Click();
                    System.Threading.Thread.Sleep(2000);
                    Driver.Navigate().Back(); //Voltando para a p�gina inicial do Google
                }
            }

            /** 
             * T�tulo da p�gina esperado: Google
             * Caso a navega��o por p�ginas seja feita de forma correta, � necess�rio que
             * todos os links sejam alterados e acessados, mas no final o t�tulo deve ser
             * o mesmo da p�gina inicial.
             */
            Assert.IsTrue(Driver.Title.Equals("Google"));
        }

        [Test]
        public void EstouComSorteBtnTest()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            Driver.FindElement(By.Name("q")).SendKeys("Rice");
            System.Threading.Thread.Sleep(2000);
            IWebElement EstouComSorteBtn = Driver.FindElement(By.Name("btnI"));
            //IWebElement EstouComSorteBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnI")));

            System.Threading.Thread.Sleep(2000);
            
            EstouComSorteBtn.Click();

            Assert.IsTrue(Driver.Title.Equals("Google Doodles"));
        }

        [Test]
        public void PesquisaEstouComSorteTest()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1)); //Vari�vel de tempo de espera
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies"); //Definindo conte�do da barra de pesquisa
            IWebElement EstouComSorteBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnI"))); //Esperando at� que o bot�o seja "clic�vel"

            System.Threading.Thread.Sleep(2000); //Espera para carregamento da p�gina ocorrer por completo

            EstouComSorteBtn.Click(); //Clique no bot�o de Estou Com Sorte

            /** 
             * T�tulo da p�gina esperado: https://www.linkedin.com/company/concertsa
             * Caso a pesquisa seja feita de forma adequada e o bot�o Estou com Sorte
             * seja apertado, a p�gina a ser acessada � o Linkedin da Concert.
             */
            Assert.IsTrue(Driver.Url.Equals("https://www.linkedin.com/company/concertsa"));
        }
    }
}