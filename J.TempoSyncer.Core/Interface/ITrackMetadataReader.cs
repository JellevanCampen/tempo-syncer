using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Core.Interface;

/// <summary>
/// Interface for classes that can read metadata information for a track.
/// </summary>
public interface ITrackMetadataReader
{
    /// <summary>
    /// Reads the metadata of the specified track file.
    /// </summary>
    /// <param name="trackFile">Track file to read the metadata from.</param>
    /// <returns>Metadata of the specified track file.</returns>
    Task<TrackMetadata> ReadMetadataAsync(string trackFile);
}
