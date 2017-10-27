
using Serilog;

namespace WHODataViz.WPFView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
        {
            ILogger logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .WriteTo.File("WHODataViz.log").CreateLogger();
            Log.Logger = logger;

        }
    }
}
