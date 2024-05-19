namespace WeatherForecastMauiApp.Services;

public class WeatherService : IWeatherService
{
    public Task<IEnumerable<Location>> GetLocations(string query)
    {
        var locations = new List<Location>();
        var restService = new RestService();
        var datetime = DateTime.Now;
        var url = $"{GlobalConst.UrlTimeLine}/HaNoi, Vietnam/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        var results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "Vietnam", Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/Tokyo, Japan/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "Japan",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/New York, NY/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "USA",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/Washington, DC/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "USA",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/Berlin, Germany/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "Germany",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/London, England/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "UK",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/Paris, France/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "France",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/Sydney, Australia/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "Australia",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/Vancouver, Canada/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "Canada",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        url = $"{GlobalConst.UrlTimeLine}/Wellington, NewZealand/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        results = restService.GetWeatherData(url);
        locations.Add(new Location
        {
            Name = results.Address,
            Icon = GetImageFile(results.Days[0].Description),
            Coordinate = new Coordinate(results.Latitude, results.Longitude),
            WeatherStation = "NewZealand",
            Value = results.Days[0].Temp,
            Humidity = $"{results.Days[0].Humidity}%"
        });

        return Task.FromResult(locations.Where(l => l.Name.Contains(query)));
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