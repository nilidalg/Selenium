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



namespace Selenium.Login6
{
    [TestFixture]

    public class Login6
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private LoginObjects loginObjects;
        private GoTo goTo;


        [SetUp]

        public void login6()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            driver.Manage().Window.Maximize();
            loginObjects = new LoginObjects(driver);
            goTo = new GoTo(driver);


        }

        [Test]
        //Test "Forgot Password" link
        public void TestLogin6()
        {
            goTo.LoginPage(ConfigurationManager.AppSettings["LoginPage"]);
            loginObjects.WaitLoginPage();
            loginObjects.ForgotPwdButton();
            System.Threading.Thread.Sleep(2000);
            var Check = driver.FindElement(By.CssSelector("#main-container > div > div.vb-content > div > div > div > div.plate.animated.fadeIn.margin-b-20 > form > h3")).Displayed;
        }


        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}