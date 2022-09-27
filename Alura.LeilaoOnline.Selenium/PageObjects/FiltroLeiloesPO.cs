using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public FiltroLeiloesPO(IWebDriver driver)
        
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.XPath("form>button.btn");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);
            select.DeselectAll();
            categorias.ForEach(categ =>
            {
                select.SelectByText(categ);
            });
            driver.FindElement(byInputTermo).SendKeys(termo);
            if (emAndamento)
            {
                driver.FindElement(byInputAndamento).Click();
            }
            driver.FindElement(byBotaoPesquisar).Click();
        }

    }
}
