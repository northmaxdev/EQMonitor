using System.Diagnostics.CodeAnalysis;
using System.Windows;
using EQMonitor.Core.Earthquake;

namespace EQMonitor.GUI;

public partial class MainWindow
{
    private readonly EarthquakeService _earthquakeService;

    public MainWindow(EarthquakeService earthquakeService)
    {
        _earthquakeService = earthquakeService;

        InitializeComponent();
        TimePeriodSelector.ItemsSource = Enum.GetValues<EarthquakeService.TimePeriod>();
    }

    // This is safe because EarthquakeStats.From() creates a backing list before iterating
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    private void FetchDataButton_Click(object sender, RoutedEventArgs e)
    {
        var timePeriod = (EarthquakeService.TimePeriod)TimePeriodSelector.SelectedItem;

        IEnumerable<EarthquakeModel> dataset = _earthquakeService.GetData(timePeriod);
        var stats = EarthquakeStats.From(dataset);

        DatasetView.ItemsSource = dataset;
        EarthquakeCountComment.Content = $"{stats.Count} earthquakes";
        AverageMagnitudeComment.Content = $"Avg. magnitude: {stats.AverageMagnitude:F3}";
    }
}
