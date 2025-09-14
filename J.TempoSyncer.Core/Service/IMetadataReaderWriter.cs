namespace J.TempoSyncer.Core.Service;

/// <summary>
/// Service for reading and writing metadata from and to autio files.
/// </summary>
public interface IMetadataReaderWriter
{
    /// <summary>
    /// Reads the BPM metadata from the specified audio file.
    /// </summary>
    /// <param name="filePath">Audio file to read the BPM metadata from.</param>
    /// <returns>BPM metadata from the specified audio file. Null if the audio file does not contain BPM metadata.</returns>
    public uint? ReadBPM(string filePath);

    /// <summary>
    /// Writes the BPM metadata to the specified audio file.
    /// </summary>
    /// <param name="filePath">Audio file to write the BPM metadata to.</param>
    /// <param name="bpm">BPM value to write to the audio file.</param>
    /// <returns>Whether the operation was successful.</returns>
    public bool WriteBPM(string filePath, uint bpm);
}
