using Newtonsoft.Json;
using NUnit.Framework;
using RestfulBookerTests.Helpers;
using RestfulBookerTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBookerTests.Tests.API
{
    public class LoginAPITests
    {
        private APIClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new APIClient();
        }

        [Test]
        public void SuccessfulLogin_ShouldReturnToken()
        {
            var response =
        _apiClient.CreateToken("admin", "password123");

            Assert.That(response.StatusCode,
                Is.EqualTo(HttpStatusCode.OK));

            var auth =
                JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            Assert.That(auth.Token, Is.Not.Null);

            Assert.That(auth.Token, Is.Not.Empty);
        }

        [Test]
        public void UnsuccessfulLogin_ShouldReturnError()
        {
            var response =
        _apiClient.CreateToken("admin", "wrongpassword");

            Assert.That(response.StatusCode,
                Is.EqualTo(HttpStatusCode.OK));

            var auth =
                JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            Assert.That(auth.Reason,
                Is.EqualTo("Bad credentials"));
        }
    }
}
