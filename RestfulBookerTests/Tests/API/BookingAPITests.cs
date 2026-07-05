using Newtonsoft.Json;
using NUnit.Framework;
using RestfulBookerTests.Helpers;
using RestfulBookerTests.Models;
using System.Net;

[TestFixture]
public class BookingApiTests
{
    private APIClient _apiClient;

    [SetUp]
    public void Setup()
    {
        _apiClient = new APIClient();
    }

    [Test]
    public void Get_Booking_Should_Return_Booking_Details()
    {
        var response =
            _apiClient.GetBooking(1);

        Assert.That(response.StatusCode,
            Is.EqualTo(HttpStatusCode.OK));

        var booking =
            JsonConvert.DeserializeObject<BookingResponse>(response.Content);

        Assert.That(booking.FirstName,
            Is.Not.Empty);

        Assert.That(booking.LastName,
            Is.Not.Empty);
    }
}