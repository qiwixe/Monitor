using BlazorBootstrap;
using hybr.Shared.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hybr.Shared.Services
{

    public class Order()
    {
        [Key]
        public int Id { get; set; }
        public int Sensor_id { get; set; }
        public int Station_id { get; set; }
        public string? Date_of_m { get; set; }
        public string? Time_of_m { get; set; }
        public double Value_of_m { get; set; }
        public string? Unit_of_m { get; set; }
    }
    public class Sensor()
    {
        public int Id { get; set; }
        public AlertColor Alert { get; set; } = AlertColor.Info;
        public double Value_of_m { get; set; } = 0;
        public int Value_min { get; set; }
        public int Value_max { get; set; }
    }
    public class SQLstring()
    {
        #region SQL строки для ДБ
        public static string Connection { get; } = "Host=localhost;Username=postgres;Password=postgres;Database=station_archive";
        public static string All { get; } = "SELECT * FROM backup_201311_3 order by id";
        public static string WindPower { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 1 order by id";
        public static string Photovoltaic { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 2 order by id";
        public static string SolarCollector { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 3 order by id";
        public static string SolarСoncentrator { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 4 order by id";
        public static string HeatPump { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 5 order by id";
        public static string Bioplant { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 6 order by id";
        public static string Meteorological { get; } = "SELECT * FROM backup_201311_3 WHERE station_id = 7 order by id";
        #endregion SQL строки для ДБ
    }
    public class ChartDataSet()
    {
        #region Настройки данных для графиков
        public static List<IChartDataset> MeteorologicalChartDataTemperature { get; } = new List<IChartDataset> {new DefaultChartOption
        {
            Label = $"Температура, °C",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        } };
        public static List<IChartDataset> MeteorologicalChartDataHumidity { get; } = new List<IChartDataset>{new DefaultChartOption
        {
            Label = $"Влажность, %",
            Data = new(),
            BackgroundColor = "rgba(255, 255, 0, 0.7)",
            BorderColor = "rgba(255, 255, 0, 0.7)",
        } };
        public static List<IChartDataset> MeteorologicalChartDataPressure { get; } = new List<IChartDataset>{new DefaultChartOption
        {
            Label = $"Давление, мм.рт.ст.",
            Data = new(),
            BackgroundColor = "rgba(0, 255, 0, 0.7)",
            BorderColor = "rgba(0, 255, 0, 0.7)",
        } };
        public static List<IChartDataset> MeteorologicalChartDataSolarRadiation { get; } = new List<IChartDataset>{new DefaultChartOption
        {
            Label = $"Солнечная радиация, Вт/м2",
            Data = new(),
            BackgroundColor = "rgba(0, 0, 255, 0.7)",
            BorderColor = "rgba(0, 0, 255, 0.7)",
        } };
        #endregion Настройки данных для графиков
    }
    public class GlobalChartData()
    {
        #region Настройки графиков
        public static ChartData MeteorologicalChartTemperature { get; } = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataTemperature };
        public static ChartData MeteorologicalChartHumidity { get; } = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataHumidity };
        public static ChartData MeteorologicalChartPressure { get; } = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataPressure };
        public static ChartData MeteorologicalChartSolarRadiation { get; } = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataSolarRadiation };
        #endregion Настройки графиков
    }
    public class GlobalSensorData()
    {
        public static Dictionary<int, Sensor> AllSensors { get; } = new Dictionary<int, Sensor>
        {
            [1] = (new Sensor
            {
                Id = 1,
                Value_min = -50,
                Value_max = 50,
            }),
            [2] = (new Sensor
            {
                Id = 2,
                Value_min = -50,
                Value_max = 50,
            }),
            [3] = (new Sensor
            {
                Id = 3,
                Value_min = -50,
                Value_max = 50,
            }),
            [4] = (new Sensor
            {
                Id = 4,
                Value_min = -50,
                Value_max = 50,
            }),
            [5] = (new Sensor
            {
                Id = 5,
                Value_min = -50,
                Value_max = 50,
            }),
            [6] = (new Sensor
            {
                Id = 6,
                Value_min = -50,
                Value_max = 50,
            }),
            [7] = (new Sensor
            {
                Id = 7,
                Value_min = -50,
                Value_max = 50,
            }),
            [8] = (new Sensor
            {
                Id = 8,
                Value_min = -50,
                Value_max = 50,
            }),
            [9] = (new Sensor
            {
                Id = 9,
                Value_min = -50,
                Value_max = 50,
            }),
            [10] = (new Sensor
            {
                Id = 10,
                Value_min = -50,
                Value_max = 50,
            }),
            [11] = (new Sensor
            {
                Id = 11,
                Value_min = -50,
                Value_max = 50,
            }),
            [12] = (new Sensor
            {
                Id = 12,
                Value_min = -50,
                Value_max = 50,
            }),
            [103] = (new Sensor
            {
                Id = 103,
                Value_min = -50,
                Value_max = 50,
            }),
            [104] = (new Sensor
            {
                Id = 104,
                Value_min = 0,
                Value_max = 100,
            }),
            [105] = (new Sensor
            {
                Id = 105,
                Value_min = 700,
                Value_max = 900,
            }),
            [106] = (new Sensor
            {
                Id = 106,
                Value_min = 0,
                Value_max = 360,
            }),
            [107] = (new Sensor
            {
                Id = 107,
                Value_min = 0,
                Value_max = 15,
            }),
            [108] = (new Sensor
            {
                Id = 108,
                Value_min = 0,
                Value_max = 600,
            })
        };
    }
    public class GlobalData()
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
            DataMeteorological = await Db.Data(SQLstring.Meteorological);
            DataAll = await Db.Data(SQLstring.All);
            DataBioplant = await Db.Data(SQLstring.Bioplant);
            DataHeatPump = await Db.Data(SQLstring.HeatPump);
            DataSolarСoncentrator = await Db.Data(SQLstring.SolarСoncentrator);
            DataSolarCollector = await Db.Data(SQLstring.SolarCollector);
            DataPhotovoltaic = await Db.Data(SQLstring.Photovoltaic);
            DataWindPower = await Db.Data(SQLstring.WindPower);
        }
        public static List<Order> FakeData()
        {
            List<Order> _fakeData = new();
            #region Данные для ФЭУ(1)
            _fakeData.Add(new Order
            {
                Sensor_id = 1,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData.Add(new Order
            {
                Sensor_id = 2,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 3,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 4,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 5,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 6,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 7,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 8,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 9,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 10,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); _fakeData.Add(new Order
            {
                Sensor_id = 11,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData.Add(new Order
            {
                Sensor_id = 12,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            #endregion ФЭУ(1)
            #region Данные для метеостанции(7)
            _fakeData.Add(new Order
            {
                Sensor_id = 103,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData.Add(new Order
            {
                Sensor_id = 104,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100),
            });
            _fakeData.Add(new Order
            {
                Sensor_id = 105,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(200) + 700,
            });
            _fakeData.Add(new Order
            {
                Sensor_id = 106,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(360),
            });
            _fakeData.Add(new Order
            {
                Sensor_id = 107,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(15),
            });
            _fakeData.Add(new Order
            {
                Sensor_id = 108,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(600),
            });
            #endregion Данные для метеостанции(7)


            PreparationSensorData(_fakeData);
            return _fakeData;
        }
        public static void PreparationSensorData(List<Order> _lastFakeData)
        {
            foreach (var _data in _lastFakeData)
            {
                if (GlobalSensorData.AllSensors[_data.Sensor_id].Value_min < _data.Value_of_m &&
                _data.Value_of_m < GlobalSensorData.AllSensors[_data.Sensor_id].Value_max)
                {
                    GlobalSensorData.AllSensors[_data.Sensor_id].Alert = AlertColor.Success;
                    GlobalSensorData.AllSensors[_data.Sensor_id].Value_of_m = _data.Value_of_m;
                }
                else
                {
                    GlobalSensorData.AllSensors[_data.Sensor_id].Alert = AlertColor.Warning;
                    GlobalSensorData.AllSensors[_data.Sensor_id].Value_of_m = _data.Value_of_m;
                }
            }
        }
    }
}

