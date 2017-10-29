

using GalaSoft.MvvmLight.Threading;

namespace WHODataViz.WPFView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
        {
            DispatcherHelper.Initialize();
        }
    }
}
