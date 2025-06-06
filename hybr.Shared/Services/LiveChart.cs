using BlazorBootstrap;
using DocumentFormat.OpenXml.Office2010.Excel;
using SixLabors.Fonts;
using System.Reflection.Emit;

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
    public class ArchiveChart()
    {
        public bool DActive { get; set; } = false;
        public required ChartData DChartData { get; set; }
        public required List<IChartDataset> DChartDataset { get; set; }
        public IChartOptions DChartOptions { get; set; } = new LiveChartOptions { Interaction = new Interaction { Mode = InteractionMode.Point, Intersect = false } };
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

        public static IChartDataset ChartDataSetArchive { get; } =
        new DefaultChartOption()
        {
            Data = new(),
            BackgroundColor = "rgba(0, 0, 255, 0.7)",
            BorderColor = "rgba(0, 0, 255, 0.7)",
            BorderWidth = 1,
            HoverBorderWidth = 4,
            PointRadius = [0],
            PointStyle = ["triangle"],
            PointHoverRadius = [0.2],
        };
        public static Dictionary<int, IChartDataset> DictChartSettingsArchive { get; set; } = new Dictionary<int, IChartDataset>{};
    }
    public class ChartDataSet()
    {
        public static List<IChartDataset> PhotovoltaicChartDataSetVoltage1 { get; } = new List<IChartDataset> { ChartSettings.PhotovoltaicChartDataSetSensor1, ChartSettings.PhotovoltaicChartDataSetSensor3, ChartSettings.PhotovoltaicChartDataSetSensor5 };
        public static List<IChartDataset> PhotovoltaicChartDataSetAmperage1 { get; } = new List<IChartDataset> { ChartSettings.PhotovoltaicChartDataSetSensor2, ChartSettings.PhotovoltaicChartDataSetSensor4, ChartSettings.PhotovoltaicChartDataSetSensor6 };
        public static List<IChartDataset> PhotovoltaicChartDataSetVoltage2 { get; } = new List<IChartDataset> { ChartSettings.PhotovoltaicChartDataSetSensor7, ChartSettings.PhotovoltaicChartDataSetSensor9 };
        public static List<IChartDataset> PhotovoltaicChartDataSetAmperage2 { get; } = new List<IChartDataset> { ChartSettings.PhotovoltaicChartDataSetSensor8, ChartSettings.PhotovoltaicChartDataSetSensor10 };
        public static List<IChartDataset> PhotovoltaicChartDataSetVoltage3 { get; } = new List<IChartDataset> { ChartSettings.PhotovoltaicChartDataSetSensor11 };
        public static List<IChartDataset> PhotovoltaicChartDataSetAmperage3 { get; } = new List<IChartDataset> { ChartSettings.PhotovoltaicChartDataSetSensor12 };

        public static List<IChartDataset> MeteorologicalChartDataSetTemperature { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor103 };
        public static List<IChartDataset> MeteorologicalChartDataSetHumidity { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor104 };
        public static List<IChartDataset> MeteorologicalChartDataSetPressure { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor105 };
        public static List<IChartDataset> MeteorologicalChartDataSetSolarRadiation { get; } = new List<IChartDataset> { ChartSettings.MeteorologicalChartDataSetSensor108 };

        public static List<IChartDataset> ChartDataSetArchive { get; } = new List<IChartDataset> { ChartSettings.ChartDataSetArchive };
        public static List<IChartDataset> DictChartDataSetArchive { get; set; }
    }
    public class LiveChartElement()
    {
        public static LineChart PhotovoltaicChartVoltage1 { get; set; } = default!;
        public static LineChart PhotovoltaicChartAmperage1 { get; set; } = default!;
        public static LineChart PhotovoltaicChartVoltage2 { get; set; } = default!;
        public static LineChart PhotovoltaicChartAmperage2 { get; set; } = default!;
        public static LineChart PhotovoltaicChartVoltage3 { get; set; } = default!;
        public static LineChart PhotovoltaicChartAmperage3 { get; set; } = default!;

        public static LineChart MeteorologicalChartTemperature { get; set; } = default!;
        public static LineChart MeteorologicalChartHumidity { get; set; } = default!;
        public static LineChart MeteorologicalChartPressure { get; set; } = default!;
        public static LineChart MeteorologicalChartSolarRadiation { get; set; } = default!;

        public static LineChart ChartArchive { get; set; } = default!;

        public static Dictionary<string, Dictionary<LineChart, Chart>> AllCharts { get; set; } = new();
        public static Dictionary<string, Dictionary<LineChart, ArchiveChart>> AllChartsArchive { get; set; } = new();

        public static async Task PageProperty(string _PageName)
        {
            
            switch (_PageName)
            {
                case ("Home"):
                    break;
                case ("Photovoltaic"):
                    AllCharts["Photovoltaic"] = new Dictionary<LineChart, Chart>()
                    {
                        [PhotovoltaicChartVoltage1] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.PhotovoltaicChartDataSetVoltage1 },
                            DChartDataset = ChartDataSet.PhotovoltaicChartDataSetVoltage1
                        },
                        [PhotovoltaicChartAmperage1] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.PhotovoltaicChartDataSetAmperage1 },
                            DChartDataset = ChartDataSet.PhotovoltaicChartDataSetAmperage1
                        },
                        [PhotovoltaicChartVoltage2] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.PhotovoltaicChartDataSetVoltage2 },
                            DChartDataset = ChartDataSet.PhotovoltaicChartDataSetVoltage2
                        },
                        [PhotovoltaicChartAmperage2] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.PhotovoltaicChartDataSetAmperage2 },
                            DChartDataset = ChartDataSet.PhotovoltaicChartDataSetAmperage2
                        },
                        [PhotovoltaicChartVoltage3] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.PhotovoltaicChartDataSetVoltage3 },
                            DChartDataset = ChartDataSet.PhotovoltaicChartDataSetVoltage3
                        },
                        [PhotovoltaicChartAmperage3] = new Chart
                        {
                            maxLabelXasixCount = 5,
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.PhotovoltaicChartDataSetAmperage3 },
                            DChartDataset = ChartDataSet.PhotovoltaicChartDataSetAmperage3
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
                    AllChartsArchive["Archive"] = new Dictionary<LineChart, ArchiveChart>()
                    {
                        [ChartArchive] = new ArchiveChart
                        {
                            DChartData = new ChartData { Labels = new List<string>(), Datasets = ChartDataSet.ChartDataSetArchive },
                            DChartDataset = ChartDataSet.ChartDataSetArchive
                        }
                    };
                    break;
            }
            foreach (var (_key, _a) in AllCharts)
            {
                if (_key == _PageName)
                {
                    foreach (var (_lineChart, _chart) in AllCharts[_key])
                    await _lineChart.InitializeAsync(_chart.DChartData,_chart.DChartOptions);
                }
            }
            foreach (var (_key, _a) in AllChartsArchive)
            {
                if (_key == _PageName)
                {
                    foreach (var (_lineChart, _chart) in AllChartsArchive[_key]) {
                        await _lineChart.InitializeAsync(_chart.DChartData, _chart.DChartOptions);
                    }
                }
            }
        }
    };
}
