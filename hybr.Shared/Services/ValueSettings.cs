using BlazorBootstrap;

namespace hybr.Shared.Services
{
        public class Station()
        {
            public required string Title { get; set; }
            public required string ShortTitle { get; set; }
            public required string FullTitle { get; set; }
            public required string Href { get; set; }
            public required List<int> SensorsId { get; set; }
            public IconColor Alert { get; set; } = IconColor.Info;
            public IconName Icon { get; set; } = IconName.InfoCircleFill;
            public string Station_Ip { get; set; } = "192.168.0.0";
        }
        public class Sensor()
        {
            public int Id { get; set; }
            public int Station_Id { get; set; }
            public string? Title { get; set; } = "Датчик";
            public int Unit_of_m { get; set; }
            public string GraduationString { get; set; } = "x";
            public double Value_min { get; set; }
            public double Value_max { get; set; }
            public double Value_of_m { get; set; } = 0;
            public AlertColor Alert { get; set; } = AlertColor.Info;
            public IconName Icon { get; set; } = IconName.InfoCircleFill;
            public bool Disconnected { get; set; }
        }

    public class SensorUnit()
        {
            public required string UnitFull { get; set; }
            public required string UnitShort { get; set; }
        }
    public class ValueSettings()
        {
            public static Dictionary<int, Station> Stations = new();
            public static Dictionary<int, Sensor> Sensors = new();
            public static Dictionary<int, SensorUnit> Units = new();
    }
}