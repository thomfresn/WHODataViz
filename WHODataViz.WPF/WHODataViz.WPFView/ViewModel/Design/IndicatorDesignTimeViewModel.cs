using WHODataViz.DataModel;

namespace WHODataViz.WPFView.ViewModel.Design
{
    public class IndicatorDesignTimeViewModel : IIndicatorViewModel
    {
        public IndicatorDesignTimeViewModel(string displayName)
        {
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public string DisplayName { get; private set; }

        public Indicator Indicator => null;
    }
}