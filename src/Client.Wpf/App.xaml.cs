using System;
using System.Net.Http;
using System.Windows;
using Application.Common.Interfaces.Movies;
using Application.Common.Interfaces.Searchers;
using Client.Wpf.Services;
using Client.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Client.Wpf;

public partial class App : System.Windows.Application
{
    public static IHost? AppHost { get; set; }
    public IServiceProvider ServiceProvider { get; private set; }
    public App()
    {
        AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContent, services) =>
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
        services.AddScoped<IMovieManager, MovieManager>();
        services.AddScoped<ISearchManager, SearchManager>();
        services.AddScoped<MainViewModel>();
        services.AddScoped<MoviesViewModel>();
        services.AddScoped<TvViewModel>();
        services.AddScoped<HomeViewModel>();
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:49153") });
    }
}
