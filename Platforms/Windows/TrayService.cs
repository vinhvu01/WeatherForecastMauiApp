using Hardcodet.Wpf.TaskbarNotification.Interop;
using Microsoft.UI.Xaml;
using WeatherForecastMauiApp.Services;

namespace WeatherForecastMauiApp.WinUI;

public class TrayService : ITrayService
{
    WindowsTrayIcon tray;

    public Action ClickHandler { get; set; }

    public void Initialize()
    {
        tray = new WindowsTrayIcon("Platforms/Windows/trayicon.ico");
        tray.LeftClick = () => {
            WindowExtensions.BringToFront();
            ClickHandler?.Invoke();
        };
    }
}
