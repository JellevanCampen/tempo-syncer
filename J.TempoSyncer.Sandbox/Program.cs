using Autofac;
using J.TempoSyncer.Core.Interface;
using J.TempoSyncer.Core.Model;
using J.TempoSyncer.Sandbox.Utility;

namespace J.TempoSyncer.Sandbox;

public class Program
{
    private static IContainer _container { get; set; }
    private const string _testSourceCollection = @"H:\Music\";

    static async Task Main(string[] args)
    {
        // Register all dependencies.
        _container = DependencyInjection.BuildContainer();

        using ILifetimeScope scope = _container.BeginLifetimeScope();
        ITrackCollectionFactory trackCollectionFactory = scope.Resolve<ITrackCollectionFactory>();

        TrackCollection trackCollection = await trackCollectionFactory.FromDirectoryAsync(_testSourceCollection);
    }
}