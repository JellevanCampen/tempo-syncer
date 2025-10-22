using J.TempoSyncer.Core.Interface;
using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Core.Factory;

/// <summary>
/// Factory for creating <see cref="Track"/> instances.
/// </summary>
public class TrackFactory(ITrackMetadataReader metadataProvider) : ITrackFactory
{
    /// <inheritdoc/>
    public async Task<Track> FromFileAsync(string fileName)
    {
        TrackMetadata metadata = await metadataProvider.ReadMetadataAsync(fileName);
        return new(fileName, metadata);
    }
}