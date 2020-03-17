using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SunnyCalc.App.ViewModels;
using SunnyCalc.App.Views;
using SunnyCalc.Maths;

namespace SunnyCalc.App
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mathsService = new MathsService();

                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(mathsService),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
