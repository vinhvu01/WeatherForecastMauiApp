namespace WeatherForecastMauiApp.Views;

public partial class CurrentWidget
{
    public CurrentWidget()
    {
        InitializeComponent();
        var restService = new RestService();
        var datetime = DateTime.Now;
        var url = $"{GlobalConst.UrlTimeLine}/{GlobalConst.CurrentLocation}/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        var results = restService.GetWeatherData(url);
        Temp.Text = $"{results.Days[0].Temp}℉"; 
        Description.Text = results.Days[0].Description + " Suggestion today: Need umbrella";
        WeatherImage.Source = ImageSource.FromFile(GetImageFile(results.Days[0].Description));
    }

    private string GetImageFile(string description)
    {
        switch (description)
        {
            case "Partly cloudy throughout the day with rain clearing later.":
                return "fluent_weather_rain_showers_day_20_filled.png";
            case "Cloudy skies throughout the day with a chance of rain.":
                return "fluent_weather_rain_20_filled.png";
            case "Partly cloudy throughout the day.":
                return "fluent_weather_partly_cloudy.png";
            case "Clearing in the afternoon.":
                return "fluent_weather_sunny_high_20_filled.png";
            case "Cloudy skies throughout the day with storms possible.":
                return "fluent_weather_thunderstorm_20_filled.png";
        }

        return "fluent_weather_sunny_20_filled.png";
    }
}
