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
        public void BarraDePesquisaListTest()
        {
            Driver.FindElement(By.Name("q")).SendKeys("selenium webdriver"); //Definindo conteúdo da barra de pesquisa
            System.Threading.Thread.Sleep(10000); //Espera para garatir carregamento da página
            Random rndElementoAClicar = new Random(); 
            int index = rndElementoAClicar.Next(0, 9); //Definindo intervalo para seleção de número aleatório a ser escolhido da lista
            
            IList<IWebElement> SearchList = Driver.FindElements(By.XPath("//*[@class='sbct']")); //Buscando elemento pelo XPath
            //SearchList.Add(Driver.FindElement(By.XPath("//*[@class='sbct sbre']")));
        

            SearchList[index].Click();


            /** 
             * A URL esperada: Não é a URL do Google
             * Uma vez que após fazer a pesquisa e selecionar uma das opções da lista
             * que aparece depois de digitar, deve ser redirecionado para a página
             * de pesquisa do item escolhido.
             */
            Assert.IsTrue(!Driver.Url.Equals("https://google.com"));
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
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1)); //Variável de tempo de espera
            Driver.FindElement(By.Name("q")).SendKeys("CONCERT Technologies"); //Definindo conteúdo da barra de pesquisa
            IWebElement EstouComSorteBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnI"))); //Esperando até que o botão seja "clicável"

            System.Threading.Thread.Sleep(2000); //Espera para carregamento da página ocorrer por completo

            EstouComSorteBtn.Click(); //Clique no botão de Estou Com Sorte

            /** 
             * Título da página esperado: https://www.linkedin.com/company/concertsa
             * Caso a pesquisa seja feita de forma adequada e o botão Estou com Sorte
             * seja apertado, a página a ser acessada é o Linkedin da Concert.
             */
            Assert.IsTrue(Driver.Url.Equals("https://www.linkedin.com/company/concertsa"));
        }
    }
}