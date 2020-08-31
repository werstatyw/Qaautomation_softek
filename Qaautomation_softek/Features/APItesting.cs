using System;
using RestSharp;
namespace Qaautomation_softek.Features
{
    public class APItesting
    {

        public void APItesting_discount()
        {
            var client = new RestClient("https://fg1ap986e9.execute-api.eu-west-1.amazonaws.com/Dev/coupon?coupon=string");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

    }
}
