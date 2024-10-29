using EQMonitor.Core.Earthquake;

namespace EQMonitor.GUI;

public partial class MainWindow
{
    public MainWindow()
    {
        // DatasetView
        // TimePeriodSelector
        // FetchDataButton
        // FetchProgressBar
        // ViewStatsButton
        // CsvExportButton
        // CsvExportProgressBar

        InitializeComponent();

        TimePeriodSelector.ItemsSource = Enum.GetValues<EarthquakeService.TimePeriod>();
    }
}
