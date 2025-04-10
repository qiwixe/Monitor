using BlazorBootstrap;

namespace hybr.Shared.Services
{
    internal class LiveChartOptions : LineChartOptions
    {
        public bool Animation { get; set; } = false;
        public new string? IndexAxis { get; set; } = new("x");
        public new Interaction Interaction { get; set; } = new Interaction { Mode = InteractionMode.Index, Intersect = false };
        public new bool Responsive { get; set; } = true;
        //public new Scales Scales { get; set; } = new Scales() { Y = new ChartAxes() { Min = 100, Max = 300 } };
    }

}
