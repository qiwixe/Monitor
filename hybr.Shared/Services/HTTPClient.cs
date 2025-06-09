using System.Net;
using System.Net.Http.Json;

namespace hybr.Shared.Services
{
    internal class HTTPClientSensor
    {
        static HttpMessageHandler handler = new HttpClientHandler();
        static List<Order> _httpData = new();
        Dictionary<int, Order> _data = new();
        static readonly HttpClient client = new HttpClient(handler){Timeout = TimeSpan.FromSeconds(1)};
        public static async Task<List<Order>> Main()
        {
            _httpData.Clear();
                foreach (var (_key, _value) in ValueSettings.Stations)
                    try
                    {
                        _httpData.AddRange(await client.GetFromJsonAsync<List<Order>>(_value.Station_Ip));
                    }
                    catch (OperationCanceledException ex) when (ex.InnerException is TimeoutException tex)
                    {
                        Console.WriteLine($"Превышено время ожидания ответа от сервера: {_value.Station_Ip}");
                    }
                    catch (HttpRequestException ex) when (ex is { StatusCode: HttpStatusCode.NotFound })
                    {
                        Console.WriteLine($"Неправильно указан адресс: {ex.Message}");
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine("Непредвиденная ошибка!");
                        Console.WriteLine("Сообщение :", e.Message);
                    }
            return _httpData;
        }
    }
}