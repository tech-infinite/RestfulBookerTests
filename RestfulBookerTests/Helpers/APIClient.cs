using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBookerTests.Helpers
{
    public class APIClient
    {
        private readonly RestClient client;

        public APIClient()
        {
            client = new RestClient("\"https://restful-booker.herokuapp.com\"");

        }

        public RestResponse Login(string username, string password)
        {
            var request = new RestRequest("/auth", Method.Post);

            request.AddJsonBody(new
            {
                UserName = username,
                Password = password
            });

            return client.Execute(request);
        }
    }
}
