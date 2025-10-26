using J.TempoSyncer.Core.Interface;

namespace J.TempoSyncer.Core.Model.TargetTrackProperty;

/// <summary>
/// <see cref="ITargetTrackProperty"/> that states that the track must have a specified loudness expressed in loudness 
/// units relative to full scale (LUFS).
/// </summary>
/// <param name="TargetLUFS">Target loudness expressed in loudness units relative to full scale (LUFS).</param>
public sealed record LoudnessLufsTargetTrackProperty(int TargetLUFS) : ITargetTrackProperty;
