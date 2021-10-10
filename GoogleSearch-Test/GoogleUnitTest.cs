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

        /** 
         * Título da página esperado: CONCERT Technologies - Pesquisa Google
         * Caso a pesquisa ocorra de forma correta o título da página deverá contar por padrão
         * um título com o texto especificado no Assert.IsTrue.
         */
        [Test]
        public void BarraDePesquisaTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies"); //Definindo conteúdo da barra de pesquisa
            Driver.FindElement(By.Name("q")).Submit(); //Enviando comando para efetuar a busca

            Assert.IsTrue(Driver.Title.Equals("CONCERT Technologies - Pesquisa Google"));
        }

        /** 
          * A URL esperada: Não é a URL do Google
          * Uma vez que após fazer a pesquisa e selecionar uma das opções da lista
          * que aparece depois de digitar, deve ser redirecionado para a página
          * de pesquisa do item escolhido.
          */
        [Test]
        public void BarraDePesquisaListTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("selenium webdriver");
            System.Threading.Thread.Sleep(10000); //Espera para garatir carregamento da página
            Random rndElementoAClicar = new Random(); 
            int index = rndElementoAClicar.Next(0, 9); //Definindo intervalo para seleção de número aleatório a ser escolhido da lista
            
            IList<IWebElement> SearchList = Driver.FindElements(By.XPath("//*[@class='sbct']"));
            
            SearchList[index].Click();

            Assert.IsTrue(!Driver.Url.Equals("https://google.com"));
        }


        /** 
         * Título da página esperado: Google
         * Clicando no botão de Pesquisar sem que se digite nada
         * no campo de pesquisa do Google, a página não deve ser
         * alterada e se manter no Google.
        */
        [Test]
        public void BarraDePesquisaEmptyTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("");
            IWebElement PesquisaBtn = Driver.FindElements(By.Name("btnK"))[1]; //Existem 2 botões na tela
            System.Threading.Thread.Sleep(2000);
            PesquisaBtn.Click();
            
            Assert.IsTrue(Driver.Title.Equals("Google"));
        }


        /** 
         * Título da página esperado: CONCERT Technologies - Pesquisa Google
         * Caso a pesquisa ocorra de forma correta o título da página deverá contar por padrão
         * um título com o texto especificado.
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
        * Título da página esperado: Google
        * Caso a navegação por páginas seja feita de forma correta, é necessário que
        * todos os links sejam alterados e acessados, mas no final o título deve ser
        * o mesmo da página inicial.
        */
        [Test]
        public void TodosLinksTest()
        {
            int qtdLinks = Driver.FindElements(By.TagName("a")).Count();
            
            for (int i = 0; i < qtdLinks; i++)
            {
                if (!Driver.FindElements(By.TagName("a"))[i].Text.Equals("")){ //Evitando entrada em links que não alteram a página
                    Driver.FindElements(By.TagName("a"))[i].Click();
                    System.Threading.Thread.Sleep(2000);
                    Driver.Navigate().Back(); //Voltando para a página inicial do Google
                }
            }

            Assert.IsTrue(Driver.Title.Equals("Google"));
        }

        /** 
         * Título da página esperado: Google Doodles
         * Após clicar no botão de Estou com Sorte sem nada escrito
         * na pesquisa, por padrão o Google direciona o usuário para
         * a página do Google Doodles.
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
         * Url da página esperado: https://www.linkedin.com/company/concertsa
         * Caso a pesquisa seja feita de forma adequada e o botão Estou com Sorte
         * seja apertado, a página a ser acessada é o Linkedin da Concert, pois
         * o botão de Estou com Sorte encaminha para a primeira página da pesquisa
         * quando é clicado junto de uma pesquisa
         */
        [Test]
        public void PesquisaEstouComSorteTest()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies");
            IWebElement EstouComSorteBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnI"))); //Esperando até que o botão seja "clicável"

            System.Threading.Thread.Sleep(2000);

            EstouComSorteBtn.Click();

            Assert.IsTrue(Driver.Url.Equals("https://www.linkedin.com/company/concertsa"));
        }
    }
}