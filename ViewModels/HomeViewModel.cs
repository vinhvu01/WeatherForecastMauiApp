using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherForecastMauiApp.Models;

namespace WeatherForecastMauiApp.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private static readonly string _apiKey = "";

    private static readonly string UrlTimeLine = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline";

    private RestService RestService { get; set; }

    public List<Forecast> Week { get; set; }

    public List<Forecast> Hours { get; set; }

    public Command QuitCommand { get; set; } = new Command(() => {
        Application.Current.Quit();
    });

    public Command AddLocationCommand { get; set; } = new Command(() => {
        // nav to modal form
    });

    public Command<string> ChangeLocationCommand { get; set; } = new Command<string>((location) => {
        // change primary location
    });

    public Command RefreshCommand { get; set; } = new Command(() => {
        // fake a refresh call
    });

    private Command toggleModeCommand;

    public Command ToggleModeCommand {
        get {
            return toggleModeCommand;
        }
        set {
            toggleModeCommand = value;
            OnPropertyChanged();
        }
    }

    public HomeViewModel()
    {
        InitData();

        ToggleModeCommand = new Command(() => {
            App.Current.UserAppTheme = App.Current.UserAppTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light;
        });
    }

    private void InitData()
    {
        var restService = new RestService();
        var url = $"{UrlTimeLine}/London, UK/next7days?key={_apiKey}";
        var results = restService.GetWeatherData(url);
        Week = [];
        foreach (var day in results.Days)
        {
            Week.Add(new Forecast
            {
                DateTime = DateTime.Parse(day.DateTime),
                Day = new Day { Phrase = GetPhraseByDay(day.Description) },
                Temperature = new Models.Temperature { Minimum = new Minimum { Unit = "F", Value = decimal.Parse(day.TempMin) }, Maximum = new Maximum { Unit = "F", Value = decimal.Parse(day.TempMax) } },
            });
        }

        url = $"{UrlTimeLine}/London, UK/next24hours?key={_apiKey}";
        results = restService.GetWeatherData(url);
        Hours = [];
        foreach (var hour in results.Days[1].Hours)
        {
            Hours.Add(new Forecast
            {
                DateTime = DateTime.Parse(hour.DateTime),
                Day = new Day { Phrase = GetPhraseByHour(hour.Conditions, DateTime.Parse(hour.DateTime)) },
                Temperature = new Models.Temperature { Minimum = new Minimum { Unit = "F", Value = decimal.Parse(hour.Temp) }, Maximum = new Maximum { Unit = "F", Value = decimal.Parse(hour.FeelsLike) } }
            });
        }
    }

    private string GetPhraseByDay(string dayDescription)
    {
        switch (dayDescription)
        {
            case "Partly cloudy throughout the day with rain clearing later.":
                return "fluent_weather_rain_showers_day_20_filled";
            case "Cloudy skies throughout the day with a chance of rain.":
                return "fluent_weather_rain_20_filled";
            case "Partly cloudy throughout the day.":
                return "fluent_weather_partly_cloudy";
            case "Clearing in the afternoon.":
                return "fluent_weather_sunny_high_20_filled";
        }

        return "fluent_weather_sunny_20_filled";
    }

    private string GetPhraseByHour(string conditions, DateTime date)
    {
        switch (conditions)
        {
            case "Partially cloudy":
                if (date.Hour > 17)
                {
                    return "fluent_weather_partly_cloudy_night_20_filled";
                }
                return "fluent_weather_partly_cloudy";
            case "Rain, Partially cloudy":
                if (date.Hour > 17)
                {
                    return "fluent_weather_rain_showers_night_20_filled";
                }
                return "fluent_weather_rain_showers_day_20_filled";
            case "Rain, Overcast":
                return "fluent_weather_rain_20_filled";
            case "Overcast":
                return "fluent_weather_cloudy_20_filled";
        }

        return "fluent_weather_sunny_20_filled";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

}
