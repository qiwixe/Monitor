using BlazorBootstrap;

namespace hybr.Shared.Services
{
        public class Station() : ICloneable
        {
                public required string Title { get; set; }
                public required string ShortTitle { get; set; }
                public required string FullTitle { get; set; }
                public required string Href { get; set; }
                public required List<int> SensorsId { get; set; }
                public IconColor Alert { get; set; } = IconColor.Info;
                public IconName Icon { get; set; } = IconName.InfoCircleFill;
                public string Station_Ip { get; set; } = "192.168.0.0";
            public object Clone()
            {
                return MemberwiseClone();
            }
            public override bool Equals(object? obj)
            {
                if (obj is Station _station) return (Title == _station.Title && ShortTitle == _station.ShortTitle && FullTitle == _station.FullTitle && Href == _station.Href && Station_Ip == _station.Station_Ip);
                return false;
            }

            public override int GetHashCode() => throw new NotImplementedException();
        }
        public class Sensor() : ICloneable
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

            public object Clone()
            {
                return MemberwiseClone();
            }
            public override bool Equals(object? obj)
            {
                if (obj is Sensor _sensor) return (Station_Id == _sensor.Station_Id && Title == _sensor.Title && Unit_of_m == _sensor.Unit_of_m && GraduationString == _sensor.GraduationString && Value_min == _sensor.Value_min && Value_max == _sensor.Value_max);
                return false;
            }
            public override int GetHashCode() => throw new NotImplementedException();
    }

    public class SensorUnit() : ICloneable
    {
        public required string UnitFull { get; set; }
        public required string UnitShort { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    public class ValueSettings()
        {
            public static Dictionary<int, Station> Stations { get; set; } = new();
            public static Dictionary<int, Sensor> Sensors { get; set; } = new();
            public static Dictionary<int, SensorUnit> Units { get; set; } = new();
            public static Dictionary<int, Station> StationsSettings { get; set; } = new();
            public static Dictionary<int, Sensor> SensorsSettings { get; set; } = new();
            public static Dictionary<int, SensorUnit> UnitsSettings { get; set; } = new();
    }
}