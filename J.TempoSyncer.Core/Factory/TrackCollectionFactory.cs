using J.TempoSyncer.Core.Interface;
using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Core.Factory;

/// <summary>
/// Factory for creating <see cref="TrackCollection"/> instances.
/// </summary>
public class TrackCollectionFactory(ITrackFactory trackFactory) : ITrackCollectionFactory
{
    /// <inheritdoc/>
    public async Task<TrackCollection> FromDirectoryAsync(string directory)
    {
        string[] trackFiles = Directory.GetFiles(directory, "*.mp3");
        Track[] tracks = await Task.WhenAll(trackFiles.Select(trackFactory.FromFileAsync));
        return new(directory, tracks);
    }
}
