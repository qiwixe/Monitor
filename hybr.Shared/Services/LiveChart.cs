using BlazorBootstrap;

namespace hybr.Shared.Services
{
    public class Chart()
    {
        public bool DActive { get; set; } = false;
        public required int maxLabelXasixCount = 1;
        public required ChartData DChartData { get; set; }
        public required List<IChartDataset> DChartDataset { get; set; }
        public IChartOptions DChartOptions { get; set; } = new LiveChartOptions();
    }
    public class ChartSettings()
    {
        public static IChartDataset PhotovoltaicChartDataSetSensor1 { get; } =
        new DefaultChartOption
        {
            SensorId = 1,
            Label = $"Напряжение 1, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)"
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor2 { get; } =
        new DefaultChartOption
        {
            SensorId = 2,
            Label = $"Ток 2, A",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor3 { get; } =
        new DefaultChartOption
        {
            SensorId = 3,
            Label = $"Напряжение 3, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor4 { get; } =
        new DefaultChartOption
        {
            SensorId = 4,
            Label = $"Ток 4, A",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor5 { get; } =
        new DefaultChartOption
        {
            SensorId = 5,
            Label = $"Напряжение 5, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor6 { get; } =
        new DefaultChartOption
        {
            SensorId = 6,
            Label = $"Ток 6, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor7 { get; } =
        new DefaultChartOption
        {
            SensorId = 7,
            Label = $"Напряжение 7, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor8 { get; } =
        new DefaultChartOption
        {
            SensorId = 8,
            Label = $"Ток 8, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor9 { get; } =
        new DefaultChartOption
        {
            SensorId = 9,
            Label = $"Напряжение 9, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor10 { get; } =
        new DefaultChartOption
        {
            SensorId = 10,
            Label = $"Ток 10, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor11 { get; } =
        new DefaultChartOption
        {
            SensorId = 11,
            Label = $"Напряжение 11, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset PhotovoltaicChartDataSetSensor12 { get; } =
        new DefaultChartOption
        {
            SensorId = 12,
            Label = $"Ток 12, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };

        public static IChartDataset WindPowerChartDataSetSensor21 { get; } =
        new DefaultChartOption
        {
            SensorId = 21,
            Label = $"Напряжение 1, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)"
        };
        public static IChartDataset WindPowerChartDataSetSensor22 { get; } =
        new DefaultChartOption
        {
            SensorId = 22,
            Label = $"Ток 2, A",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor23 { get; } =
        new DefaultChartOption
        {
            SensorId = 23,
            Label = $"Напряжение 3, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor24 { get; } =
        new DefaultChartOption
        {
            SensorId = 24,
            Label = $"Ток 4, A",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor25 { get; } =
        new DefaultChartOption
        {
            SensorId = 25,
            Label = $"Напряжение 5, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor26 { get; } =
        new DefaultChartOption
        {
            SensorId = 26,
            Label = $"Ток 6, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor27 { get; } =
        new DefaultChartOption
        {
            SensorId = 27,
            Label = $"Напряжение 7, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor28 { get; } =
        new DefaultChartOption
        {
            SensorId = 28,
            Label = $"Ток 8, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor29 { get; } =
        new DefaultChartOption
        {
            SensorId = 29,
            Label = $"Напряжение 9, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor30 { get; } =
        new DefaultChartOption
        {
            SensorId = 30,
            Label = $"Ток 10, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor31 { get; } =
        new DefaultChartOption
        {
            SensorId = 31,
            Label = $"Напряжение 11, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor32 { get; } =
        new DefaultChartOption
        {
            SensorId = 32,
            Label = $"Ток 12, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor33 { get; } =
        new DefaultChartOption
        {
            SensorId = 33,
            Label = $"Ток 12, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };

        public static IChartDataset WindPowerChartDataSetSensor41 { get; } =
        new DefaultChartOption
        {
            SensorId = 41,
            Label = $"Напряжение 1, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)"
        };
        public static IChartDataset WindPowerChartDataSetSensor42 { get; } =
        new DefaultChartOption
        {
            SensorId = 42,
            Label = $"Ток 2, A",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor43 { get; } =
        new DefaultChartOption
        {
            SensorId = 43,
            Label = $"Напряжение 3, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor44 { get; } =
        new DefaultChartOption
        {
            SensorId = 44,
            Label = $"Ток 4, A",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor45 { get; } =
        new DefaultChartOption
        {
            SensorId = 45,
            Label = $"Напряжение 5, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor46 { get; } =
        new DefaultChartOption
        {
            SensorId = 46,
            Label = $"Ток 6, В",
            Data = new(),
            BackgroundColor = "rgba(255, 0, 0, 0.7)",
            BorderColor = "rgba(255, 0, 0, 0.7)",
        };
        public static IChartDataset WindPowerChartDataSetSensor47 { get; } =
        new DefaultChartOption
        {
            SensorId = 47,
            Label = $"Напряжение 7, В",
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

        public static IChartDataset MeteorologicalChartDataSetSensor103Archive { get; } =
        new DefaultChartOption
        {
            SensorId = 108,
            Label = $"Солнечная радиация, Вт/м2",
            Data = new(),
            BackgroundColor = "rgba(0, 0, 255, 0.7)",
            BorderColor = "rgba(0, 0, 255, 0.7)",
            PointRadius = [1],
        };
    }
    public class ChartDataSet()
    {
        public static List<IChartDataset> WindPowerChartDataSetVoltage1 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor21, ChartSettings.WindPowerChartDataSetSensor23, ChartSettings.WindPowerChartDataSetSensor25 };
        public static List<IChartDataset> WindPowerChartDataSetAmperage1 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor22, ChartSettings.WindPowerChartDataSetSensor24, ChartSettings.WindPowerChartDataSetSensor26 };
        public static List<IChartDataset> WindPowerChartDataSetVoltage2 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor27, ChartSettings.WindPowerChartDataSetSensor29 };
        public static List<IChartDataset> WindPowerChartDataSetAmperage2 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor28, ChartSettings.WindPowerChartDataSetSensor30 };
        public static List<IChartDataset> WindPowerChartDataSetVoltage3 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor31 };
        public static List<IChartDataset> WindPowerChartDataSetAmperage3 { get; } = new List<IChartDataset> { ChartSettings.WindPowerChartDataSetSensor32 };

        public static List<IChartDataset> MeteorologicalChartDataSetTemperature { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor103 };
        public static List<IChartDataset> MeteorologicalChartDataSetHumidity { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor104 };
        public static List<IChartDataset> MeteorologicalChartDataSetPressure { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor105 };
        public static List<IChartDataset> MeteorologicalChartDataSetSolarRadiation { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor108 };

        public static List<IChartDataset> MeteorologicalChartDataSetTemperatureArchive { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor103Archive };
    }
    public class LiveChartElement()
    {
        public static LineChart WindPowerChartVoltage1 { get; set; } = default!;
        public static LineChart WindPowerChartAmperage1 { get; set; } = default!;
        public static LineChart WindPowerChartVoltage2 { get; set; } = default!;
        public static LineChart WindPowerChartAmperage2 { get; set; } = default!;
        public static LineChart WindPowerChartVoltage3 { get; set; } = default!;
        public static LineChart WindPowerChartAmperage3 { get; set; } = default!;

        public static LineChart MeteorologicalChartTemperature { get; set; } = default!;
        public static LineChart MeteorologicalChartHumidity { get; set; } = default!;
        public static LineChart MeteorologicalChartPressure { get; set; } = default!;
        public static LineChart MeteorologicalChartSolarRadiation { get; set; } = default!;

        public static LineChart MeteorologicalChartTemperatureArchive { get; set; } = default!;

        public static Dictionary<string, Dictionary<LineChart, Chart>> AllCharts { get; set; } = new();
        public static Dictionary<string, Dictionary<LineChart, Chart>> AllChartsArchive { get; set; } = new();

        public static void PageProperty(string _PageName)
        {
            switch (_PageName)
            {
                case ("Home"):
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
                    break;
                case ("Archive"):
                    AllChartsArchive["Archive"] = new Dictionary<LineChart, Chart>()
                    {
                        [MeteorologicalChartTemperatureArchive] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.MeteorologicalChartDataSetTemperatureArchive },
                            DChartDataset = ChartDataSet.MeteorologicalChartDataSetTemperatureArchive
                        },

                    };
                    break;
            }
            foreach (var (_key, _a) in AllCharts)
            {
                if (_key == _PageName)
                {
                    foreach (var (_lineChart, _chart) in AllCharts[_key])
                    _lineChart.InitializeAsync(_chart.DChartData,_chart.DChartOptions);
                }
            }
            foreach (var (_key, _a) in AllChartsArchive)
            {
                if (_key == _PageName)
                {
                    foreach (var (_lineChart, _chart) in AllChartsArchive[_key])
                        _lineChart.InitializeAsync(_chart.DChartData, _chart.DChartOptions);
                }
            }
        }
    };
}
