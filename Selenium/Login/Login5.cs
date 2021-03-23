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



namespace Selenium.Login5
{
    [TestFixture]

    public class Login5
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private LoginObjects loginObjects;
        private GoTo goTo;


        [SetUp]

        public void login5()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            driver.Manage().Window.Maximize();
            loginObjects = new LoginObjects(driver);
            goTo = new GoTo(driver);


        }

        [Test]
        //Test on "Register Now" button
        public void TestLogin5()
        {
            goTo.LoginPage(ConfigurationManager.AppSettings["LoginPage"]);
            loginObjects.WaitLoginPage();
            loginObjects.RegisterNowButton();
            System.Threading.Thread.Sleep(2000);
            var IsCheck = driver.FindElement(By.CssSelector("#gate > div.vb.vb-invisible > div.vb-content > div > div > div > div.plate.animated.fadeIn.margin-b-20")).Selected;


        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}