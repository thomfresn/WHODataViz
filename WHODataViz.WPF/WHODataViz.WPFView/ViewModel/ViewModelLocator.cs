
using WHODataViz.DataModel;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Serilog;
using Serilog.Core;

namespace WHODataViz.WPFView.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register(() => CreateLogger());
            SimpleIoc.Default.Register<IIndicatorsService, IndicatorsFinder>();
        }

        private ILogger CreateLogger()
        {
            //Load configure for Serilog logger (https://github.com/serilog/serilog)
            Logger logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();
            Log.Logger = logger;
            return Log.Logger;
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
        }
    }
}