using System.Windows;
using Dengi.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace Dengi;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    private ServiceProvider ServiceProvider { get; }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddTransient<Category>();
        services.AddTransient<Invoices>();
        services.AddTransient<Reports>();
        services.AddTransient<Sheduler>();
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var window = ServiceProvider.GetRequiredService<MainWindow>();
        //window.DataContext = 
        window.Show();
    }
}