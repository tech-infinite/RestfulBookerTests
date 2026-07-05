using OpenQA.Selenium;

namespace RestfulBookerTests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }

    
}
