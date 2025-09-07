using J.TempoSyncer.Core.Utility.Config;

ApplicationConfig applicationConfig = new()
{
    FilePathFFMPEG = "C:/Data/Utilities/Video/FFMPEG-v8.0/bin/ffmpeg.exe",
    FilePathFFProbe = "C:/Data/Utilities/Video/FFMPEG-v8.0/bin/ffprobe.exe",
};

ApplicationConfig.WriteConfig(applicationConfig, "config.json");