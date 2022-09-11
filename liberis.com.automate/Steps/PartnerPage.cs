using OpenQA.Selenium;

namespace liberis.com.automate.Steps
{
    internal class PartnerPage
    {
        private IWebDriver webDriver;

        public PartnerPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
    }
}