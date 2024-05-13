using WeatherForecastMauiApp.ViewModels;

namespace WeatherForecastMauiApp.Views;

public partial class Next24HrWidget
{
    public Next24HrWidget()
    {
        InitializeComponent();

        BindingContext = new HomeViewModel();
    }
}
