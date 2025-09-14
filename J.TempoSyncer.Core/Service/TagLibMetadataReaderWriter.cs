namespace J.TempoSyncer.Core.Service;

public class TagLibMetadataReaderWriter : IMetadataReaderWriter
{
    /// <inheritdoc/>
    public uint? ReadBPM(string filePath)
    {
        try
        {
            var file = TagLib.File.Create(filePath);
            var bpm = file.Tag.BeatsPerMinute;
            return (bpm > 0) ? bpm : null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <inheritdoc/>
    public bool WriteBPM(string filePath, uint bpm)
    {
        try
        {
            var file = TagLib.File.Create(filePath);
            file.Tag.BeatsPerMinute = bpm;
            file.Save();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
