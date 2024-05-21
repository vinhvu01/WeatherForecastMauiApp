# WeatherForecastMauiApp

The following is an app written in the MAUI (Multi-platform App UI) library for educational purposes. It calls Weather API (www.visualcrossing.com) to get weather forecast information for specified cities, and locations.

The Visual Crossing Weather API provides developers with weather data for any programming language or script. The Weather API provides instant and scalable access to historical weather reports and forecast data in an easy-to-use JSON or text format. See https://www.visualcrossing.com/weather-api for more information and additional documentation, sample code, and use cases.

To sign up for a free account to view, download weather data, and build weather API queries, see https://www.visualcrossing.com/weather/weather-data-services

Documentation for the Weather API can be found at https://www.visualcrossing.com/resources/documentation/weather-api/weather-api-documentation/. The documentation of the available data on weather elements and their values can be found at https://www.visualcrossing.com/resources/documentation/weather-data/weather-data-documentation/.

Weather data is sourced from Visual Crossing Weather Data (see https://www.visualcrossing.com/weather-data)

Done:
- Weather displays at the current time: show temperature, wind speed, wind gust, wind dir, location and humidity.
- Weather forecast for the next 24 hours and the next 7 days.
- Suggestion for today: Every day the application will display a short suggestion for the user based on the weather forecast for today. For example: if it's raining the suggestion could be "Bring an umbrella.."
- Weather in top 10 cities.

Used:

- Microsoft.Maui
- Microsoft.NETCore.App
- System.Net.Http for making requests to the backend.
- Weather API (https://www.visualcrossing.com/).

Note:
Need to fill the API key of the Weather API in the class GlobalConst.cs
