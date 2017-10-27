using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WHODataViz.WPFView
{
    public class MainDesignTimeViewModel : IMainViewModel
    {
        public MainDesignTimeViewModel()
        {
            AvailableIndicators = new ObservableCollection<IIndicatorViewModel>()
            {
                new IndicatorDesignTimeViewModel("Infant mortality rate (p…1 per 1000 live births)"),
                new IndicatorDesignTimeViewModel("Adolescent birth rate (p…women aged 15-19 years)"),
                new IndicatorDesignTimeViewModel("Contraceptive prevalence (%)"),
            };

            SelectedIndicator = AvailableIndicators.First();

            IndicatorData = new ObservableCollection<IndicatorDataRowViewModel>()
            {
                new IndicatorDataRowViewModel(50.9, "2009-2011", "Male", "Papua New Guinea", "Western Pacific", true),
                new IndicatorDataRowViewModel(31.4, "1990", "Male", "China", "Western Pacific", true),
                new IndicatorDataRowViewModel(8.9, "2011-2012", "Female", "Bosnia and Herzegovina", "Europe", true),
                new IndicatorDataRowViewModel(55.4, "1995", "Both sexes", "Guatemala", "Americas", false),
            };
        }

        public ObservableCollection<IIndicatorViewModel> AvailableIndicators { get; }

        public ObservableCollection<IndicatorDataRowViewModel> IndicatorData { get; }

        public IIndicatorViewModel SelectedIndicator { get; set; }

        public IndicatorDataRowViewModel SelectedIndicatorData { get; set; }

        public ICommand SelectIndicatorCommand
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}