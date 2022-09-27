using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
      

        public FiltroLeiloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }


        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
          
            Filtro = new FiltroLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);

        }
    }
}
