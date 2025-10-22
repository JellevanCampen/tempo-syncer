using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Core.Interface;

/// <summary>
/// Interface for a factory for creating <see cref="Track"/> instances.
/// </summary>
public interface ITrackFactory
{
    /// <summary>
    /// Creates a <see cref="Track"/> instance from the specified file.
    /// </summary>
    /// <param name="fileName">Name of the file from which to create a <see cref="Track"/> instance.</param>
    /// <returns><see cref="Track"/> instance from the specified file.</returns>
    Task<Track> FromFileAsync(string fileName);
}
