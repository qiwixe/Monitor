using BlazorBootstrap;
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
        public string? Unit_of_m { get; set; }
    }
    public class Sensor()
    {
        public int Id { get; set; }
        public int Station_Id { get; set; }
        public AlertColor Alert { get; set; } = AlertColor.Info;
        public IconName Icon { get; set; } = IconName.InfoCircleFill;
        public double Value_of_m { get; set; } = 0;
        public string GraduationString { get; set; } = "x";
        public int Value_min { get; set; }
        public int Value_max { get; set; }
        public bool Disconnected { get; set; }
    }

    public class GlobalPageProperty()
    {
        public static void UpdateDataArchive(List<Order> _lastData)
        {
            int _index = 0;
            int _index1 = 0;
            foreach (var (_PageChart, _chart) in LiveChartElement.AllChartsArchive["Archive"])
            {
                foreach (DefaultChartOption _lineChartDataset in _chart.DChartDataset)
                {
                    
                    foreach (var _data in _lastData)  
                        //perfm test x40 less
                        if (_data.Sensor_id == 103) {
                            _index++;
                            if(_index == 40)
                            {
                                _index = 0;
                                _lineChartDataset.Data.Add(_data.Value_of_m);
                            }
                        }
                }
                foreach (var _data in _lastData)
                    if (_data.Sensor_id == 103)
                    {
                        _index1++;
                        if (_index1 == 40)
                        {
                            _index1 = 0;
                            _chart.DChartData.Labels.Add(_data.Date_of_m + _data.Time_of_m);
                        }
                    }
                _PageChart.UpdateValuesAsync(_chart.DChartData);
            }
        }
    }

}

