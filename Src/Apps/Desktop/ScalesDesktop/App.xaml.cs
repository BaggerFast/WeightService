using Microsoft.Extensions.Configuration;

namespace ScalesDesktop;

public partial class App : Application
{
    private static readonly Mutex Mutex = new(true, Assembly.GetEntryAssembly()?.GetName().Name);

    public App(IConfiguration configuration)
    {
        if (!Mutex.WaitOne(TimeSpan.Zero, true))
        {
            Current?.Quit();
            Environment.Exit(0);
        }

        InitializeComponent();
        MainPage = new MainPage(configuration);
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window window = base.CreateWindow(activationState);
        window.Title = "Весовой пост";
        return window;
    }
}