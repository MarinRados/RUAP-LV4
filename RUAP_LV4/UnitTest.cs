using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UnitTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demo.opencart.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUnitTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("Ime");
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("Prezime");
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("tonchi2@mail.hr");
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("38512345678");
            driver.FindElement(By.Id("input-address-1")).Clear();
            driver.FindElement(By.Id("input-address-1")).SendKeys("Adresa 1");
            driver.FindElement(By.Id("input-city")).Clear();
            driver.FindElement(By.Id("input-city")).SendKeys("Grad");
            driver.FindElement(By.Id("input-postcode")).Clear();
            driver.FindElement(By.Id("input-postcode")).SendKeys("31431");
            new SelectElement(driver.FindElement(By.Id("input-country"))).SelectByText("Croatia");
            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByText("Osječko-baranjska");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("lega");
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("lega");
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

