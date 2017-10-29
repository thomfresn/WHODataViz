using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WHODataViz.WPFView.ViewModel
{
    public interface IMainViewModel
    {
        ObservableCollection<IIndicatorViewModel> AvailableIndicators { get; }
        ObservableCollection<IndicatorDataRowViewModel> IndicatorData { get; }
        IIndicatorViewModel SelectedIndicator { get; set; }
        ICommand SelectIndicatorCommand { get; }
        IndicatorDataRowViewModel SelectedIndicatorData { get; set; }
    }
}