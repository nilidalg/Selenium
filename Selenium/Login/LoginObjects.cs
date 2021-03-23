using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Configuration;

namespace Selenium.Login
{
    class LoginObjects
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "login-username")]
        public IWebElement LoginInput { get; set; }

        [FindsBy(How = How.Id, Using = "login-password")]
        public IWebElement PwdInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#gate > div > div.vb-content > div > div > div > div.plate.animated.fadeIn.margin-b-20 > form:nth-child(2) > div:nth-child(6) > button")]
        public IWebElement Loginbutton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#login-remember-me")]
        public IWebElement RememberMe { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='gate']/div/div[1]/div/div/div/div[1]/form[1]/div[6]/a")]
        public IWebElement RegisterNow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#gate > div > div.vb-content > div > div > div > div.plate.animated.fadeIn.margin-b-20 > form:nth-child(2) > div.form-group.row.font-s13.margin-b-20 > div:nth-child(2) > div > a")]
        public IWebElement ForgotPwd { get; set; }

        public LoginObjects(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            PageFactory.InitElements(driver, this);


        }
        public void WaitLoginPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id='app']/div/img[1]")));
        }

        public void InputLogin(string Login)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(LoginInput)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(LoginInput)).SendKeys(Login);
        }

        public void InputPwd(string Pwd)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(PwdInput)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(PwdInput)).SendKeys(Pwd);
        }

        public void LoginButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Loginbutton)).Click();
        }

        public void RememberMeButton()
        {
            System.Threading.Thread.Sleep(4000);
            wait.Until(ExpectedConditions.ElementToBeClickable(RememberMe)).Click();
        }

        public void RegisterNowButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(RegisterNow)).Click();
        }
        public void ForgotPwdButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ForgotPwd)).Click();
        }






















        public void waiit()
            {
            
            }
    }
}
