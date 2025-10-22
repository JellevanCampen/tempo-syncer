using CommunityToolkit.Mvvm.Messaging;
using J.TempoSyncer.Core.Interface;
using J.TempoSyncer.Infrastructure.TagLibMetadata.Implementation;
using J.TempoSyncer.Presentation.WPF.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Windows;

namespace J.TempoSyncer.Presentation.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    /// <inheritdoc/>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Configure Serilog for logging.
        ConfigureSerilog();

        // Register services for dependency injection.
        ServiceCollection serviceCollection = new();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();

        // Create the main window and show it.
        MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    /// <summary>
    /// Configures services for dependency injection.
    /// </summary>
    /// <param name="serviceCollection">Service collection in which to register services.</param>
    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        // Register logging services.
        serviceCollection.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });

        // Register the messenger service.
        serviceCollection.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

        // Register infrastructure.
        serviceCollection.AddTransient<ITrackMetadataReader, TagLibTrackMetadataReader>();
        serviceCollection.AddTransient<ITrackMetadataWriter, TagLibTrackMetadataWriter>();

        // Register services.
        // serviceCollection.AddSingleton<IService, Service>();

        // Decorate services with logging.
        // serviceCollection.Decorate<IService, LoggingServiceDecorator>();

        // Register command services.
        serviceCollection.Scan(scan => scan
            .FromAssemblyOf<App>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("CommandService")))
            .AsSelf()
            .WithTransientLifetime()
        );

        // Register view models.
        serviceCollection.Scan(scan => scan
            .FromAssemblyOf<App>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("ViewModel")))
            .AsSelf()
            .WithTransientLifetime()
        );

        // Register views.
        serviceCollection.Scan(scan => scan
            .FromAssemblyOf<App>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Window")))
            .AsSelf()
            .WithTransientLifetime()
        );
    }

    /// <summary>
    /// Configures Serilog for logging.
    /// </summary>
    private static void ConfigureSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Debug()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    /// <summary>
    /// Gets or sets the service provider for dependency injection.
    /// </summary>
    public IServiceProvider? ServiceProvider { get; private set; }
}
