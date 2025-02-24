using BlazorBootstrap;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace hybr.Shared.Services
{
    internal class DefaultChartOption : LineChartDataset
    {
        public new List<double> PointRadius { get; set; } = [5];
        public new List<double> PointHoverRadius { get; set; } = [8];
    }
}
