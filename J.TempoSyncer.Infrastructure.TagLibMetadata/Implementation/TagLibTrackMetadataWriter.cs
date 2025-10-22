using J.TempoSyncer.Core.Interface;
using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Infrastructure.TagLibMetadata.Implementation;

/// <summary>
/// Implementation of <see cref="ITrackMetadataWriter"/> using TagLib.
/// </summary>
public class TagLibTrackMetadataWriter : ITrackMetadataWriter
{
    /// <inheritdoc/>
    public Task WriteMetadataAsync(Track track)
    {
        TagLib.File file = TagLib.File.Create(track.FileName);
        TrackMetadata metadata = track.Metadata;

        file.Tag.Title = track.Metadata.Title;
        file.Tag.Performers = [.. metadata.Artists];
        if (metadata.Bpm is not null)
        {
            file.Tag.BeatsPerMinute = (uint)metadata.Bpm;
        }

        file.Save();
        return Task.CompletedTask;
    }
}
