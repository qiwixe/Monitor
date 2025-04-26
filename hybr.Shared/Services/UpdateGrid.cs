using BlazorBootstrap;

namespace hybr.Shared.Services
{
    public class UpdateGrid
    {
        public static Dictionary<string, Grid<Sensor>> AllUpdateGrid { get; set; } =
        new Dictionary<string, Grid<Sensor>>
        {
            ["Home"] = new(),
            ["Photovoltaic"] = new(),
            ["WindPower"] = new(),
            ["SolarCollector"] = new(),
            ["SolarConcentrator"] = new(),
            ["HeatPump"] = new(),
            ["Bioplant"] = new(),
            ["Meteorological"] = new()
        };
        public static Dictionary<string, Grid<Order>> AllUpdateDataGrid { get; set; } =
        new Dictionary<string, Grid<Order>>
        {
            ["Archive"] = new()
        };
    }
}
