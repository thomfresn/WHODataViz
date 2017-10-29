using Serilog;
using System.Collections.Generic;
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
            Log.Logger.Verbose("Loading indicators");
            IList<Indicator> indicators = await IndicatorsFinder.GetAllIndicatorsAsync();
            Log.Logger.Verbose("Indicators loaded");
            (DataContext as MainViewModel).Initialize(indicators);
            Log.Logger.Debug("Application initialized");
        }
    }
}
