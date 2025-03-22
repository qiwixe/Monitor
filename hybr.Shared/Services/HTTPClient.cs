using System.Net;
using System.Net.Http.Json;


namespace hybr.Shared.Services
{
    internal class HTTPClientSensor
    {
        //создать меню с настройками
        // что то сделать с исключением TaskCanceledException?
        static string _meteoServer = "http://192.168.0.18/";
        static HttpMessageHandler handler = new HttpClientHandler();
        static readonly HttpClient client = new HttpClient(handler){Timeout = TimeSpan.FromSeconds(1)};

        public static async Task<List<Order>> Main()
        {
            List<Order> _httpData = new();
            Dictionary<int, Order> _data = new();
            try
            {
                var responseBody = await client.GetFromJsonAsync<List<Order>>(_meteoServer);
                return responseBody;
            }
            catch (OperationCanceledException ex) when (ex.InnerException is TimeoutException tex)
            {
                Console.WriteLine($"Превышено время ожидания ответа от сервера: {_meteoServer}");
                return null;
            }
            catch (HttpRequestException ex) when (ex is { StatusCode: HttpStatusCode.NotFound })
            {
                Console.WriteLine($"Неправильно указан адресс: {ex.Message}");
                return null;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Непредвиденная ошибка!");
                Console.WriteLine("Сообщение :{0} ", e.Message);
                return null;
            }
        }
    }
}
