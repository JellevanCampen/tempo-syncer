namespace J.TempoSyncer.Core.Interface;

/// <summary>
/// Interface for a registry in which to look up <see cref="ITargetTrackPropertyResolver{TTargetTrackProperty}"/> 
/// instances by an <see cref="ITargetTrackProperty"/>.
/// </summary>
public interface ITargetTrackPropertyResolverRegistry
{
    /// <summary>
    /// Try to get a <see cref="ITargetTrackPropertyResolver"/> for the specified <see cref="ITargetTrackProperty"/> 
    /// type.
    /// </summary>
    /// <param name="targetTrackPropertyType"><see cref="ITargetTrackProperty"/> type for which to get a resolver.</param>
    /// <param name="resolver"><see cref="ITargetTrackPropertyResolver"/> for the specified 
    /// <see cref="ITargetTrackProperty"/> type.</param>
    /// <returns>Whether a <see cref="ITargetTrackPropertyResolver"/> was found for the specified 
    /// <see cref="ITargetTrackProperty"/> type.</returns>
    bool TryGetResolver(Type targetTrackPropertyType, out ITargetTrackPropertyResolver? resolver);

    /// <summary>
    /// Try to get a <see cref="ITargetTrackPropertyResolver"/> for the specified <see cref="ITargetTrackProperty"/>.
    /// </summary>
    /// <param name="targetTrackProperty"><see cref="ITargetTrackProperty"/> for which to get a resolver.</param>
    /// <param name="resolver"><see cref="ITargetTrackPropertyResolver"/> for the specified 
    /// <see cref="ITargetTrackProperty"/>.</param>
    /// <returns>Whether a <see cref="ITargetTrackPropertyResolver"/> was found for the specified 
    /// <see cref="ITargetTrackProperty"/>.</returns>
    bool TryGetResolver(ITargetTrackProperty targetTrackProperty, out ITargetTrackPropertyResolver? resolver)
    {
        return TryGetResolver(targetTrackProperty.GetType(), out resolver);
    }
}
