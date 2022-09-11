using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace liberis.com.automate.Steps
{
    [Binding]
    public class StepDefinitions : IDisposable
    {
        private ChromeDriver chromeDriver;

        public StepDefinitions() => chromeDriver = new ChromeDriver();
        private readonly ScenarioContext _scenarioContext;

        public object I { get; private set; }

       
        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            chromeDriver.Navigate().GoToUrl("https://liberis.com/");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("liberis"));
        }

        [When(@"I press the Get a Demo button")]
        public void WhenIPressGetADemoButton()
         {
            System.Threading.Thread.Sleep(2000);
            var getADemoButton = chromeDriver.FindElement(By.XPath("//a[contains(text(),'Get a Demo')"));
            getADemoButton.Click();
         }

        [Then(@"It should be navigate to Partner Selection page")]
        public void ThenIShouldBeNavigateToPartnerSelectionPage()
        {

            System.Threading.Thread.Sleep(2000);
            chromeDriver.Navigate().GoToUrl("https://www.liberis.com/become-a-partner");
            // After click is complete the become - a - partner should be present in url as well as page title`
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("Contact us"));
            //Assert.IsTrue(chromeDriver.Title.ToLower().Contains("Type of partner"));
        }

        [Then(@"Partner Selection page has the required 3 Types of Partners")]
        public void ThenShouldBerequired3TypesOfPartners()
        {

            System.Threading.Thread.Sleep(2000);
            // After click is complete the become - a - partner should be present in url as well as page title`
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("I'm a Broker"));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("I'm an ISO"));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("I'm a Strategic Partner"));

        }

        [Then(@"I should validate the message when user does not make a partner selection and click ‘Get a demo’ button")]
        public void ValidateTheAlertMessage()
        {
            System.Threading.Thread.Sleep(2000);
            var getADemoButton = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/main/section/div[2]/div/div[2]/div/a"));
            getADemoButton.Click();
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("Please select a type of partner"));
        }

        [Then(@"I press the radio button")]
        public void IPressTheRadiobutton()
        {
            System.Threading.Thread.Sleep(2000);
            WebElement radio = (WebElement)chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/main/section/div[2]/div/div[2]/div/div[1]/div[1]/label"));
            radio.Click();
        }

        [Then(@"I press the Get a Demo button on partner page after select")]
        public void IPressTheGetADemoButtonAfterRadioBoxSelect()
        {
            System.Threading.Thread.Sleep(2000);
            WebElement radio = (WebElement)chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/main/section/div[2]/div/div[2]/div/a"));
            radio.Click();
        }

        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
    }
}