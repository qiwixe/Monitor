using BlazorBootstrap;
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
        public bool Disconnected { get; set; }
    }
    public class GlobalPageProperty()
    {
        public static async Task UpdateDataAsync(Dictionary<int, Order> _lastData)
        {
            foreach (var (_key,_a) in LiveChartElement.AllCharts) {  
                foreach (var (_PageChart, _chart) in LiveChartElement.AllCharts[_key])
                {
                    if (_chart.DActive == true)
                    {
                    foreach (DefaultChartOption _lineChartDataset in _chart.DChartDataset)
                    {
                        if (_lineChartDataset.Data.Count > _chart.maxLabelXasixCount)
                        {
                            _lineChartDataset.Data.RemoveAt(0);
                        }
                        if (_lastData.TryGetValue(_lineChartDataset.SensorId, out var _bool)) 
                        { 
                            _lineChartDataset.Data.Add(_lastData[_lineChartDataset.SensorId].Value_of_m);
                        }
                    }
                    if (_chart.DChartData.Labels.Count > _chart.maxLabelXasixCount)
                    {
                        _chart.DChartData.Labels.RemoveAt(0);
                    }
                    //peredelat
                    _chart.DChartData.Labels.Add(_lastData[106].Time_of_m);
                    await _PageChart.UpdateValuesAsync(_chart.DChartData);
                    }
                }
                UpdateGrid.AllUpdateGrid[_key].RefreshDataAsync();
            }
        }
    }
    public class GlobalSensorData()
    {
        public static Dictionary<int, Sensor> AllSensors { get; } = 
        new Dictionary<int, Sensor>
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

        public static async Task<Dictionary<int, Order>> FakeData()
        {
            List<Order> _listMeteoSensor = await HTTPClientSensor.Main();
            Dictionary<int, Order> _fakeData = new();
            if (_listMeteoSensor != null) 
            foreach (var _value in _listMeteoSensor)
                {
                    _fakeData[_value.Sensor_id] = _value;
                }
            #region Данные для ФЭУ(1)
            //_fakeData.Add(new Order
            //{
            //    Sensor_id = 1,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //});
            //_fakeData.Add(new Order
            //{
            //    Sensor_id = 2,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 3,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 4,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 5,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 6,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 7,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 8,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 9,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 10,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //}); _fakeData.Add(new Order
            //{
            //    Sensor_id = 11,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //});
            //_fakeData.Add(new Order
            //{
            //    Sensor_id = 12,
            //    Station_id = 1,
            //    Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
            //    Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
            //    Value_of_m = new Random().Next(100) - 50,
            //});
            #endregion ФЭУ(1)
            #region Данные для метеостанции(7)
            _fakeData[106]=(new Order
            {
                Sensor_id = 106,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(360),
            });
            _fakeData[107] =(new Order
            {
                Sensor_id = 107,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(15),
            });
            _fakeData[108]=(new Order
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
        public static void PreparationSensorData(Dictionary<int, Order> _lastData)
        {
            foreach (var (_key, _value) in GlobalSensorData.AllSensors)
            {
                if (_lastData.TryGetValue(_key, out var _bool))
                {
                    if (_value.Value_min < _lastData[_key].Value_of_m && _lastData[_key].Value_of_m < _value.Value_max)
                    {
                        _value.Alert = AlertColor.Success;
                        _value.Icon = IconName.CheckCircleFill;
                    }
                    else if (_value.Value_min == _lastData[_key].Value_of_m || _lastData[_key].Value_of_m == _value.Value_max)
                    {
                        _value.Alert = AlertColor.Warning;
                        _value.Icon = IconName.ExclamationCircleFill;
                    }
                    else
                    {
                        _value.Alert = AlertColor.Danger;
                        _value.Icon = IconName.XCircleFill;
                    }
                    _value.Value_of_m = _lastData[_key].Value_of_m;
                    _value.Disconnected = false;
                }
                else
                {
                    _value.Alert = AlertColor.Danger;
                    _value.Icon = IconName.XCircleFill;
                    _value.Value_of_m = 0;
                    _value.Disconnected = true;
                }
            }
        }
    }
    public class TimerUpdate()
    {
        public static Dictionary<string, bool> RepeatRender { get; set; } = new();
        public static async void StartTimer()
        {
            if (!RepeatRender.TryGetValue("Timer",out var _bool))
            {
                RepeatRender["Timer"] = true;
                while (true)
                {
                    await Task.Delay(1000);
                    GlobalData.FakeData();
                }
            }
        }
    }
}

