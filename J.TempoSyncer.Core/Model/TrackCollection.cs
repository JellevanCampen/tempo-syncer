using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace J.TempoSyncer.Core.Model;

/// <summary>
/// Collection of audio tracks.
/// </summary>
public partial class TrackCollection : ObservableObject
{
    public TrackCollection(string directory, IEnumerable<Track> tracks)
    {
        Directory = directory;
        _tracks = new(tracks);
        Tracks = new(_tracks);
    }

    /// <summary>
    /// Gets the directory where the track collection is stored.
    /// </summary>
    public readonly string Directory;

    /// <summary>
    /// Gets the tracks in the track collection.
    /// </summary>
    public ReadOnlyObservableCollection<Track> Tracks { get; }
    private readonly ObservableCollection<Track> _tracks;
}
