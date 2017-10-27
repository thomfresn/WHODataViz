using Serilog;
using System.Collections.Generic;
using WHODataViz.DataModel;

namespace WHODataViz.WPFView
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
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            Log.Logger.Verbose("Loading indicators");
            IList<Indicator> indicators = await IndicatorsFinder.GetAllIndicatorsAsync();
            Log.Logger.Verbose("Indicators loaded");
            mainViewModel.Initialize(indicators);
            Log.Logger.Debug("Application initialized");
        }
    }
}
