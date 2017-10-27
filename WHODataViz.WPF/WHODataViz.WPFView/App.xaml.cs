using Serilog;
using Serilog.Core;

namespace WHODataViz.WPFView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
        {
            //Load configure for Serilog logger (https://github.com/serilog/serilog)
            Logger logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();
            Log.Logger = logger;

        }
    }
}
