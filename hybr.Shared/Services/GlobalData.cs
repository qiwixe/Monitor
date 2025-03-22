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
                UpdateGrid.AllUpdateGrid[_key].RefreshDataAsync();
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
            SensorData.PreparationSensorData(_fakeData);
            return _fakeData;
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

