using BlazorBootstrap;
using Newtonsoft.Json;
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
        public IconName Icon { get; set; } = IconName.InfoCircleFill;
        public double Value_of_m { get; set; } = 0;
        public int Value_min { get; set; }
        public int Value_max { get; set; }
    }
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
    public class Chart()
    {
        public bool DActive { get; set; } = false;
        public required int maxLabelXasixCount = 1;
        public required ChartData DChartData { get; set; }
        public required List<IChartDataset> DChartDataset { get; set; }
        public IChartOptions DChartOptions { get; set; } = new LiveChartOptions();
    }
    public class SensorGrid
    {
        public static Grid<Sensor> SensorGrid0 { get; set; } = default!;
        public static Grid<Sensor> SensorGrid1 { get; set; } = default!;
        public static Grid<Sensor> SensorGrid2 { get; set; } = default!;
        public static Grid<Sensor> SensorGrid3 { get; set; } = default!;
    }
    public class ChartSettings()
    {
        public static IChartDataset WindPowerChartDataSetSensor1 { get; } =
        new DefaultChartOption
        {
            SensorId = 1,
            Label = $"Напряжение 1, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)"
        };
        public static IChartDataset WindPowerChartDataSetSensor2 { get; } =
        new DefaultChartOption
        {
            SensorId = 2,
            Label = $"Ток 2, A",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor3 { get; } =
        new DefaultChartOption
        {
            SensorId = 3,
            Label = $"Напряжение 3, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor4 { get; } =
        new DefaultChartOption
        {
            SensorId = 4,
            Label = $"Ток 4, A",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor5 { get; } =
        new DefaultChartOption
        {
            SensorId = 5,
            Label = $"Напряжение 5, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor6 { get; } =
        new DefaultChartOption
        {
            SensorId = 6,
            Label = $"Ток 6, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor7 { get; } =
        new DefaultChartOption
        {
            SensorId = 7,
            Label = $"Напряжение 7, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor8 { get; } =
        new DefaultChartOption
        {
            SensorId = 8,
            Label = $"Ток 8, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor9 { get; } =
        new DefaultChartOption
        {
            SensorId = 9,
            Label = $"Напряжение 9, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor10 { get; } =
        new DefaultChartOption
        {
            SensorId = 10,
            Label = $"Ток 10, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor11 { get; } =
        new DefaultChartOption
        {
            SensorId = 11,
            Label = $"Напряжение 11, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor12 { get; } =
        new DefaultChartOption
        {
            SensorId = 12,
            Label = $"Ток 12, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };

        public static IChartDataset MeteorologicalChartDataSetSensor103 { get; } = 
        new DefaultChartOption
        {
            SensorId = 103,
            Label = $"Температура, °C",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset MeteorologicalChartDataSetSensor104 { get; } = 
        new DefaultChartOption
        {
            SensorId = 104,
            Label = $"Влажность, %",
            Data = new(),
            BackgroundColor = "rgba(255, 255, 0, 0.7)",
            BorderColor = "rgba(255, 255, 0, 0.7)",
        };
        public static IChartDataset MeteorologicalChartDataSetSensor105 { get; } = 
        new DefaultChartOption
        {
            SensorId = 105,
            Label = $"Давление, мм.рт.ст.",
            Data = new(),
            BackgroundColor = "rgba(0, 255, 0, 0.7)",
            BorderColor = "rgba(0, 255, 0, 0.7)",
        };
        public static IChartDataset MeteorologicalChartDataSetSensor108 { get; } = 
        new DefaultChartOption
        {
            SensorId = 108,
            Label = $"Солнечная радиация, Вт/м2",
            Data = new(),
            BackgroundColor = "rgba(0, 0, 255, 0.7)",
            BorderColor = "rgba(0, 0, 255, 0.7)",
        };
    }
    public class ChartDataSet()
    {
        public static List<IChartDataset> WindPowerChartDataSetVoltage1 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor1, ChartSettings.WindPowerChartDataSetSensor3, ChartSettings.WindPowerChartDataSetSensor5 };
        public static List<IChartDataset> WindPowerChartDataSetAmperage1 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor2, ChartSettings.WindPowerChartDataSetSensor4, ChartSettings.WindPowerChartDataSetSensor6 };
        public static List<IChartDataset> WindPowerChartDataSetVoltage2 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor7, ChartSettings.WindPowerChartDataSetSensor9 };
        public static List<IChartDataset> WindPowerChartDataSetAmperage2 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor8, ChartSettings.WindPowerChartDataSetSensor10 };
        public static List<IChartDataset> WindPowerChartDataSetVoltage3 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor11 };
        public static List<IChartDataset> WindPowerChartDataSetAmperage3 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor12 };
        
        public static List<IChartDataset> MeteorologicalChartDataSetTemperature { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor103 };
        public static List<IChartDataset> MeteorologicalChartDataSetHumidity { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor104 };
        public static List<IChartDataset> MeteorologicalChartDataSetPressure { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor105 };
        public static List<IChartDataset> MeteorologicalChartDataSetSolarRadiation { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor108 };

    }
    public class GlobalPageProperty()
    {
        public static Dictionary<string, Dictionary<LineChart, Chart>> AllCharts { get; set; } = new();
        public static List<Grid<Sensor>> allGrid = new();

        public static LineChart WindPowerChartVoltage1 { get; set; } = default!;
        public static LineChart WindPowerChartAmperage1 { get; set; } = default!;
        public static LineChart WindPowerChartVoltage2 { get; set; } = default!;
        public static LineChart WindPowerChartAmperage2 { get; set; } = default!;
        public static LineChart WindPowerChartVoltage3 { get; set; } = default!;
        public static LineChart WindPowerChartAmperage3 { get; set; } = default!;

        public static LineChart MeteorologicalChartTemperature { get; set; } = default!;
        public static LineChart MeteorologicalChartHumidity { get; set; } = default!;
        public static LineChart MeteorologicalChartPressure { get; set; } = default!;
        public static LineChart MeteorologicalChartSolarRadiation { get; set;} = default!;

        public static void AllPageProperty(string _PageName)
        {
            switch (_PageName)
            {
                case ("Home"):
                    allGrid.Add(SensorGrid.SensorGrid3);
                    break;
                case ("WindPower"):
                    AllCharts["WindPower"] = new Dictionary<LineChart, Chart>()
                    {
                        [WindPowerChartVoltage1] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.WindPowerChartDataSetVoltage1 },
                            DChartDataset = ChartDataSet.WindPowerChartDataSetVoltage1
                        },
                        [WindPowerChartAmperage1] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.WindPowerChartDataSetAmperage1 },
                            DChartDataset = ChartDataSet.WindPowerChartDataSetAmperage1
                        },
                        [WindPowerChartVoltage2] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.WindPowerChartDataSetVoltage2 },
                            DChartDataset = ChartDataSet.WindPowerChartDataSetVoltage2
                        },
                        [WindPowerChartAmperage2] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.WindPowerChartDataSetAmperage2 },
                            DChartDataset = ChartDataSet.WindPowerChartDataSetAmperage2
                        },
                        [WindPowerChartVoltage3] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.WindPowerChartDataSetVoltage3 },
                            DChartDataset = ChartDataSet.WindPowerChartDataSetVoltage3
                        },
                        [WindPowerChartAmperage3] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.WindPowerChartDataSetAmperage3 },
                            DChartDataset = ChartDataSet.WindPowerChartDataSetAmperage3
                        },
                    };
                    break;
                case ("Meteorological"):
                    AllCharts["Meteorological"] = new Dictionary<LineChart, Chart>()
                    {
                        [MeteorologicalChartTemperature] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataSetTemperature },
                            DChartDataset = ChartDataSet.MeteorologicalChartDataSetTemperature
                        },
                        [MeteorologicalChartHumidity] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataSetHumidity },
                            DChartDataset = ChartDataSet.MeteorologicalChartDataSetHumidity
                        },
                        [MeteorologicalChartPressure] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataSetPressure },
                            DChartDataset = ChartDataSet.MeteorologicalChartDataSetPressure
                        },
                        [MeteorologicalChartSolarRadiation] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataSetSolarRadiation },
                            DChartDataset = ChartDataSet.MeteorologicalChartDataSetSolarRadiation
                        }
                    };
                    allGrid.Add(SensorGrid.SensorGrid0);
                    allGrid.Add(SensorGrid.SensorGrid1);
                    allGrid.Add(SensorGrid.SensorGrid2);
                    break;


            }
            foreach (var (_key, _a) in AllCharts)
            {
                if (_key == _PageName)
                {
                    foreach (var (_b, _chart) in AllCharts[_key])
                    _chart.DActive = true;
                }
                else
                {
                    foreach (var (_b, _chart) in AllCharts[_key])
                    _chart.DActive = false;
                }
            }
        }
        public static async Task UpdateDataAsync(List<Order> _lastData)
        {
            foreach (var (_key,_a) in AllCharts) 
            foreach (var (_PageChart, _chart) in AllCharts[_key])
            {
                if (_chart.DActive == true)
                {
                    await _PageChart.InitializeAsync(_chart.DChartData, _chart.DChartOptions);
                foreach (DefaultChartOption _lineChartDataset in _chart.DChartDataset)
                {
                    if (_lineChartDataset.Data.Count > _chart.maxLabelXasixCount)
                    {
                        _lineChartDataset.Data.RemoveAt(0);
                    }
                    foreach (var _data in _lastData)
                    {
                        if (_data.Sensor_id == _lineChartDataset.SensorId)
                        {
                            _lineChartDataset.Data.Add(_data.Value_of_m);
                        }
                    }    
                }
                if (_chart.DChartData.Labels.Count > _chart.maxLabelXasixCount)
                {
                    _chart.DChartData.Labels.RemoveAt(0);
                }
                _chart.DChartData.Labels.Add(_lastData[0].Time_of_m);
                await _PageChart.UpdateValuesAsync(_chart.DChartData);
                }
            }
            foreach (Grid<Sensor> _grid in allGrid)
            {
                _grid.RefreshDataAsync();
            }
        }
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


        public static Dictionary<string, bool>  RepeatRender { get; set; } = new();
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
        public static async Task<List<Order>> FakeData()
        {
            List<Order> _listMeteoSensor = await HTTPClientSensor.Main();
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
            //_fakeData.Add(new Order
            //{
            //    Sensor_id = 103,
            //    Station_id = 7,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //});
            //_fakeData.Add(new Order
            //{
            //    Sensor_id = 104,
            //    Station_id = 7,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100),
            //});
            //_fakeData.Add(new Order
            //{
            //    Sensor_id = 105,
            //    Station_id = 7,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(200) + 700,
            //});
            _fakeData.Add(_listMeteoSensor[0]);
            _fakeData.Add(_listMeteoSensor[1]);
            _fakeData.Add(_listMeteoSensor[2]);
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

            await GlobalPageProperty.UpdateDataAsync(_fakeData);
            PreparationSensorData(_fakeData);
            return _fakeData;
        }
        public static void PreparationSensorData(List<Order> _lastData)
        {
            foreach (var _data in _lastData)
            {
                if (GlobalSensorData.AllSensors[_data.Sensor_id].Value_min < _data.Value_of_m &&
                _data.Value_of_m < GlobalSensorData.AllSensors[_data.Sensor_id].Value_max)
                {
                    GlobalSensorData.AllSensors[_data.Sensor_id].Alert = AlertColor.Success;
                    GlobalSensorData.AllSensors[_data.Sensor_id].Icon = IconName.CheckCircleFill;
                    GlobalSensorData.AllSensors[_data.Sensor_id].Value_of_m = _data.Value_of_m;
                }
                else
                {
                    GlobalSensorData.AllSensors[_data.Sensor_id].Alert = AlertColor.Warning;
                    GlobalSensorData.AllSensors[_data.Sensor_id].Icon = IconName.ExclamationCircleFill;
                    GlobalSensorData.AllSensors[_data.Sensor_id].Value_of_m = _data.Value_of_m;
                }
            }
        }
    }
    public class TimerUpdate()
    {
        public static async void StartTimer()
        {
            if (!GlobalData.RepeatRender.TryGetValue("Timer",out var _bool))
            {
                GlobalData.RepeatRender["Timer"] = true;
                while (true)
                {
                    await Task.Delay(1000);
                    GlobalData.FakeData();
                }
            }
        }
    }
}

