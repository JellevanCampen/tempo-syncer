using CommunityToolkit.Mvvm.ComponentModel;
using J.TempoSyncer.Core.Utility;

namespace J.TempoSyncer.Core.Model;

/// <summary>
/// An audio track.
/// </summary>
public partial class Track : ObservableObject
{
    public Track(string fileName, TrackMetadata metadata)
    {
        FileName = fileName;
        Metadata = metadata;
    }

    /// <summary>
    /// Gets the file name of the track.
    /// </summary>
    public readonly string FileName;

    /// <summary>
    /// Gets the file format of the track.
    /// </summary>
    public TrackFileFormat FileFormat => TrackFileFormatUtils.GetTrackFileFormatFromFileName(FileName);

    /// <summary>
    /// Gets or sets the metadata of the track.
    /// </summary>
    public TrackMetadata Metadata;

    /// <inheritdoc/>
    public override string? ToString()
    {
        return $"{Metadata.Artists.FirstOrDefault("Unknown")} - {Metadata.Title}";
    }
}
