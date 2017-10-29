using WHODataViz.DataModel;

namespace WHODataViz.WPFView.ViewModel
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