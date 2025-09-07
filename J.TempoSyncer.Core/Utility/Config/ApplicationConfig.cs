namespace J.TempoSyncer.Core.Utility.Config;

using System.Text.Json;

/// <summary>
/// Class containing all configurable properties of the application.
/// </summary>
public class ApplicationConfig
{
    /// <summary>
    /// Serialization options for reading and writing the application config to a JSON file.
    /// </summary>
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };

    /// <summary>
    /// Gets or sets the file path to the FFMPEG executable.
    /// </summary>
    public string FilePathFFMPEG { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the file path to the FFProbe executable.
    /// </summary>
    public string FilePathFFProbe { get; set; } = string.Empty;

    /// <summary>
    /// Read the application config from a JSON file.
    /// </summary>
    /// <param name="fileName">Name of the JSON file to read the application config from.</param>
    /// <returns>Application config read from the specified JSON file. Default application configuration if there was
    /// an error reading the JSON file.</returns>
    public static ApplicationConfig ReadConfig(string fileName)
    {
        // Return default application config if the config file doesn't exist.
        if (File.Exists(fileName))
        {
            try
            {
                string json = File.ReadAllText(fileName);

                var applicationConfig = JsonSerializer.Deserialize<ApplicationConfig>(json)
                    ?? throw new InvalidOperationException("Deserialized config is null.");

                return applicationConfig;
            }
            catch (JsonException ex)
            {
                // Handle malformed JSON
                Console.Error.WriteLine($"JSON error while reading config: {ex.Message}");
            }
            catch (IOException ex)
            {
                // Handle file access issues
                Console.Error.WriteLine($"I/O error while reading config file: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                // Handle null deserialization result
                Console.Error.WriteLine($"Config deserialization failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch-all for any other unexpected errors
                Console.Error.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        // Fallback to default config if anything goes wrong.
        return new ApplicationConfig();
    }

    /// <summary>
    /// Write the application config to a JSON file.
    /// </summary>
    /// <param name="applicationConfig">Application config instance to write to a JSON file.</param>
    /// <param name="fileName">Name of the JSON file to write the application config to.</param>
    public static void WriteConfig(ApplicationConfig applicationConfig, string fileName)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(applicationConfig, options);
        File.WriteAllText(fileName, json);
    }
}
