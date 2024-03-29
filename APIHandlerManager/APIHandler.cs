﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Food.Models;

namespace Food.APIHandlerManager
{
    public class APIHandler
    {
        

        static string BASE_URL = "https://api.fda.gov/food/";
       

        HttpClient httpClient;

        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
           // httpClient.DefaultRequestHeaders.Add("X-Api-Key");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        
        public RootObject GetRootObject()
        {
            string FOOD_API_PATH = BASE_URL + "/enforcement.json?search=report_date:[20040101+TO+20131231]&limit=50";

            string foodData = "";

            RootObject rootObject = null;

            httpClient.BaseAddress = new Uri(FOOD_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(FOOD_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    foodData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!foodData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    rootObject = JsonConvert.DeserializeObject<RootObject>(foodData);
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