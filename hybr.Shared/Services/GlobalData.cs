using BlazorBootstrap;
using System.ComponentModel.DataAnnotations;

namespace hybr.Shared.Services
{

    public class Order()
    {
        [Key]
        public int Id               { get; set; }
        public int Sensor_id        { get; set; }
        public int Station_id       { get; set; }
        public string? Date_of_m    { get; set; }
        public string? Time_of_m    { get; set; }
        public double Value_of_m    { get; set; }
        public string? Unit_of_m    { get; set; }
    }
    public class Sensor()
    {
        public AlertColor Alert { get; set; } = AlertColor.Info;
        public double Value_of_m { get; set; } = 0;
    }
    public class SensorRange()
    {
        public int Value_min { get; set; }
        public int Value_max { get; set; }
    }

    public class SQLstring()
    {
        public static string Connection         { get; } = "Host=localhost;Username=postgres;Password=postgres;Database=station_archive";
        public static string All                { get; } = "SELECT * FROM backup_201311_3 order by id";
        public static string WindPower          { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 1 order by id";
        public static string Photovoltaic       { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 2 order by id";
        public static string SolarCollector     { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 3 order by id";
        public static string SolarСoncentrator  { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 4 order by id";
        public static string HeatPump           { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 5 order by id";
        public static string Bioplant           { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 6 order by id";
        public static string Meteorological     { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 7 order by id";

    }
    public class GlobalData()
    {
        public static List<Order> DataAll                  { get; set; } = new();
        public static List<Order> DataMeteorological       { get; set; } = new();
        public static List<Order> DataBioplant             { get; set; } = new();
        public static List<Order> DataHeatPump             { get; set; } = new();
        public static List<Order> DataSolarСoncentrator    { get; set; } = new();
        public static List<Order> DataSolarCollector       { get; set; } = new();
        public static List<Order> DataPhotovoltaic         { get; set; } = new();
        public static List<Order> DataWindPower            { get; set; } = new();

        public static async void GetAllData()
        {
            DataMeteorological      = await Db.Data(SQLstring.Meteorological);
            DataAll                 = await Db.Data(SQLstring.All);
            DataBioplant            = await Db.Data(SQLstring.Bioplant);
            DataHeatPump            = await Db.Data(SQLstring.HeatPump);
            DataSolarСoncentrator   = await Db.Data(SQLstring.SolarСoncentrator);
            DataSolarCollector      = await Db.Data(SQLstring.SolarCollector);
            DataPhotovoltaic        = await Db.Data(SQLstring.Photovoltaic);
            DataWindPower           = await Db.Data(SQLstring.WindPower);
        }
        public static List<SensorRange> GetSensorData()
        {
            List<SensorRange> _sensorValue = new List<SensorRange>(new SensorRange[110]);

            _sensorValue[103] = (new SensorRange
            {
                Value_min = -50,
                Value_max = 50,
            });
            _sensorValue[104] = (new SensorRange
            {
                Value_min = 0,
                Value_max = 100,
            });
            _sensorValue[105] = (new SensorRange
            {
                Value_min = 700,
                Value_max = 900,
            });
            _sensorValue[106] = (new SensorRange
            {
                Value_min = 0,
                Value_max = 360,
            });
            _sensorValue[107] = (new SensorRange
            {
                Value_min = 0,
                Value_max = 15,
            });
            _sensorValue[108] = (new SensorRange
            {
                Value_min = 0,
                Value_max = 600,
            });
            return _sensorValue;
        }

    }
}
