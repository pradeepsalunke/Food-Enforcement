using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Food.Models;

namespace Food.APIHandlerManager
{
    public class APIHandlerChart
    {


        static string BASE_URL = "https://api.fda.gov/food/";


        HttpClient httpClient;

        public APIHandlerChart()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // httpClient.DefaultRequestHeaders.Add("X-Api-Key");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public RootObject GetRootObject()
        {
            string FOOD_CHART_PATH = BASE_URL + "/enforcement.json?count=classification.exact";

            string foodChart = "";

            RootObject rootObject = null;

            httpClient.BaseAddress = new Uri(FOOD_CHART_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(FOOD_CHART_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    foodChart = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!foodChart.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    rootObject = JsonConvert.DeserializeObject<RootObject>(foodChart);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }




            return rootObject;
        }
    }
}