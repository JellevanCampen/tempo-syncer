using J.TempoSyncer.Core.Model;

namespace J.TempoSyncer.Core.Utility;

/// <summary>
/// Utility functions for handling audio track file formats.
/// </summary>
public static class TrackFileFormatUtils
{
    private static readonly Dictionary<string, TrackFileFormat> _extensionMap = new()
    {
        { "mp3", TrackFileFormat.MP3 },
        { "flac", TrackFileFormat.FLAC },
        { "ogg", TrackFileFormat.OGG },
        { "m4a", TrackFileFormat.M4A },
    };

    /// <summary>
    /// Gets the <see cref="TrackFileFormat"/> of an audio track file from its file name.
    /// </summary>
    /// <param name="fileName">File name from which to get the <see cref="TrackFileFormat"/>.</param>
    /// <returns><see cref="TrackFileFormat"/> of an audio track file.</returns>
    public static TrackFileFormat GetTrackFileFormatFromFileName(string fileName)
    {
        string extension = Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant();
        return _extensionMap.TryGetValue(extension, out TrackFileFormat format) ? format : TrackFileFormat.Unknown;
    }
}
