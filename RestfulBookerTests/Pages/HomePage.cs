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

        public void Open()
        {
            driver.Navigate().GoToUrl("https://automationintesting.online/");
        }

        public void SelectCheckInDate(string date)
        {
            driver.FindElement(By.XPath("//label[normalize-space()='Check In']/following::input[1]")).SendKeys(date);
        }

        public void SelectCheckOutDate(string date)
        {
            driver.FindElement(By.XPath("//label[normalize-space()='Check Out']/following::input[1]")).SendKeys(date);
        }

        public void ClickSearch()
        {
            driver.FindElement(By.XPath("//button[normalize-space()='Check Availability']")).Click();
        }

        public bool AvailableRoomsAreDisplayed()
        {
            var rooms = driver.FindElements(By.CssSelector(".room-card"));

            return rooms.Any();

        }

        public bool EveryRoomHasBookingButton()
        {
            var rooms = driver.FindElements(By.CssSelector(".room-card"));

            return rooms.All(room =>
                room.FindElements(By.CssSelector(".btn-primary")).Any());
        }

        public string GetNoRoomsMessage()
        {
            return driver.FindElement(By.Id("noRoomsMessage")).Text;
        }
    }
}

    
