using Serilog;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using WHODataViz.DataModel;

namespace WHODataViz.WPFView.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ILogger>().Verbose("Loading indicators");
            IList<Indicator> indicators = await IndicatorsFinder.GetAllIndicatorsAsync();
            ServiceLocator.Current.GetInstance<ILogger>().Verbose("Indicators loaded");
            (DataContext as MainViewModel).Initialize(indicators);
            ServiceLocator.Current.GetInstance<ILogger>().Debug("Application initialized");
        }
    }
}
