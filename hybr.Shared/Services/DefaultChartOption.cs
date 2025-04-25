using BlazorBootstrap;
namespace hybr.Shared.Services
{
    internal class DefaultChartOption : LineChartDataset
    {
        public int SensorId { get; set; } = 0;
        //public new List<double> PointRadius { get; set; } = [5];
        public new List<double> PointHoverRadius { get; set; } = [8];
    }
}
