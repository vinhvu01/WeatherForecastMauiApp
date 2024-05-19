using System.Threading.Channels;

namespace WeatherForecastMauiApp.Views;

public partial class SuggestionToday
{
    private List<string> clearing_in_the_afternoon =
    [
        "Since the temperatures are continuing similarly, likely on the warmer side, it's best to dress in lightweight, breathable clothing.",
        "Make sure to drink plenty of water throughout the day to stay hydrated, especially if you’re spending time outdoors.",
        "If you’re going outside, apply sunscreen to protect your skin from UV rays.",
        "With no rain expected, it's a good day to enjoy outdoor activities like walking, jogging, or picnicking.",
        "If indoors, ensure proper ventilation by opening windows to keep the air circulating and cool.",
        "Skip wearing heavy or layered clothing that can cause overheating.",
        "Avoid intense outdoor exercises during peak sunlight hours to prevent heat exhaustion.",
        "Neglecting sunscreen can lead to sunburns, so make sure to apply it even if it seems cloudy.",
        "Never leave pets in parked cars, as temperatures inside can rise quickly and be dangerous.",
        "Limit high-caffeine or sugary drinks which can dehydrate you."
    ];

    private List<string> partly_cloudy_throughout_the_day_with_rain =
    [
        "Since there will be some rain during the day, it's a good idea to carry an umbrella or a raincoat.",
        "Keep an eye on weather updates to know when the rain is expected to clear.",
        "Consider planning indoor activities for when it's raining, and outdoor activities for later when the rain clears.",
        "Wear shoes that can handle getting wet, especially if you’ll be outside during the rain.",
        "Once the rain clears, take the opportunity to enjoy the fresh air and possibly a rainbow.",
        "Don’t plan long outdoor activities without having a backup indoor option in case the rain persists longer than expected.",
        "Even if the rain clears later, the weather might still be cool and damp, so a light jacket can be useful.",
        "Try to avoid driving during the heaviest rain periods to reduce the risk of accidents.",
        "Ensure windows at home or in your car are closed during the rain to prevent water damage.",
        "Don’t leave sensitive items like electronics or furniture outside where they can get wet."
    ];

    private List<string> cloudy_skies_throughout_the_day_chance_of_rain =
    [
        "With a chance of rain, it's wise to carry an umbrella or a raincoat to stay dry.",
        "Dress in layers to adjust to potentially cooler, damp weather and stay comfortable throughout the day.",
        "Consider planning indoor activities or have indoor options ready in case it starts to rain.",
        "Be aware of changing weather conditions and be prepared to seek shelter if it starts to rain.",
        "Use weather apps to monitor the likelihood and timing of rain to plan your day more effectively.",
        "Don’t leave home without some form of rain protection, like an umbrella or waterproof jacket.",
        "Avoid planning long outdoor events or activities that can’t be easily moved indoors.",
        "Keep windows closed, especially if you’re not home, to prevent rain from getting in.",
        "Avoid wearing clothes and shoes that aren’t suitable for wet conditions.",
        "Don’t leave important or sensitive items like electronics or paperwork outdoors where they could get damaged by rain."
    ];

    private List<string> partly_cloudy_throughout_the_day =
    [
        "Dress in comfortable layers that can be adjusted throughout the day as the temperature changes.",
        "Take advantage of the partly cloudy weather to enjoy outdoor activities such as walking, jogging, or picnicking.",
        "Even with clouds, UV rays can still be strong, so wear sunglasses and apply sunscreen.",
        "Plan activities that can easily be moved indoors or adjusted if the weather changes slightly.",
        "Keep hydrated, especially if you are spending a lot of time outdoors.",
        "Avoid skipping sun protection; clouds can still let through harmful UV rays.",
        "Don’t wear too many layers or heavy clothing, as partly cloudy conditions can still be warm.",
        "Avoid leaving home without checking the full weather forecast, in case conditions change.",
        "Don’t plan outdoor activities that can’t be easily adjusted or rescheduled in case the weather becomes less favorable.",
        "Avoid neglecting to drink water, particularly if engaging in outdoor activities."
    ];

    private List<string> cloudy_skies_with_storms =
    [
        "Bring an umbrella or raincoat to stay dry in case of storms.",
        "Consider planning indoor activities to avoid being caught in a storm.",
        "Keep an eye on weather updates and alerts to stay informed about potential storms.",
        "Ensure your electronic devices are fully charged in case of power outages due to storms.",
        "Make sure outdoor items, like furniture or decorations, are secured or brought inside to prevent them from being damaged or blown away.",
        "Don’t plan long outdoor activities, especially those far from shelter, as storms could start suddenly.",
        "Don’t park your car under trees or in areas prone to flooding to prevent damage from falling branches or water.",
        "Avoid leaving home without some form of rain protection, like an umbrella or waterproof jacket.",
        "Avoid ignoring weather warnings or alerts about potential storms.",
        "Don’t engage in high-energy activities outdoors, like running or cycling, where seeking immediate shelter could be difficult if a storm hits suddenly."
    ];

    private List<string> sunny =
    [
        "Apply sunscreen to protect your skin from UV rays.",
        "Use sunglasses to protect your eyes from bright sunlight.",
        "Drink plenty of water throughout the day, especially if you are spending time outdoors.",
        "Take advantage of the sunny weather to enjoy outdoor activities such as hiking, picnicking, or visiting the beach.",
        "Dress in lightweight, breathable clothing to stay cool and comfortable.",
        "Don’t spend too much time in direct sunlight without taking breaks in the shade to avoid sunburn or heat exhaustion.",
        "Avoid going out without a hat to protect your head and face from the sun.",
        "Don't eat heavy meals outdoors in the heat, as it can make you feel sluggish and uncomfortable.",
        "Never leave pets in parked cars, as temperatures can rise quickly and become dangerous.",
        "Avoid strenuous outdoor activities during peak sunlight hours (10 a.m. to 4 p.m.) to reduce the risk of heat-related illnesses."
    ];

    public SuggestionToday()
    {
        InitializeComponent();
        var restService = new RestService();
        var datetime = DateTime.Now;
        var url = $"{GlobalConst.UrlTimeLine}/{GlobalConst.CurrentLocation}/{datetime:yyyy-MM-ddTHH:mm:ss}?key={GlobalConst.ApiKey}";
        var results = restService.GetWeatherData(url);
        Suggestion.Text = GetSuggestion(results.Days[0].Description); 
    }

    private string GetSuggestion(string description)
    {
        if (description.Contains("Clearing in the afternoon."))
        {
            return clearing_in_the_afternoon.OrderBy(s => Guid.NewGuid()).First();
        }

        if (description.Contains("Partly cloudy throughout the day with rain clearing later."))
        {
            return partly_cloudy_throughout_the_day_with_rain.OrderBy(s => Guid.NewGuid()).First();
        }

        if (description.Contains("Cloudy skies throughout the day with a chance of rain."))
        {
            return cloudy_skies_throughout_the_day_chance_of_rain.OrderBy(s => Guid.NewGuid()).First();
        }

        if (description.Contains("Partly cloudy throughout the day."))
        {
            return partly_cloudy_throughout_the_day.OrderBy(s => Guid.NewGuid()).First();
        }

        if (description.Contains("Cloudy skies throughout the day with storms possible."))
        {
            return cloudy_skies_with_storms.OrderBy(s => Guid.NewGuid()).First();
        }

        return description.Contains("Partly cloudy throughout the day with storms possible.") ? cloudy_skies_with_storms.OrderBy(s => Guid.NewGuid()).First() : sunny.OrderBy(s => Guid.NewGuid()).First();
    }
}