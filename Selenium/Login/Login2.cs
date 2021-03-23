using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Linq;
using System.Configuration;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using Selenium.Urls;
using Selenium.Login;



namespace Selenium.Login2
{
    [TestFixture]

    public class Login2
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private LoginObjects loginObjects;
        private GoTo goTo;


        [SetUp]

        public void login2()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            driver.Manage().Window.Maximize();
            loginObjects = new LoginObjects(driver);
            goTo = new GoTo(driver);


        }

        [Test]
        //Test on input invaid sybols (
        public void TestLogin2()
        {
            goTo.LoginPage(ConfigurationManager.AppSettings["LoginPage"]);
            loginObjects.WaitLoginPage();
            loginObjects.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            loginObjects.InputPwd(ConfigurationManager.AppSettings["InvalidPwd"]);
            loginObjects.LoginButton();
            
            System.Threading.Thread.Sleep(2000);
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#gate > div > div.vb-content > div > div > div > div.plate.animated.fadeIn.margin-b-20 > form:nth-child(2) > div:nth-child(2) > span")));
            Assert.IsTrue(errorMessage.Text.Contains("The login-username field must be a valid email."));

        }


        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}