﻿using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencheFormulario(string login, string senha)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            driver.FindElement(byInputSenha).SendKeys(senha);
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoLogin).Submit();
        }

        public void EfetuarLoginComCredenciais(string login, string senha)
        {
            Visitar();
            PreencheFormulario(login, senha);
            SubmeteFormulario();
        }

    }
}
