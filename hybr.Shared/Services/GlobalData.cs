using BlazorBootstrap;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
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
        public int Unit_of_m { get; set; }
    }

    public class GlobalPageProperty()
    {
        public static void UpdateData(Dictionary<int, Order> _lastData)
        {
            foreach (var (_key,_a) in LiveChartElement.AllCharts)   
                foreach (var (_PageChart, _chart) in LiveChartElement.AllCharts[_key])
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
                        } else
                        {
                            _lineChartDataset.Data.RemoveAt(0);
                        }
                    }
                    if (_chart.DChartData.Labels.Count > _chart.maxLabelXasixCount)
                    {
                        _chart.DChartData.Labels.RemoveAt(0);
                    }
                    _chart.DChartData.Labels.Add(DateTime.Now.ToLongTimeString());
                    _PageChart.UpdateValuesAsync(_chart.DChartData);
                }
        }
        public static void UpdateDataArchive(List<Order> _lastData)
        {
            foreach (var (_PageChart, _chart) in LiveChartElement.AllChartsArchive["Archive"])
            {
                _chart.DChartData.Labels.Clear();
                foreach (DefaultChartOption _lineChartDataset in _chart.DChartDataset)
                {
                _lineChartDataset.Data.Clear();
                    foreach (var _data in _lastData)
                        if (_lineChartDataset.SensorId == _data.Sensor_id) {
                            _lineChartDataset.Data.Add(_data.Value_of_m);
                        }
                }
                foreach (var _data in _lastData) {
                    if(_chart.DChartData.Labels.Count == 0 || _chart.DChartData.Labels.Last() != _data.Date_of_m + " " + _data.Time_of_m)
                     _chart.DChartData.Labels.Add(_data.Date_of_m + " " + _data.Time_of_m);                               
                }
                _PageChart.UpdateAsync(_chart.DChartData, _chart.DChartOptions);
            }
        }
    }
    public class GlobalData()
    {
        public static async Task<Dictionary<int, Order>> FakeData()
        {
            List<Order> _listMeteoSensor = await HTTPClientSensor.Main();
            Dictionary<int, Order> _fakeData = new();
            if (_listMeteoSensor != null) 
            foreach (var _value in _listMeteoSensor)
                {
                    _fakeData[_value.Sensor_id] = _value;
                }
            #region Фейк Данные для ФЭУ(1)
            _fakeData[1] = (new Order
            {
                Sensor_id = 1,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[2] = (new Order
            {
                Sensor_id = 2,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[3] = (new Order
            {
                Sensor_id = 3,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[4] = (new Order
            {
                Sensor_id = 4,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[5] = (new Order
            {
                Sensor_id = 5,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[6] = (new Order
            {
                Sensor_id = 6,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[7] = (new Order
            {
                Sensor_id = 7,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[8] = (new Order
            {
                Sensor_id = 8,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[9] = (new Order
            {
                Sensor_id = 9,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[10] = (new Order
            {
                Sensor_id = 10,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            }); 
            _fakeData[11] = (new Order
            {
                Sensor_id = 11,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[12] = (new Order
            {
                Sensor_id = 12,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            #endregion Фейк Данные для ФЭУ(1)
            #region Фейк Данные для ВЭУ(2)
            _fakeData[21] = (new Order
            {
                Sensor_id = 21,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[22] = (new Order
            {
                Sensor_id = 22,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[23] = (new Order
            {
                Sensor_id = 23,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[24] = (new Order
            {
                Sensor_id = 24,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[25] = (new Order
            {
                Sensor_id = 25,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[26] = (new Order
            {
                Sensor_id = 26,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[27] = (new Order
            {
                Sensor_id = 27,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[28] = (new Order
            {
                Sensor_id = 28,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[29] = (new Order
            {
                Sensor_id = 29,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[30] = (new Order
            {
                Sensor_id = 30,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[31] = (new Order
            {
                Sensor_id = 31,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[32] = (new Order
            {
                Sensor_id = 32,
                Station_id = 1,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[33] = (new Order
            {
                Sensor_id = 33,
                Station_id = 2,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            #endregion Фейк Данные для ВЭУ(2)
            #region Фейк Данные для Коллектора(3)
            _fakeData[41] = (new Order
            {
                Sensor_id = 41,
                Station_id = 3,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[42] = (new Order
            {
                Sensor_id = 42,
                Station_id = 3,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[43] = (new Order
            {
                Sensor_id = 43,
                Station_id = 3,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[44] = (new Order
            {
                Sensor_id = 44,
                Station_id = 3,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[45] = (new Order
            {
                Sensor_id = 45,
                Station_id = 3,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[46] = (new Order
            {
                Sensor_id = 46,
                Station_id = 3,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            _fakeData[47] = (new Order
            {
                Sensor_id = 47,
                Station_id = 3,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(100) - 50,
            });
            #endregion Фейк Данные для Коллектора(3)
            #region Фейк Данные для метеостанции(7)
            _fakeData[106] = (new Order
            {
                Sensor_id = 106,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(360),
            });
            _fakeData[107] = (new Order
            {
                Sensor_id = 107,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = new Random().Next(15),
            });
            _fakeData[108] = (new Order
            {
                Sensor_id = 108,
                Station_id = 7,
                Date_of_m = DateTime.Now.ToString("dd:MM:yy"),
                Time_of_m = DateTime.Now.ToString("HH:mm:ss"),
                Value_of_m = (double)new Random().Next(10) / 30,
            });
            #endregion Фейк Данные для метеостанции(7)
            var _GData = SensorData.Graduation(_fakeData);
            GlobalPageProperty.UpdateData(_GData);
            SensorData.PreparationSensorData(_GData);
            return _fakeData;
        }
        public static async Task Data()
        {
            List<Order> _httpData = await HTTPClientSensor.Main();
            Dictionary<int, Order> _dictData = new();
            if (_httpData != null)
            {
                foreach (var _value in _httpData)
                {
                    _dictData[_value.Sensor_id] = _value;
                }
            var _gradData = SensorData.Graduation(_dictData);
            GlobalPageProperty.UpdateData(_gradData);
            SensorData.PreparationSensorData(_gradData);
            DataBase.InsertData(_gradData);
            }
            foreach (var (_key, _a) in UpdateGrid.AllUpdateGrid)
                UpdateGrid.AllUpdateGrid[_key].RefreshDataAsync();

        }
    }
    public class TimerUpdate()
    {
        public static Dictionary<string, bool> RepeatRender { get; set; } = new();
        public static async void StartTimer()
        {
            await DataBase.Init();
            if (!RepeatRender.TryGetValue("Timer",out var _bool))
            {
                RepeatRender["Timer"] = true;
                int i = 0;
                while (true)
                {
                    i++;
                    await Task.Delay(1000);
                    //GlobalData.FakeData();
                    GlobalData.Data();
                    if (i >= 60)
                    {
                        i = 0;
                    DataBase.CheckPart();
                    }
                }
            }
        }
    }
}

