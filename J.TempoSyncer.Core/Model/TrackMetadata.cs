using CommunityToolkit.Mvvm.ComponentModel;

namespace J.TempoSyncer.Core.Model;

/// <summary>
/// Metadata of an audio track.
/// </summary>
public partial class TrackMetadata : ObservableObject
{
    /// <summary>
    /// Gets or sets the title of the audio track.
    /// </summary>
    [ObservableProperty]
    private string _title;

    /// <summary>
    /// Gets or sets the artist of the audio track.
    /// </summary>
    [ObservableProperty]
    private List<string> _artists;

    /// <summary>
    /// Gets or sets the tempo of the track in beats per minute.
    /// </summary>
    [ObservableProperty]
    private int? _bpm;
}
