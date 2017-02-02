using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class TesteParipassu
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://acesso.paripassu.com.br/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheEParipassuTest()
        {
            driver.Navigate().GoToUrl("https://acesso.paripassu.com.br/#/login?urlAnterior=http:%2F%2Fclicq.paripassu.com.br%2F");
            driver.FindElement(By.Id("usuario")).Clear();
            driver.FindElement(By.Id("usuario")).SendKeys("gustavosaramago@hotmail.com");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("1Qualidade");
            driver.FindElement(By.Id("submit-login")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [altKeyUp |  | ]]
            driver.FindElement(By.LinkText("Aplicação de questionário")).Click();
            driver.FindElement(By.LinkText("Nova aplicação de questionário")).Click();
            driver.FindElement(By.CssSelector("a.list-group-item")).Click();
            driver.FindElement(By.CssSelector("a.list-group-item")).Click();
            driver.FindElement(By.XPath("//textarea[@type='text']")).Clear();
            driver.FindElement(By.XPath("//textarea[@type='text']")).SendKeys("Gustavo Saramago");
            driver.FindElement(By.XPath("(//textarea[@type='text'])[2]")).Clear();
            driver.FindElement(By.XPath("(//textarea[@type='text'])[2]")).SendKeys("gustavosaramago@hotmail.com");
            driver.FindElement(By.XPath("//body[@id='webBody']/div/div/div[3]/div/div/div/div[2]/form/div[4]/div/div/a[2]")).Click();
            driver.FindElement(By.XPath("//textarea[@type='text']")).Clear();
            driver.FindElement(By.XPath("//textarea[@type='text']")).SendKeys("Me interessei pela descrição da vaga, por achar meu perfil compatível. Ao acessar o site da empresa, fiquei ainda mais entusiasmado pela possibilidade de realizar testes em aplicativos e novas funcionalidades.");
            driver.FindElement(By.XPath("(//textarea[@type='text'])[2]")).Clear();
            driver.FindElement(By.XPath("(//textarea[@type='text'])[2]")).SendKeys("Sempre fui muito detalhista e crítico. Encontrar inconformidades e erros nos softwares já acontecia mesmo antes de trabalhar na área. Me interessei pelo teste e me aprofundei, com cursos e certificações.");
            driver.FindElement(By.XPath("(//textarea[@type='text'])[3]")).Clear();
            driver.FindElement(By.XPath("(//textarea[@type='text'])[3]")).SendKeys("Admitindo que todo problema tem uma solução. Procurando resolver da maneira mais correta e rápida.");
            driver.FindElement(By.XPath("(//a[contains(text(),'Salvar e finalizar')])[2]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
