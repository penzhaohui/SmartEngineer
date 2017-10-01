using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceClient.Confluence
{
    public class ConfluenceClient
    {
        public static T Get<T>(string url, string urlParameters)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(ConfigurationManager.AppSettings["username"] + ":" + ConfigurationManager.AppSettings["password"])));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObject = response.Content.ReadAsAsync<T>().Result;               
                return dataObject;
            }
            else
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                throw new Exception("Error calling " + client.BaseAddress, new Exception(responseString));
            }
        }

        public static T Put<T>(string url, T dataObject)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(ConfigurationManager.AppSettings["username"] + ":" + ConfigurationManager.AppSettings["password"])));

            var DATA = JsonConvert.SerializeObject(dataObject);
            var content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");

            // List data response.
            HttpResponseMessage response = client.PutAsync(client.BaseAddress, content).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var updatedObject = response.Content.ReadAsAsync<T>().Result;
                return updatedObject;
            }
            else
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                throw new Exception("Error calling " + url, new Exception(responseString));
            }
        }
    }
}
