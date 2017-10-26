using System.Collections.ObjectModel;
using System.Linq;
using WHODataViz.DataModel;

namespace WHODataViz.WPFView
{
    public class MainViewModel : IMainViewModel
    {
        public MainViewModel()
        {
            AvailableIndicators = new ObservableCollection<IIndicatorViewModel>();
            foreach (Indicator indicator in IndicatorsFinder.GetAllIndicators())
            {
                AvailableIndicators.Add(new IndicatorTimeViewModel(indicator));
            }

            SelectedIndicator = AvailableIndicators.FirstOrDefault();
        }

        public ObservableCollection<IIndicatorViewModel> AvailableIndicators { get; }
        public ObservableCollection<IndicatorDataRowViewModel> IndicatorData { get; }
        public IIndicatorViewModel SelectedIndicator { get; set; }
    }

    public class IndicatorTimeViewModel : IIndicatorViewModel
    {
        private readonly Indicator indicator;

        public IndicatorTimeViewModel(Indicator indicator)
        {
            this.indicator = indicator;
        }

        public override string ToString()
        {
            return this.indicator.Description;
        }
    }
}