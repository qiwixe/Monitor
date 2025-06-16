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
                        } else if (_lineChartDataset.Data.Count > 0)
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
            Dictionary<int, Order> _fakeData = new();
            #region Фейк Данные для ФЭУ(1)
            _fakeData[1] = (new Order
            {
                Sensor_id = 1,
                Station_id = 1,
                Value_of_m = new Random().Next(1) + 6,
            });
            _fakeData[2] = (new Order
            {
                Sensor_id = 2,
                Station_id = 1,
                Value_of_m = new Random().Next(4) + 110,
            }); 
            _fakeData[3] = (new Order
            {
                Sensor_id = 3,
                Station_id = 1,
                Value_of_m = new Random().Next(1) + 8,
            }); 
            _fakeData[4] = (new Order
            {
                Sensor_id = 4,
                Station_id = 1,
                Value_of_m = new Random().Next(4) + 270,
            }); 
            _fakeData[5] = (new Order
            {
                Sensor_id = 5,
                Station_id = 1,
                Value_of_m = new Random().Next(1) + 10,
            }); 
            _fakeData[6] = (new Order
            {
                Sensor_id = 6,
                Station_id = 1,
                Value_of_m = new Random().Next(4) + 330,
            }); 
            _fakeData[7] = (new Order
            {
                Sensor_id = 7,
                Station_id = 1,
                Value_of_m = new Random().Next(1) + 1,
            }); 
            _fakeData[8] = (new Order
            {
                Sensor_id = 8,
                Station_id = 1,
                Value_of_m = new Random().Next(1) + 24,
            }); 
            _fakeData[9] = (new Order
            {
                Sensor_id = 9,
                Station_id = 1,
                Value_of_m = new Random().Next(1) + 1,
            }); 
            _fakeData[10] = (new Order
            {
                Sensor_id = 10,
                Station_id = 1,
                Value_of_m = new Random().Next(1) + 24,
            }); 
            _fakeData[11] = (new Order
            {
                Sensor_id = 11,
                Station_id = 1,
                Value_of_m = 10,
            });
            _fakeData[12] = (new Order
            {
                Sensor_id = 12,
                Station_id = 1,
                Value_of_m = 220,
            });
            _fakeData[103] = (new Order
            {
                Sensor_id = 103,
                Station_id = 7,
                Value_of_m = 33,
            });
            _fakeData[104] = (new Order
            {
                Sensor_id = 104,
                Station_id = 7,
                Value_of_m = 47,
            });
            _fakeData[105] = (new Order
            {
                Sensor_id = 104,
                Station_id = 7,
                Value_of_m = 733.4,
            });
            _fakeData[106] = (new Order
            {
                Sensor_id = 104,
                Station_id = 7,
                Value_of_m = 167,
            });
            _fakeData[107] = (new Order
            {
                Sensor_id = 104,
                Station_id = 7,
                Value_of_m = 4.2,
            });
            _fakeData[108] = (new Order
            {
                Sensor_id = 104,
                Station_id = 7,
                Value_of_m = 657,
            });

            #endregion Фейк Данные для ФЭУ(1)
            var _GData = SensorData.Graduation(_fakeData);
            GlobalPageProperty.UpdateData(_GData);
            SensorData.PreparationSensorData(_GData);
            //DataBase.InsertData(_GData);
            return _fakeData;
        }
        public static async Task Data()
        {
            List<Order> _httpData = await HTTPClientSensor.Main();
            Dictionary<int, Order> _dictData = new();
            if (_httpData.Count != 0)
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
            else
            {
                GlobalPageProperty.UpdateData(new());
                SensorData.PreparationSensorData(new());
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
                    if (i >= 3600)
                    {
                        i = 0;
                    DataBase.CheckPart();
                    }
                }
            }
        }
    }
}

