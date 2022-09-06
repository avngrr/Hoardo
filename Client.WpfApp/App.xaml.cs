using System;
using System.Net.Http;
using System.Windows;
using Application.Common.Interfaces.Movies;
using Client.WpfApp.Commands;
using Client.WpfApp.Services;
using Client.WpfApp.UI.Home;
using Client.WpfApp.UI.Main;
using Client.WpfApp.UI.Movies;
using Client.WpfApp.UI.TvShows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Client.WpfApp;
public partial class App : System.Windows.Application
{
    public static IHost? AppHost { get; set; }
    public IServiceProvider ServiceProvider { get; private set; }
    public App()
    {
        AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
        {
            ConfigureServices(services);
        }).Build();
    }
    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();
        var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
        startupForm.DataContext = AppHost.Services.GetService<MainViewModel>();
        startupForm.Show();
    }
    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<AddMovieForm>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MoviesViewModel>();
        services.AddSingleton<TvShowsViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddScoped<INavigationService, NavigationService>();
        services.AddScoped<IMovieManager, MovieManager>();
        services.AddTransient(typeof(NavigateCommand<>));
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:49153") });

    }
}

