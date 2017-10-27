﻿using Serilog;
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
            ILogger logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Logger = logger;
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            Log.Logger.Information("Loading indicators");
            IList<Indicator> indicators = await IndicatorsFinder.GetAllIndicatorsAsync();
            Log.Logger.Information("Indicators loaded");
            mainViewModel.Initialize(indicators);
            Log.Logger.Information("Application initialized");
        }
    }
}
