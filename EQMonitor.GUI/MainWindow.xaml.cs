using System.Net.Http;
using EQMonitor.Core.Earthquake;

namespace EQMonitor.GUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        EarthquakeService service = new EarthquakeService(new HttpClient());
    }
}
