using hybr.Shared.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace hybr.Shared
{
    internal class HTTPClientSensor
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<List<Order>> Main()
        {
            try
            {
                string responseBody = await client.GetStringAsync("http://192.168.0.18/");
                return JsonConvert.DeserializeObject<List<Order>>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return new();
            }
        }
    }
}
