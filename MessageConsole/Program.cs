using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MessageConsole // console app will call MessageApi
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static IConfigurationRoot configuration;
        static string demoApiUri = "";

        static void Main(string[] args)
        {
             configuration = new ConfigurationBuilder() // create configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            demoApiUri = configuration["DemoApiUri"].ToString(); // set uri from config value
            
            string response = MessageApiGetDemo().Result; // get api response
            Console.WriteLine(response); // write response 
        }
        
        static async Task<string> MessageApiGetDemo() // calls message demo api and returns result
        {
            string result = "";

            try{
                HttpResponseMessage response = await client.GetAsync(demoApiUri); 
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }catch(Exception ex){
                result = ex.InnerException.ToString();
            }

            return result;
        }
    }
}
