using System.Collections.ObjectModel;

namespace WHODataViz.WPFView
{
    public interface IMainViewModel
    {
        ObservableCollection<IIndicatorViewModel> AvailableIndicators { get; }
        ObservableCollection<IndicatorDataRowViewModel> IndicatorData { get; }
        IIndicatorViewModel SelectedIndicator { get; set; }
    }
}