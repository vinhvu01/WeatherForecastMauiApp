namespace WeatherForecastMauiApp.Views;

public partial class WidgetsPanel
{
    public WidgetsPanel()
    {
        InitializeComponent();
        var restService = new RestService();
        var datetime = DateTime.Now;
        var url = $"{GlobalConst.UrlTimeLine}/{GlobalConst.CurrentLocation}/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        var results = restService.GetWeatherData(url);
        Humidity = $"{results.Days[0].Humidity}%";
        //WindSpeed.Value = $"{results.Days[0].WindSpeed}mph";
        //WindGust.Value = $"{results.Days[0].Windgust}mph";
        //WindDir.Value = $"{results.Days[0].WindDir}mph";
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
