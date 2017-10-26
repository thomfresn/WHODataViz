using System.Collections.ObjectModel;
using System.Linq;
using WHODataViz.DataModel;

namespace WHODataViz.WPFView
{
    public class MainViewModel : IMainViewModel
    {
        private IIndicatorViewModel selectedIndicator;

        public MainViewModel()
        {
            AvailableIndicators = new ObservableCollection<IIndicatorViewModel>();
            foreach (Indicator indicator in IndicatorsFinder.GetAllIndicators())
            {
                AvailableIndicators.Add(new IndicatorViewModel(indicator));
            }

            SelectedIndicator = AvailableIndicators.FirstOrDefault();
        }

        public ObservableCollection<IIndicatorViewModel> AvailableIndicators { get; }
        public ObservableCollection<IndicatorDataRowViewModel> IndicatorData { get; } = new ObservableCollection<IndicatorDataRowViewModel>();

        public IIndicatorViewModel SelectedIndicator
        {
            get => selectedIndicator;
            set
            {
                selectedIndicator = value;
                IndicatorData.Clear();
                foreach (WHOStatistics statistics in IndicatorDataFetcher.GetWHOStatistics(selectedIndicator.Indicator.Code))
                {
                    IndicatorData.Add(new IndicatorDataRowViewModel(statistics.Value, statistics.Year, statistics.Sex, statistics.Country, statistics.Region, statistics.IsPublished));
                }
            }
        }
    }
}