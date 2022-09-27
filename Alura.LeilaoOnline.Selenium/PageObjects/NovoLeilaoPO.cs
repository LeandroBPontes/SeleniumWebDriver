using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;

        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By byBotaoSalvar;

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byInputCategoria = By.Id("Categoria");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byBotaoSalvar = By.CssSelector("button[type=submit]");
        }

        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(byInputCategoria));
                //elementoCategoria.FindElements(By.TagName("option"));
                return elementoCategoria.Options
                    .Where(o => o.Enabled)
                    .Select(o => o.Text);
            }
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(
            string titulo,
            string descricao,
            string categoria,
            double valor,
            string imagem,
            DateTime inicio,
            DateTime termino
            )
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            driver.FindElement(byInputCategoria).SendKeys(categoria);
            driver.FindElement(byInputValorInicial).SendKeys(valor.ToString());
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString("dd/MM/yyyy"));
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoSalvar).Click();
        }
    }
}
