using System.Net.Http;
using System.Windows;
using EQMonitor.Core.Earthquake;

namespace EQMonitor.GUI;

public partial class App
{
    private readonly HttpClient _httpClient = new();

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        EarthquakeService earthquakeService = new(_httpClient);
        var mainWindow = new MainWindow(earthquakeService);
        mainWindow.Show();
    }
}
