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
    public class Test1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
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
        public void The1Test()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/login");
            driver.FindElement(By.XPath("//form[@id='loginfrm']/div[3]/div/label/span")).Click();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("user@phptravels.com");
            driver.FindElement(By.XPath("//form[@id='loginfrm']/div[3]/div[2]/label/span")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("demouser");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.LinkText("Newsletter")).Click();
            driver.FindElement(By.XPath("//div[@id='newsletter']/div/div/label/span")).Click();
            driver.FindElement(By.XPath("//div[@id='newsletter']/div/div/label/span")).Click();
            driver.FindElement(By.LinkText("My Profile")).Click();
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.LinkText("Demo")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
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
