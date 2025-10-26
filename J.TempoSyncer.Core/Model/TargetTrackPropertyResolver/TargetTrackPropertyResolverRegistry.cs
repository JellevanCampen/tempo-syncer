using J.TempoSyncer.Core.Interface;

namespace J.TempoSyncer.Core.Model.TargetTrackPropertyResolver;

/// <summary>
/// Base implementation of a <see cref="ITargetTrackPropertyResolverRegistry"/>.
/// </summary>
public class TargetTrackPropertyResolverRegistry : ITargetTrackPropertyResolverRegistry
{
    private readonly Dictionary<Type, ITargetTrackPropertyResolver> _resolverMap;

    /// <summary>
    /// Initializes a new <see cref="TargetTrackPropertyResolverRegistry"/> instance based on a collection of resolvers.
    /// </summary>
    /// <param name="resolvers">Resolvers to add to the registry.</param>
    public TargetTrackPropertyResolverRegistry(IEnumerable<ITargetTrackPropertyResolver> resolvers)
    {
        _resolverMap = resolvers.ToDictionary(r => r.TargetTrackPropertyType, r => r);
    }

    /// <inheritdoc/>
    public bool TryGetResolver(Type targetTrackPropertyType, out ITargetTrackPropertyResolver? resolver)
    {
        return _resolverMap.TryGetValue(targetTrackPropertyType, out resolver);
    }
}
