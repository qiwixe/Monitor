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

        public static Dictionary<string, Dictionary<LineChart, Chart>> AllCharts { get; set; } = new();

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
            }
            foreach (var (_key, _a) in AllCharts)
            {
                if (_key == _PageName)
                {
                    foreach (var (_lineChart, _chart) in AllCharts[_key])
                    _lineChart.InitializeAsync(_chart.DChartData,_chart.DChartOptions);
                }
            }
        }
    };
}
