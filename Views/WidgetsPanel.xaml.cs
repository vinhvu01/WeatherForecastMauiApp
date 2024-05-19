using System.Collections.ObjectModel;
using WeatherForecastMauiApp.Models;

namespace WeatherForecastMauiApp.Views;

public partial class WidgetsPanel
{
    public ObservableCollection<Metric> Metrics { get; set; }

    public WidgetsPanel()
    {
        InitializeComponent();
        var restService = new RestService();
        var datetime = DateTime.Now;
        var url = $"{GlobalConst.UrlTimeLine}/{GlobalConst.CurrentLocation}/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        var results = restService.GetWeatherData(url);
        Metrics =
        [
            new Metric { Title = "Humidity", Icon = "humidity_icon.png", Value = $"{results.Days[0].Humidity}%"},
            new Metric { Title = "WindGust", Icon = "wind_icon.png", Value = $"{results.Days[0].Windgust}mph" },
            new Metric { Title = "WindDir", Icon = "wind_icon.png", Value = $"{results.Days[0].WindSpeed}mph"},
            new Metric { Title = "WindSpeed", Icon = "wind_icon.png", Value = $"{results.Days[0].WindDir}mph"}
        ];

        this.BindingContext = this;
    }

    public string Humidity;

    async void OnTapped(object sender, EventArgs eventArgs)
    {
        Grid g = (Grid)sender;

        await g.FadeTo(0, 200);
        await g.FadeTo(0.5, 100);
        await g.FadeTo(0, 100);
        await g.FadeTo(0.3, 100);
        await g.FadeTo(0, 100);

        await Task.Delay(1000);

        await g.FadeTo(1, 400);

    }
}
