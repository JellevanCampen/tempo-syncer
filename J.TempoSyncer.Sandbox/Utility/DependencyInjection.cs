using Autofac;
using J.TempoSyncer.Core.Factory;
using J.TempoSyncer.Core.Interface;
using J.TempoSyncer.Infrastructure.TagLibMetadata.Implementation;

namespace J.TempoSyncer.Sandbox.Utility;

/// <summary>
/// Utility class for setup up the dependency injection container for the project.
/// </summary>
internal class DependencyInjection
{
    /// <summary>
    /// Builds the dependency injection container for the project.
    /// </summary>
    /// <returns>Dependency injection container for the project.</returns>
    public static IContainer BuildContainer()
    {
        ContainerBuilder builder = new();

        builder.RegisterType<TrackFactory>().As<ITrackFactory>().SingleInstance();
        builder.RegisterType<TrackCollectionFactory>().As<ITrackCollectionFactory>().SingleInstance();

        builder.RegisterType<TagLibTrackMetadataReader>().As<ITrackMetadataReader>().SingleInstance();
        builder.RegisterType<TagLibTrackMetadataWriter>().As<ITrackMetadataWriter>().SingleInstance();

        return builder.Build();
    }
}
