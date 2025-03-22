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
        public static string Meteorological { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 7 order by id";
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

        public static async Task<List<Order>> Data(string _queryGetData)
        {
            #region асинхронн данные старое
            // if (dbData.Count == 0)
            // {
            //     NpgsqlConnection conn = new("Host=localhost;Username=postgres;Password=postgres;Database=station_archive");
            //     conn.Open();
            //     NpgsqlCommand cmd = new("SELECT * FROM backup_201311_3 order by id", conn);
            //     NpgsqlDataAdapter dataAdapter = new(cmd);
            //     DataTable dataTable = new();
            //     dataAdapter.Fill(dataTable);
            //     dbData = (from DataRow Data in dataTable.Rows
            //               select new Order()
            //                   {
            //                       Id = Convert.ToInt32(Data["id"]),
            //                       sensor_id = Convert.ToInt32(Data["sensor_id"]),
            //                       station_id = Convert.ToInt32(Data["station_id"]),
            //                       date_of_m = Data["date_of_m"].ToString(),
            //                       time_of_m = Data["time_of_m"].ToString(),
            //                       value_of_m = Convert.ToDouble(Data["value_of_m"]),
            //                       unit_of_m = Data["station_id"].ToString(),

            //                   }).ToList();
            // }
            // return await Task.FromResult(request.ApplyTo(dbData));

            // using (NpgsqlConnection sqlConnection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=station_archive"))
            // {

            //     try
            //     {
            //         if (dbData.Count == 0)
            //         {
            //             await sqlConnection.OpenAsync();

            //             using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT * FROM backup_201311_3  order by id", sqlConnection))
            //             {

            //                 using (NpgsqlDataReader DataReader = await sqlCommand.ExecuteReaderAsync())
            //                 {
            //                     while (await DataReader.ReadAsync())
            //                     {
            //                         dbData.Add(new Order()
            //                             {
            //                                 Id = Convert.ToInt32(DataReader["id"]),
            //                                 sensor_id = Convert.ToInt32(DataReader["sensor_id"]),
            //                                 station_id = Convert.ToInt32(DataReader["station_id"]),
            //                                 date_of_m = DataReader["date_of_m"].ToString(),
            //                                 time_of_m = DataReader["time_of_m"].ToString(),
            //                                 value_of_m = Convert.ToDouble(DataReader["value_of_m"]),
            //                                 unit_of_m = DataReader["station_id"].ToString(),
            //                             });
            //                     }
            //                 }
            //             }
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         throw new ApplicationException("Ошибка загрузки списка работ.", ex);
            //     }
            // return await Task.FromResult(request.ApplyTo(dbData));
            #endregion асинхронн данные старое
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


    }
}