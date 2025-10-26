using J.TempoSyncer.Core.Interface;

namespace J.TempoSyncer.Core.Model.TargetTrackProperty;

/// <summary>
/// <see cref="ITargetTrackProperty"/> that states that the track must have a specified file name format expressed as a
/// string.
/// </summary>
/// <param name="TargetFileNameFormat">Target file name format expressed a string.</param>
public sealed record FileNameFormatTargetTrackProperty(string TargetFileNameFormat) : ITargetTrackProperty;
