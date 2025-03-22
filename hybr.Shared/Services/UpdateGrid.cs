using BlazorBootstrap;

namespace hybr.Shared.Services
{
    public class UpdateGrid
    {
        public static Dictionary<string, Grid<Sensor>> AllUpdateGrid { get; set; } =
        new Dictionary<string, Grid<Sensor>>
        {
            ["Home"] = new(),
            //["Photovoltaic"] = new(),
            //["WindPower"] = new(),
            ["Meteorological"] = new()
        };
    }
}
