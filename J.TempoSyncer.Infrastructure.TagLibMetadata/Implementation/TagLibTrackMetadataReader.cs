using J.TempoSyncer.Core.Interface;
using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Infrastructure.TagLibMetadata.Implementation;

/// <summary>
/// Implementation of <see cref="ITrackMetadataReader"/> using TagLib.
/// </summary>
public class TagLibTrackMetadataReader : ITrackMetadataReader
{
    /// <inheritdoc/>
    public Task<TrackMetadata> ReadMetadataAsync(string trackFile)
    {
        TagLib.File file = TagLib.File.Create(trackFile);

        TrackMetadata metadata = new()
        {
            Title = file.Tag.Title ?? "Unknown",
            Artists = file.Tag.Performers.ToList() ?? [],
            Bpm = (int?)file.Tag.BeatsPerMinute,
        };

        return Task.FromResult(metadata);
    }
}