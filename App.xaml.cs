using System.Diagnostics;

namespace WeatherForecastMauiApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
            Shell.Current.CurrentItem = PhoneTabs;

    }

    async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        try { 
            await Shell.Current.GoToAsync("///settings");
        }catch (Exception ex) {
            Debug.WriteLine($"err: {ex.Message}");
        }
    }
}
