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

        /** 
         * T�tulo da p�gina esperado: CONCERT Technologies - Pesquisa Google
         * Caso a pesquisa ocorra de forma correta o t�tulo da p�gina dever� contar por padr�o
         * um t�tulo com o texto especificado no Assert.IsTrue.
         */
        [Test]
        public void BarraDePesquisaTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies"); //Definindo conte�do da barra de pesquisa
            Driver.FindElement(By.Name("q")).Submit(); //Enviando comando para efetuar a busca

            Assert.IsTrue(Driver.Title.Equals("CONCERT Technologies - Pesquisa Google"));
        }

        /** 
          * A URL esperada: N�o � a URL do Google
          * Uma vez que ap�s fazer a pesquisa e selecionar uma das op��es da lista
          * que aparece depois de digitar, deve ser redirecionado para a p�gina
          * de pesquisa do item escolhido.
          */
        [Test]
        public void BarraDePesquisaListTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("selenium webdriver");
            System.Threading.Thread.Sleep(10000); //Espera para garatir carregamento da p�gina
            Random rndElementoAClicar = new Random(); 
            int index = rndElementoAClicar.Next(0, 9); //Definindo intervalo para sele��o de n�mero aleat�rio a ser escolhido da lista
            
            IList<IWebElement> SearchList = Driver.FindElements(By.XPath("//*[@class='sbct']"));
            
            SearchList[index].Click();

            Assert.IsTrue(!Driver.Url.Equals("https://google.com"));
        }


        /** 
         * T�tulo da p�gina esperado: Google
         * Clicando no bot�o de Pesquisar sem que se digite nada
         * no campo de pesquisa do Google, a p�gina n�o deve ser
         * alterada e se manter no Google.
        */
        [Test]
        public void BarraDePesquisaEmptyTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("");
            IWebElement PesquisaBtn = Driver.FindElements(By.Name("btnK"))[1]; //Existem 2 bot�es na tela
            System.Threading.Thread.Sleep(2000);
            PesquisaBtn.Click();
            
            Assert.IsTrue(Driver.Title.Equals("Google"));
        }


        /** 
         * T�tulo da p�gina esperado: CONCERT Technologies - Pesquisa Google
         * Caso a pesquisa ocorra de forma correta o t�tulo da p�gina dever� contar por padr�o
         * um t�tulo com o texto especificado.
         */
        [Test]
        public void PesquisaBtnTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies");
            IWebElement PesquisaBtn = Driver.FindElement(By.Name("btnK"));
            System.Threading.Thread.Sleep(2000);
            PesquisaBtn.Click();

            Assert.IsTrue(Driver.Title.Equals("CONCERT Technologies - Pesquisa Google"));
        }

        /** 
        * T�tulo da p�gina esperado: Google
        * Caso a navega��o por p�ginas seja feita de forma correta, � necess�rio que
        * todos os links sejam alterados e acessados, mas no final o t�tulo deve ser
        * o mesmo da p�gina inicial.
        */
        [Test]
        public void TodosLinksTest()
        {
            int qtdLinks = Driver.FindElements(By.TagName("a")).Count();
            
            for (int i = 0; i < qtdLinks; i++)
            {
                if (!Driver.FindElements(By.TagName("a"))[i].Text.Equals("")){ //Evitando entrada em links que n�o alteram a p�gina
                    Driver.FindElements(By.TagName("a"))[i].Click();
                    System.Threading.Thread.Sleep(2000);
                    Driver.Navigate().Back(); //Voltando para a p�gina inicial do Google
                }
            }

            Assert.IsTrue(Driver.Title.Equals("Google"));
        }

        /** 
         * T�tulo da p�gina esperado: Google Doodles
         * Ap�s clicar no bot�o de Estou com Sorte sem nada escrito
         * na pesquisa, por padr�o o Google direciona o usu�rio para
         * a p�gina do Google Doodles.
         */
        [Test]
        public void EstouComSorteBtnTest()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            Driver.FindElement(By.Name("q")).SendKeys(" ");
            System.Threading.Thread.Sleep(10000);
            IWebElement EstouComSorteBtn = Driver.FindElements(By.Name("btnI"))[1];
            //IWebElement EstouComSorteBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnI")));

            System.Threading.Thread.Sleep(2000);
            
            EstouComSorteBtn.Click();

            Assert.IsTrue(Driver.Title.Equals("Google Doodles"));
        }

        /** 
         * Url da p�gina esperado: https://www.linkedin.com/company/concertsa
         * Caso a pesquisa seja feita de forma adequada e o bot�o Estou com Sorte
         * seja apertado, a p�gina a ser acessada � o Linkedin da Concert, pois
         * o bot�o de Estou com Sorte encaminha para a primeira p�gina da pesquisa
         * quando � clicado junto de uma pesquisa
         */
        [Test]
        public void PesquisaEstouComSorteTest()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies");
            IWebElement EstouComSorteBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnI"))); //Esperando at� que o bot�o seja "clic�vel"

            System.Threading.Thread.Sleep(2000);

            EstouComSorteBtn.Click();

            Assert.IsTrue(Driver.Url.Equals("https://www.linkedin.com/company/concertsa"));
        }
    }
}