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



namespace Selenium.Login4
{
    [TestFixture]

    public class Login4
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private LoginObjects loginObjects;
        private GoTo goTo;


        [SetUp]

        public void login4()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            driver.Manage().Window.Maximize();
            loginObjects = new LoginObjects(driver);
            goTo = new GoTo(driver);


        }

        [Test]
        //Test "Remember me" button
        public void TestLogin4()
        {
            goTo.LoginPage(ConfigurationManager.AppSettings["LoginPage"]);
            loginObjects.WaitLoginPage();
            System.Threading.Thread.Sleep(4000);
            loginObjects.RememberMeButton();
            
            
            System.Threading.Thread.Sleep(2000);
            var isChecked = driver.FindElement(By.CssSelector("#login-remember-me")).Selected;
        }


        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}