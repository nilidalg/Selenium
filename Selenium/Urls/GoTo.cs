using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Selenium.Urls
{
    class GoTo
    {
        private IWebDriver driver;
        private WebDriverWait wait;



        public GoTo(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));

        }

        public void LoginPage(string LoginPage)
        {
            driver.Navigate().GoToUrl(LoginPage);
        }
    }
}
