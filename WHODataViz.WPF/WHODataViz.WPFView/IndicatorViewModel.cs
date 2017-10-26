using WHODataViz.DataModel;

namespace WHODataViz.WPFView
{
    public class IndicatorViewModel : IIndicatorViewModel
    {
        public Indicator Indicator { get; }

        public IndicatorViewModel(Indicator indicator)
        {
            Indicator = indicator;
        }

        public override string ToString()
        {
            return Indicator.Description;
        }
    }
}