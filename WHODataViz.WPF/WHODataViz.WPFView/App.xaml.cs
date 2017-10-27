
using Raven.Client.Document;
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
            DocumentStore documentStore = new DocumentStore {Url = "http://localhost:8080", DefaultDatabase = "logs"};
            documentStore.Initialize();

            ILogger logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .WriteTo.RavenDB(documentStore)
                .WriteTo.RollingFile(@"C:\Temp\logs\WHODataViz.log").CreateLogger();
            Log.Logger = logger;

        }
    }
}
