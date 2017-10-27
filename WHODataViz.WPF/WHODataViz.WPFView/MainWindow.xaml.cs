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
            IList<Indicator> indicators = await IndicatorsFinder.GetAllIndicatorsAsync();
            mainViewModel.Initialize(indicators);
        }
    }
}
