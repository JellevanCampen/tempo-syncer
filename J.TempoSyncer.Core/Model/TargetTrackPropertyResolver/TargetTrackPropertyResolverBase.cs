using J.TempoSyncer.Core.Interface;

namespace J.TempoSyncer.Core.Model.TargetTrackPropertyResolver;

/// <summary>
/// Base class for resolvers that can resolve an <see cref="ITargetTrackProperty"/> for a specific 
/// <see cref="Track"/>.
/// </summary>
public abstract class TargetTrackPropertyResolverBase<TTargetTrackProperty> : ITargetTrackPropertyResolver<TTargetTrackProperty>
    where TTargetTrackProperty : ITargetTrackProperty
{
    /// <inheritdoc/>
    public Type TargetTrackPropertyType => typeof(TTargetTrackProperty);

    /// <inheritdoc/>
    public abstract Task<Track> ResolveAsync(Track track, TTargetTrackProperty targetTrackProperty);

    /// <inheritdoc/>
    public Task<Track> ResolveAsync(Track track, ITargetTrackProperty targetTrackProperty)
    {
        return targetTrackProperty is not TTargetTrackProperty typedTargetTrackProperty
            ? throw new ArgumentException($"Expected property of type {typeof(TTargetTrackProperty).Name}", nameof(targetTrackProperty))
            : ResolveAsync(track, typedTargetTrackProperty);
    }
}
