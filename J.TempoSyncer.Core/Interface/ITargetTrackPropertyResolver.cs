using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Core.Interface;

/// <summary>
/// Non-generic interface for resolvers that can resolve an <see cref="ITargetTrackProperty"/> for a specific 
/// <see cref="Track"/>.
/// </summary>
public interface ITargetTrackPropertyResolver
{
    /// <summary>
    /// Gets the <see cref="ITargetTrackProperty"/> type that this resolver can resolve.
    /// </summary>
    Type TargetTrackPropertyType { get; }

    /// <summary>
    /// Resolves the specified <see cref="ITargetTrackProperty"/> for the specified <see cref="Track"/>.
    /// </summary>
    /// <param name="track">Track for which to resolve the <see cref="ITargetTrackProperty"/>.</param>
    /// <param name="targetTrackProperty"><see cref="ITargetTrackProperty"/> to resolve.</param>
    /// <returns>The original <see cref="Track"/> instance modified to comply with the 
    /// <see cref="ITargetTrackProperty"/>.</returns>
    Task<Track> ResolveAsync(Track track, ITargetTrackProperty targetTrackProperty);
}

/// <summary>
/// Interface for resolvers that can resolve a <see cref="ITargetTrackProperty"/> for a specific <see cref="Track"/>.
/// </summary>
public interface ITargetTrackPropertyResolver<TTargetTrackProperty> : ITargetTrackPropertyResolver
    where TTargetTrackProperty : ITargetTrackProperty
{
    /// <summary>
    /// Resolves the specified <see cref="ITargetTrackProperty"/> for the specified <see cref="Track"/>.
    /// </summary>
    /// <param name="track">Track for which to resolve the <see cref="ITargetTrackProperty"/>.</param>
    /// <param name="targetTrackProperty"><see cref="ITargetTrackProperty"/> to resolve.</param>
    /// <returns>The original <see cref="Track"/> instance modified to comply with the 
    /// <see cref="ITargetTrackProperty"/>.</returns>
    Task<Track> ResolveAsync(Track track, TTargetTrackProperty targetTrackProperty);
}
