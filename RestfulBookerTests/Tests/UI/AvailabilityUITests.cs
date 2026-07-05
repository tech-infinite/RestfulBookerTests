using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestfulBookerTests.Pages;

namespace HotelAutomationTests.Tests.UI
{
    [TestFixture]
    public class AvailabilityTests
    {
        private IWebDriver driver;
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver);
            homePage.Open();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Search_With_Valid_Dates_Should_Display_Available_Rooms()
        {
            // Arrange
            homePage.SelectCheckInDate("10/07/2026");
            homePage.SelectCheckOutDate("12/07/2026");

            // Act
            homePage.ClickSearch();

            // Assert
            Assert.That(homePage.AvailableRoomsAreDisplayed(), Is.True);
        }

        [Test]
        public void Search_With_No_Availability_Should_Display_Message()
        {
            // Arrange
            homePage.SelectCheckInDate("25/12/2026");
            homePage.SelectCheckOutDate("26/12/2026");

            // Act
            homePage.ClickSearch();

            // Assert
            Assert.That(homePage.GetNoRoomsMessage(),
                Is.EqualTo("No rooms available"));
        }
    }
}