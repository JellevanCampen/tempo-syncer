using System.Diagnostics;
using System.Text.Json;

namespace J.TempoSyncer.Core.Processing;

/// <summary>
/// Helper class for running FFprobe commands.
/// </summary>
public class FFprobeCommandRunner(string filePathFFProbe)
{




    public static string GetBPM(string filePath)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "ffprobe",
                Arguments = $"-v quiet -print_format json -show_format \"{filePath}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        using var doc = JsonDocument.Parse(output);
        if (doc.RootElement.TryGetProperty("format", out var format) &&
            format.TryGetProperty("tags", out var tags))
        {
            if (tags.TryGetProperty("BPM", out var bpm))
                return bpm.GetString();
            if (tags.TryGetProperty("TBPM", out var tbpm))
                return tbpm.GetString();
        }

        return "BPM tag not found";
    }



}
