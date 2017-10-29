using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using WHODataViz.DataModel;
using Serilog;
using WHODataViz.WPFView.ViewModel;
using WHODataViz.WPFView.ViewModel.Design;

namespace WHODataViz.WPFView
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private IIndicatorViewModel selectedIndicator;
        private IndicatorDataRowViewModel selectedIndicatorData;

        public MainViewModel()
        {
            AvailableIndicators = new ObservableCollection<IIndicatorViewModel>() {new IndicatorDesignTimeViewModel("Populating list ...")};
            SelectedIndicator = AvailableIndicators.First();
            SelectIndicatorCommand = new RelayCommand<SelectionChangedEventArgs>(OnSelectionChangedAsync);
        }

        public void Initialize(IEnumerable<Indicator> indicators)
        {
            AvailableIndicators.Clear();
            foreach (Indicator indicator in indicators)
            {
                AvailableIndicators.Add(new IndicatorViewModel(indicator));
            }

            SelectedIndicator = AvailableIndicators.FirstOrDefault();
        }

        private async void OnSelectionChangedAsync(SelectionChangedEventArgs eventArgs)
        {
            IList addedItems = eventArgs.AddedItems;
            if (addedItems.Count == 1)
            {
                SelectedIndicator = addedItems.OfType<IIndicatorViewModel>().FirstOrDefault();
                IndicatorData.Clear();
                Debug.Assert(SelectedIndicator != null, nameof(SelectedIndicator) + " != null");
                foreach (WHOStatistics statistics in await IndicatorDataFetcher.GetWHOStatistics(SelectedIndicator.Indicator.Code))
                {
                    IndicatorData.Add(new IndicatorDataRowViewModel(statistics.Value, statistics.Year, statistics.Sex, statistics.Country, statistics.Region, statistics.IsPublished));
                }
            }
        }

        public ObservableCollection<IIndicatorViewModel> AvailableIndicators { get; }
            
        public ObservableCollection<IndicatorDataRowViewModel> IndicatorData { get; } = new ObservableCollection<IndicatorDataRowViewModel>();

        public IIndicatorViewModel SelectedIndicator
        {
            get => selectedIndicator;
            set
            {
                selectedIndicator = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SelectIndicatorCommand { get; }

        public IndicatorDataRowViewModel SelectedIndicatorData
        {
            get => selectedIndicatorData;
            set
            {
                selectedIndicatorData = value;
                Log.Logger.Information("Selected indicator data {@IndicatorData}", selectedIndicatorData);
            }
        }
    }
}