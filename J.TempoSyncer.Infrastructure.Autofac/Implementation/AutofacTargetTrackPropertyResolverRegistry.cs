using Autofac;
using J.TempoSyncer.Core.Interface;
using J.TempoSyncer.Core.Model.TargetTrackPropertyResolver;

namespace J.TempoSyncer.Infrastructure.Autofac.Implementation;

/// <summary>
/// Implementation of a <see cref="ITargetTrackPropertyResolverRegistry"/> that retrieves all registered 
/// <see cref="ITargetTrackPropertyResolver"/> instances from an Autofac <see cref="IComponentContext"/>.
/// </summary>
public class AutofacTargetTrackPropertyResolverRegistry : TargetTrackPropertyResolverRegistry
{
    /// <summary>
    /// Initializes a new <see cref="TargetTrackPropertyResolverRegistry"/> instance based on an Autofac 
    /// <see cref="IComponentContext"/>.
    /// </summary>
    /// <param name="componentContext"><see cref="IComponentContext"/> from which to retrieve all registered 
    /// <see cref="ITargetTrackPropertyResolver"/> instances to add to the repository.</param>
    public AutofacTargetTrackPropertyResolverRegistry(IComponentContext componentContext)
        : base(componentContext.Resolve<IEnumerable<ITargetTrackPropertyResolver>>()) { }
}
