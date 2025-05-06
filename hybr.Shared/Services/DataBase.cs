using Npgsql;

namespace hybr.Shared.Services
{
    public class SQLstring()
    {
        public static string Connection { get; } = "Host=localhost;Username=postgres;Password=postgres;Database=station_archive";
        public static string All { get; } = "SELECT * FROM backup_201311_3 order by id";
        public static string WindPower { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 1 order by id";
        public static string Photovoltaic { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 2 order by id";
        public static string SolarCollector { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 3 order by id";
        public static string SolarСoncentrator { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 4 order by id";
        public static string HeatPump { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 5 order by id";
        public static string Bioplant { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 6 order by id";
        public static string Meteorological { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 7 and sensor_id = 103 order by id";
    }
    public class DataBase
    {
        #region Переменные с данными ДБ
        public static List<Order> DataAll { get; set; } = new();
        public static List<Order> DataMeteorological { get; set; } = new();
        public static List<Order> DataBioplant { get; set; } = new();
        public static List<Order> DataHeatPump { get; set; } = new();
        public static List<Order> DataSolarСoncentrator { get; set; } = new();
        public static List<Order> DataSolarCollector { get; set; } = new();
        public static List<Order> DataPhotovoltaic { get; set; } = new();
        public static List<Order> DataWindPower { get; set; } = new();
        public static List<Order> DataArchive { get; set; } = new();
        #endregion Переменные с данными ДБ

        public static async void GetAllData()
        {
            DataMeteorological      = await Data(SQLstring.Meteorological);
            DataAll                 = await Data(SQLstring.All);
            DataBioplant            = await Data(SQLstring.Bioplant);
            DataHeatPump            = await Data(SQLstring.HeatPump);
            DataSolarСoncentrator   = await Data(SQLstring.SolarСoncentrator);
            DataSolarCollector      = await Data(SQLstring.SolarCollector);
            DataPhotovoltaic        = await Data(SQLstring.Photovoltaic);
            DataWindPower           = await Data(SQLstring.WindPower);
        }

        const string querySetData = "INSERT INTO table_test VALUES (1, 103, 7, '2013-11-21', '00:00:01', 0.944444, '6');";

        public static async void DBset()
        {
            await using var conn = new NpgsqlConnection(SQLstring.Connection);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(querySetData, conn);
            await cmd.ExecuteNonQueryAsync();
            await conn.CloseAsync();
        }
        public static string CreateSQLstring(int station_id){
        return $"SELECT * FROM backup_201311_3 WHERE station_id = {station_id} order by id";
        }
        public static string CreateSQLstring(int station_id, int sensor_id)
        {
            return $"SELECT * FROM backup_201311_3 WHERE station_id = {station_id} and sensor_id = {sensor_id} order by id";
        }
        public static string CreateSQLstring(int station_id, int sensor_id, string date)
        {
            return $"SELECT * FROM backup_201311_3 WHERE station_id = {station_id} and sensor_id = {sensor_id} and date_of_m = '{date}' order by id";
        }
        public static string CreateSQLstring(int station_id, int sensor_id, string range_start_date, string range_stop_date)
        {
            return $"SELECT * FROM backup_201311_3 WHERE station_id = {station_id} and sensor_id = {sensor_id} and date_of_m >= '{range_start_date}' and date_of_m <= '{range_stop_date}' order by id";
        }
        public static async Task<List<Order>> Data(string _queryGetData)
        {
            List<Order> _dbData = new();
            try
            {
                await using var _conn = new NpgsqlConnection(SQLstring.Connection);
                await _conn.OpenAsync();
                await using var cmd = new NpgsqlCommand(_queryGetData, _conn);
                await using var _reader = await cmd.ExecuteReaderAsync();
                while (await _reader.ReadAsync())
                {
                    _dbData.Add(new Order
                    {
                        Id = _reader.GetInt32(0),
                        Sensor_id = _reader.GetInt32(1),
                        Station_id = _reader.GetInt32(2),
                        Date_of_m = _reader.GetString(3),
                        Time_of_m = _reader.GetString(4),
                        Value_of_m = _reader.GetDouble(5),
                        Unit_of_m = _reader.GetString(6),
                    });
                }
                _conn.CloseAsync();
            }
            catch
            {
                Console.WriteLine("Нет связи с базой данных");
            }
            return _dbData;

        }

        //CREATE TABLE IF NOT EXISTS public."Sensors"
        //(
        //    "Id" integer NOT NULL,
        //    "Title" character varying NOT NULL DEFAULT Датчик,
        //    "Station_Id" integer NOT NULL DEFAULT 0,
        //    "Value_min" double precision NOT NULL DEFAULT 0,
        //    "Value_max" double precision NOT NULL DEFAULT 0,
        //    "GraduationString" character varying NOT NULL DEFAULT x,
        //    PRIMARY KEY("Id")
        //);

        //CREATE TABLE IF NOT EXISTS public."Stations"
        //(
        //    "Id" integer NOT NULL,
        //    "Title" character varying NOT NULL DEFAULT Станция,
        //    "ShortTitle" character varying NOT NULL DEFAULT Стц,
        //    "FullTitle" character varying NOT NULL DEFAULT Установка №0 Станция,
        //    "Href" character varying NOT NULL DEFAULT Home,
        //    "Station_Ip" character varying NOT NULL DEFAULT http://192.168.0.0/,
        //    PRIMARY KEY("Id")
        //);

        //CREATE TABLE IF NOT EXISTS public."Authentication"
        //(
        //    "Id" integer NOT NULL,
        //    "Password" character varying NOT NULL,
        //    PRIMARY KEY("Id")
        //);

    }
}