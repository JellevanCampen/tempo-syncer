using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Core.Interface;

/// <summary>
/// Interface for a factory for creating <see cref="TrackCollection"/> instances.
/// </summary>
public interface ITrackCollectionFactory
{
    /// <summary>
    /// Creates a <see cref="TrackCollection"/> instance from the specified directory.
    /// </summary>
    /// <param name="directory">Directory from which to create a <see cref="TrackCollection"/> instance.</param>
    /// <returns><see cref="TrackCollection"/> instance from the specified file.</returns>
    Task<TrackCollection> FromDirectoryAsync(string directory);
}
