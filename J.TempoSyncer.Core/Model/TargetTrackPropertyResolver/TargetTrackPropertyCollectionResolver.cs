using J.TempoSyncer.Core.Interface;

namespace J.TempoSyncer.Core.Model.TargetTrackPropertyResolver;

/// <summary>
/// Resolver that can resolve a <see cref="TargetTrackPropertyCollection"/> for a <see cref="Track"/>.
/// </summary>
public class TargetTrackPropertyCollectionResolver(ITargetTrackPropertyResolverRegistry resolverRegistry)
{
    /// <summary>
    /// Resolves the specified <see cref="TargetTrackPropertyCollection"/> for the specified <see cref="Track"/>.
    /// </summary>
    /// <param name="track">Track for which to resolve the <see cref="TargetTrackPropertyCollection"/>.</param>
    /// <param name="targetTrackProperties"><see cref="TargetTrackPropertyCollection"/> to resolve.</param>
    /// <returns>The original <see cref="Track"/> instance modified to comply with the 
    /// <see cref="ITargetTrackProperty"/>.</returns>
    /// <exception cref="InvalidOperationException">Exception thrown if one of the <see cref="ITargetTrackProperty"/> 
    /// instances in the <see cref="TargetTrackPropertyCollection"/> could not be resolved.</exception>
    public async Task<Track> ResolveAsync(Track track, TargetTrackPropertyCollection targetTrackProperties)
    {
        foreach (ITargetTrackProperty targetTrackProperty in targetTrackProperties.Properties)
        {
            bool success = resolverRegistry.TryGetResolver(targetTrackProperty, out ITargetTrackPropertyResolver? resolver);
            if (!success)
            {
                throw new InvalidOperationException($"No resolver could be found for target track property '{targetTrackProperty}'.");
            }

            track = await resolver!.ResolveAsync(track, targetTrackProperty);
        }

        return track;
    }
}
