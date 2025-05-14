using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Npgsql;
using Parlot;
using Parlot.Fluent;
using System;
using System.Collections.Concurrent;
using System.Formats.Asn1;
using System.Text.RegularExpressions;
using static ClosedXML.Excel.XLPredefinedFormat;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        private static string schemaName = "data";
        private static string tableName = "alldata";
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

        public static async void DBset(string _querySetData)
        {
            await using var conn = new NpgsqlConnection(SQLstring.Connection);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_querySetData, conn);
            await cmd.ExecuteNonQueryAsync();
            await conn.CloseAsync();
        }
        public static string CreateSQLstring(int station_id){
        return $"SELECT * FROM {schemaName}.{tableName} WHERE station_id = {station_id} order by date_time";
        }
        public static string CreateSQLstring(int station_id, int sensor_id)
        {
            return $"SELECT * FROM {schemaName}.{tableName} WHERE station_id = {station_id} and sensor_id = {sensor_id} order by date_time";
        }
        public static string CreateSQLstring(int station_id, int sensor_id, string range_start_date, string range_stop_date)
        {
            return $"SELECT * FROM {schemaName}.{tableName} WHERE station_id = {station_id} and sensor_id = {sensor_id} and date_time >= '{range_start_date}' and date_time <= '{range_stop_date}' order by date_time";
        }
        public static string CreateSQLstring(int station_id, Dictionary<int,bool> sensor_id, string range_start_date, string range_stop_date)
        {
            string _formated_string_sensor_id = "0";
            foreach (var (_key,_value) in sensor_id)
                if(_value)
                _formated_string_sensor_id += $",{_key}";
            return $"SELECT * FROM {schemaName}.{tableName} WHERE sensor_id in ({_formated_string_sensor_id}) and date_time >= '{range_start_date}' and date_time <= '{range_stop_date}' order by date_time";
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
                        Date_of_m = _reader.GetDateTime(3).ToString("yyyy-MM-dd"),
                        Time_of_m = _reader.GetDateTime(3).ToString("HH-mm-ss"),
                        Value_of_m = _reader.GetDouble(4),
                    });
                }
                await _conn.CloseAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine("Нет связи с базой данных");
                Console.WriteLine(e);
            }
            return _dbData;
        }
        public static async Task<bool> Auth(string _pass)
        {
            string _queryGetData = $"Select count(*) FROM Settings.Authentication WHERE password = '{_pass}'";
            try
            {
                await using var _conn = new NpgsqlConnection(SQLstring.Connection);
                await _conn.OpenAsync();
                await using var cmd = new NpgsqlCommand(_queryGetData, _conn);
                await using NpgsqlDataReader _reader = await cmd.ExecuteReaderAsync();
                await _reader.ReadAsync();
                if (_reader.GetInt32(0) == 0) {
                    await _conn.CloseAsync();
                    return false; 
                } else {
                    await _conn.CloseAsync();
                    return true; }
            }
            catch
            {
                Console.WriteLine("Нет связи с базой данных");
                return false;
            }
        }
        public static async Task Init()
        {
            try
            {
                await using var _conn = new NpgsqlConnection(SQLstring.Connection);
                await _conn.OpenAsync();
                var batch = new NpgsqlBatch(_conn)
                {
                    BatchCommands = { 
                        new("SELECT s.id,s.title,s.shorttitle,s.fulltitle,s.href,s.station_ip, array_agg(s_x_s.sensor_id) FROM settings.stations s left join settings.stations_x_sensors s_x_s on s.id = s_x_s.station_id group by s.id,s.title,s.shorttitle,s.fulltitle,s.href,s.station_ip order by id"), 
                        new("SELECT * FROM Settings.units order by id"), 
                        new("SELECT * FROM settings.sensors order by id") }
                };
                await using (var _reader = await batch.ExecuteReaderAsync())
                {
                    while (await _reader.ReadAsync())
                    {
                        ValueSettings.Stations[_reader.GetInt32(0)] = new Station
                        {
                            Title = _reader.GetString(1),
                            ShortTitle = _reader.GetString(2),
                            FullTitle = _reader.GetString(3),
                            Href = _reader.GetString(4),
                            Station_Ip = _reader.GetString(5),
                            SensorsId = _reader.GetFieldValue<int[]>(6).ToList(),
                        };
                        ValueSettings.StationsSettings[_reader.GetInt32(0)] = (Station)ValueSettings.Stations[_reader.GetInt32(0)].Clone();
                    }
                    await _reader.NextResultAsync();
                    while (await _reader.ReadAsync())
                    {
                        ValueSettings.Units[_reader.GetInt32(0)] = new SensorUnit
                        {
                            UnitFull = _reader.GetString(1),
                            UnitShort = _reader.GetString(2)
                        };
                        ValueSettings.UnitsSettings[_reader.GetInt32(0)] = (SensorUnit)ValueSettings.Units[_reader.GetInt32(0)].Clone();
                    }
                    await _reader.NextResultAsync();
                    while (await _reader.ReadAsync())
                    {
                        ValueSettings.Sensors[_reader.GetInt32(0)] = new Sensor
                        {
                            Title = _reader.GetString(1),
                            Station_Id = _reader.GetInt32(2),
                            Value_min = _reader.GetDouble(3),
                            Value_max = _reader.GetDouble(4),
                            GraduationString = _reader.GetString(5),
                            Unit_of_m = _reader.GetInt32(6)
                        };
                        ValueSettings.SensorsSettings[_reader.GetInt32(0)] = (Sensor)ValueSettings.Sensors[_reader.GetInt32(0)].Clone();
                    }
                }
                await _conn.CloseAsync();
                #region Старое
                //string _queryGetDataStations = "SELECT * FROM settings.stations";
                //string _queryGetDataUnits = "SELECT * FROM Settings.units";
                //string _queryGetDataSensors = "SELECT * FROM settings.sensors";
                //await using var cmd = new NpgsqlCommand(_queryGetDataStations, _conn);
                //await using var _reader = await cmd.ExecuteReaderAsync();
                //while (await _reader.ReadAsync())
                //{
                //    ValueSettings.Stations[_reader.GetInt32(0)] = new Station
                //    {
                //        Title = _reader.GetString(1),
                //        ShortTitle = _reader.GetString(2),
                //        FullTitle = _reader.GetString(3),
                //        Href = _reader.GetString(4),
                //        Station_Ip = _reader.GetString(5),
                //        SensorsId = _reader.GetFieldValue<int[]>(6).ToList(),
                //    };
                //    ValueSettings.StationsSettings[_reader.GetInt32(0)] = (Station)ValueSettings.Stations[_reader.GetInt32(0)].Clone();
                //}
                //await _conn.CloseAsync();
                //await _conn.OpenAsync();
                //await using var cmd1 = new NpgsqlCommand(_queryGetDataUnits, _conn);
                //await using var _reader1 = await cmd1.ExecuteReaderAsync();
                //while (await _reader1.ReadAsync())
                //{
                //    ValueSettings.Units[_reader1.GetInt32(0)] = new SensorUnit
                //    {
                //        UnitFull = _reader1.GetString(1),
                //        UnitShort = _reader1.GetString(2)
                //    };
                //    ValueSettings.UnitsSettings[_reader1.GetInt32(0)] = (SensorUnit)ValueSettings.Units[_reader1.GetInt32(0)].Clone();
                //}
                //await _conn.CloseAsync();
                //await _conn.OpenAsync();
                //await using var cmd2 = new NpgsqlCommand(_queryGetDataSensors, _conn);
                //await using var _reader2 = await cmd2.ExecuteReaderAsync();
                //while (await _reader2.ReadAsync())
                //{
                //    ValueSettings.Sensors[_reader2.GetInt32(0)] = new Sensor
                //    {
                //        Title = _reader2.GetString(1),
                //        Station_Id = _reader2.GetInt32(2),
                //        Value_min = _reader2.GetDouble(3),
                //        Value_max = _reader2.GetDouble(4),
                //        GraduationString = _reader2.GetString(5),
                //        Unit_of_m = _reader2.GetInt32(6)
                //    };
                //    ValueSettings.SensorsSettings[_reader2.GetInt32(0)] = (Sensor)ValueSettings.Sensors[_reader2.GetInt32(0)].Clone();
                //}
                //await _conn.CloseAsync();
                #endregion Старое
            }
            catch (Exception e)
            {
                Console.WriteLine("Нет связи с базой данных");
                Console.WriteLine(e);
            }
            await CheckPart();
        }
        public static async Task UpdSettings()
        {
            string _updstr = "";
            foreach (var (_key,_value) in ValueSettings.SensorsSettings)
            {
                if (!ValueSettings.Sensors[_key].Equals(_value))
                {
                    _updstr += $"UPDATE settings.sensors SET title = '{_value.Title}', value_min = {_value.Value_min}, value_max = {_value.Value_max}, graduationstring = '{_value.GraduationString}'  WHERE id = {_key};";
                    Console.WriteLine($"UPDATE settings.sensors SET title = '{_value.Title}', value_min = {_value.Value_min}, value_max = {_value.Value_max}, graduationstring = '{_value.GraduationString}'  WHERE id = {_key}");
                }
            }
            foreach (var (_key,_value) in ValueSettings.StationsSettings)
            {
                if (!ValueSettings.Stations[_key].Equals(_value))
                {
                    _updstr += $"UPDATE settings.stations SET title = '{_value.Title}', shorttitle = '{_value.ShortTitle}', fulltitle = '{_value.FullTitle}', href = '{_value.Href}',station_ip = '{_value.Station_Ip}'  WHERE id = {_key};";
                    Console.WriteLine($"UPDATE settings.stations SET title = '{_value.Title}', shorttitle = '{_value.ShortTitle}', fulltitle = '{_value.FullTitle}', href = '{_value.Href}',station_ip = '{_value.Station_Ip}'  WHERE id = {_key}");
                }
            }
            await using var _conn = new NpgsqlConnection(SQLstring.Connection);
            await _conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_updstr, _conn);
            await cmd.ExecuteNonQueryAsync();
            await _conn.CloseAsync();
            await Init();
        }
        public static async Task InsertData(Dictionary<int, Order> _dictData)
        {
            string _insstr = "";
            foreach (var (_key, _value) in _dictData)
            {
                _insstr += $"INSERT INTO data.alldata(sensor_id, station_id, date_time, value_data) VALUES ({_value.Sensor_id},{_value.Station_id},'{_value.Date_of_m} {_value.Time_of_m}',{_value.Value_of_m.ToString().Replace(',','.')});";
                Console.WriteLine($"INSERT INTO data.alldata(sensor_id, station_id, date_time, value_data) VALUES ({_value.Sensor_id},{_value.Station_id},'{_value.Date_of_m} {_value.Time_of_m}',{_value.Value_of_m.ToString().Replace(',','.')});");
            }
            await using var _conn = new NpgsqlConnection(SQLstring.Connection);
            await _conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_insstr, _conn);
            await cmd.ExecuteNonQueryAsync();
            await _conn.CloseAsync();
        }
        public static async Task CheckPart()
        {
            string _checkstr = "SELECT partman.run_maintenance();";
            await using var _conn = new NpgsqlConnection(SQLstring.Connection);
            await _conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_checkstr, _conn);
            await cmd.ExecuteNonQueryAsync();
            await _conn.CloseAsync();
            //SELECT partman.partition_data_time('data.alldata');
        }
        #region Создание базы
        //CREATE SCHEMA IF NOT EXISTS Settings;
        //CREATE TABLE IF NOT EXISTS Settings.Authentication
        //(
        //    Id serial NOT NULL,
        //    Password character varying NOT NULL,
        //    PRIMARY KEY(Id)
        //);
        //INSERT INTO Settings.Authentication (password) VALUES('qiwixe');

        //CREATE SCHEMA IF NOT EXISTS Settings;
        //CREATE TABLE IF NOT EXISTS Settings.Units
        //(
        //    Id serial NOT NULL,
        //    UnitFull character varying NOT NULL,
        //    Unit character varying NOT NULL,
        //    PRIMARY KEY(Id)
        //);
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Вольт','В');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Ампер','А');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Герц','Гц');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Метры в секунду','м/с');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Ускорение','м/с²');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Градус цельсия','°C');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Литры в час','м³/час');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Водородный показатель','pH');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Время','Час');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Процент','%');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('% Кислорода','% Кислорода');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Обороты','Об');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Градус','°');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Ватт на метр квадратный','Вт/м²');
        //INSERT INTO Settings.Units(UnitFull, Unit) VALUES('Давление','мм.рт.ст.');

        //CREATE SCHEMA IF NOT EXISTS Settings;
        //CREATE TABLE IF NOT EXISTS Settings.Stations
        //(
        //    Id serial NOT NULL,
        //    Title character varying NOT NULL DEFAULT 'Станция',
        //    ShortTitle character varying NOT NULL DEFAULT 'Стц',
        //    FullTitle character varying NOT NULL DEFAULT 'Установка №0 Станция',
        //    Href character varying NOT NULL DEFAULT 'Home',
        //    Station_Ip character varying NOT NULL DEFAULT 'http://192.168.0.0/',
        //    PRIMARY KEY(Id)
        //);
        //INSERT INTO Settings.Stations(Title, ShortTitle, FullTitle, Href) VALUES('Ветроэнергетическая установка','ВУЭ','Установка №1, Ветроэнергетическая установка','WindPower');
        //INSERT INTO Settings.Stations(Title, ShortTitle, FullTitle, Href) VALUES('Фотоэнергетическая установка','ФУЭ','Установка №2, Фотоэнергетическая установка','Photovoltaic');
        //INSERT INTO Settings.Stations(Title, ShortTitle, FullTitle, Href) VALUES('Солнечный коллектор','Коллектор','Установка №3, Солнечный коллектор','SolarCollector');
        //INSERT INTO Settings.Stations(Title, ShortTitle, FullTitle, Href) VALUES('Солнечный концентратор','Концентратор','Установка №4, Солнечный концентратор','SolarСoncentrator');
        //INSERT INTO Settings.Stations(Title, ShortTitle, FullTitle, Href) VALUES('Тепловой насос','Тепловой насос','Установка №5, Тепловой насос','HeatPump');
        //INSERT INTO Settings.Stations(Title, ShortTitle, FullTitle, Href) VALUES('Биоустановка','Биоустановка','Установка №6, Биоустановка','Bioplant');
        //INSERT INTO Settings.Stations(Title, ShortTitle, FullTitle, Href, Station_Ip) VALUES('Метеостанция','Метеостанция','Установка №7, Метеостанция','Meteorological','http://192.168.0.18/');

        //CREATE SCHEMA IF NOT EXISTS Settings;
        //CREATE TABLE IF NOT EXISTS Settings.Sensors
        //(
        //    Id serial NOT NULL,
        //    Title character varying NOT NULL DEFAULT 'Датчик',
        //    Station_id integer NOT NULL DEFAULT 0 REFERENCES Settings.Stations (Id),
        //    Value_min double precision NOT NULL DEFAULT 0,
        //    Value_max double precision NOT NULL DEFAULT 0,
        //    GraduationString character varying NOT NULL DEFAULT 'x',
        //    Unit_id integer REFERENCES Settings.Units (Id),
        //    PRIMARY KEY(Id)
        //);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(1, 1, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(2, 1, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(3, 1, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(4, 1, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(5, 1, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(6, 1, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(7, 1, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(8, 1, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(9, 1, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(10, 1, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(11, 1, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(12, 1, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(21, 2, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(22, 2, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(23, 2, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(24, 2, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(25, 2, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(26, 2, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(27, 2, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(28, 2, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(29, 2, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(30, 2, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(31, 2, 2);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(32, 2, 1);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(33, 2, 4);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(41, 'Температура горячей воды к баку', 3, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(42, 'Температура холодной воды к баку', 3, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(43, 'Температура бака', 3, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(44, 'Температура горячей воды из бака', 3, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(45, 'Температура холодной воды из бака', 3, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(46, 'Расход в бак', 3, 7);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(47, 'Расход из бака', 3, 7);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(56, 'Температура горячей воды к баку', 4, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(57, 'Температура холодной воды к баку', 4, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(58, 'Температура бака', 4, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(59, 'Температура горячей воды из бака', 4, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(60, 'Температура холодной воды из бака', 4, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(61, 'Расход в бак', 4, 7);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(62, 'Расход из бака', 4, 7);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(71, 'Температура горячей воды к баку', 5, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(72, 'Температура холодной воды к баку', 5, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(73, 'Температура бака', 5, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(74, 'Температура горячей воды из бака', 5, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(75, 'Температура холодной воды из бака', 5, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(76, 'Расход в бак', 5, 7);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(77, 'Расход из бака', 5, 7);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(78, 'Напряжение блока управления', 5, 2);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(79, 'Ток блока управления', 5, 1);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(88, 'Температура на выходе', 6, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(89, 'Показатель pH', 6, 8);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(90, 'Время работы насосов', 6, 9);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(91, 6, 10);
        //INSERT INTO settings.sensors(id, station_id, unit_id) VALUES(92, 6, 11);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(93, 'Число оборотов', 6, 12);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(94, 'Расход', 6, 7);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(103, 'Температура', 7, 6);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(104, 'Влажность', 7, 10);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(105, 'Давление', 7, 15);
        //INSERT INTO settings.sensors(id, title, station_id, value_min, value_max, unit_id) VALUES(106, 'Направление ветра', 7, 0, 359, 13);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(107, 'Скорость ветра', 7, 4);
        //INSERT INTO settings.sensors(id, title, station_id, unit_id) VALUES(108, 'Солнечная радиация', 7, 14);
        //SELECT setval('settings.sensors_id_seq', 108);

        //CREATE SCHEMA IF NOT EXISTS partman;
        //CREATE EXTENSION IF NOT EXISTS pg_partman SCHEMA partman;

        //        CREATE TABLE IF NOT EXISTS data.alldata
        //        (
        //            id serial NOT NULL,
        //    sensor_id integer NOT NULL,
        //    station_id integer NOT NULL,
        //    date_time timestamp without time zone NOT NULL,
        //    value_data double precision NOT NULL,
        //    CONSTRAINT alldata_pkey PRIMARY KEY(date_time, id),
        //    CONSTRAINT alldata_sensor_id_fkey FOREIGN KEY(sensor_id)
        //        REFERENCES settings.sensors(id) MATCH SIMPLE
        //        ON UPDATE NO ACTION
        //        ON DELETE NO ACTION,
        //    CONSTRAINT alldata_station_id_fkey FOREIGN KEY(station_id)
        //        REFERENCES settings.stations(id) MATCH SIMPLE
        //        ON UPDATE NO ACTION
        //        ON DELETE NO ACTION
        //) PARTITION BY RANGE(date_time);


        //SELECT partman.create_parent(
        //    p_parent_table := 'data.alldata',
        //    p_control := 'date_time',
        //    p_interval := '1 day',
        //    p_premake := 4,
        //    p_default_table := true,
        //    p_automatic_maintenance := 'on'
        //);

        //CREATE TABLE data.insert
        //(
        //    id integer,
        //    sensor_id integer,
        //    station_id integer,
        //    date_of_m date,
        //    time_of_m time without time zone,
        //    value_of_m double precision,
        //    unit_of_m character varying,
        //    PRIMARY KEY(id)
        //);

        //INSERT INTO data.alldata(sensor_id, station_id, date_time, value_data) SELECT sensor_id, station_id, date_of_m+time_of_m, value_of_m FROM data.insert;
        //SELECT * FROM partman.show_partitions('data.alldata');
        //SELECT partman.run_maintenance();
        //SELECT * FROM partman.check_default();
        //SELECT partman.partition_data_time('data.alldata');

        //CREATE TABLE IF NOT EXISTS settings.stations_x_sensors
        //(
        //    station_id integer NOT NULL,
        //    sensor_id integer NOT NULL,
        //    CONSTRAINT stations_x_sensors_pkey PRIMARY KEY (station_id, sensor_id),
        //    CONSTRAINT "Sensor_id_frg" FOREIGN KEY (sensor_id)
        //        REFERENCES settings.sensors (id) MATCH SIMPLE
        //        ON UPDATE NO ACTION
        //        ON DELETE NO ACTION
        //        NOT VALID,
        //    CONSTRAINT station_id_frg FOREIGN KEY (station_id)
        //        REFERENCES settings.stations (id) MATCH SIMPLE
        //        ON UPDATE NO ACTION
        //        ON DELETE NO ACTION
        //        NOT VALID
        //)
        #endregion Создание базы

        //SELECT s.id, s.title, s.shorttitle, s.fulltitle, s.href, s.station_ip, array_agg(s_x_s.sensor_id)
        //FROM settings.stations s
        //left join settings.stations_x_sensors s_x_s on s.id = s_x_s.statation_id
        //group by s.id, s.title, s.shorttitle, s.fulltitle, s.href, s.station_ip
        //order by id
    }
        //INSERT INTO data.alldata(
        //    sensor_id, station_id, date_time, value_data)
        //    VALUES(1, 1, '2013-12-01 00:00:00', 0.15625);
}