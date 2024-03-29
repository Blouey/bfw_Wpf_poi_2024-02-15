﻿
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Wpf_PointOfInterest_2024_02_15;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    public IServiceProvider ServiceProvider { get; private set; }
 
    public IConfiguration Configuration { get; private set; }
 
    public static string ConnectionString { get; private set; }
    protected override void OnStartup(StartupEventArgs e)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
        Configuration = builder.Build();

       ConnectionString =  Configuration.GetConnectionString("DefaultConnection");    

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
 
        ServiceProvider = serviceCollection.BuildServiceProvider();
 
        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
 
    private void ConfigureServices(IServiceCollection services)
    {
        // ...
 
        services.AddTransient(typeof(MainWindow));
    }
}