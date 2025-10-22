using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Core.Interface
{
    /// <summary>
    /// Interface for classes that can write metadata information for a track.
    /// </summary>
    public interface ITrackMetadataWriter
    {
        /// <summary>
        /// Writes the metadata of the specified track file.
        /// </summary>
        /// <param name="track">Track to write the metadata to.</param>
        /// <returns>Task being executed.</returns>
        Task WriteMetadataAsync(Track track);
    }
}
