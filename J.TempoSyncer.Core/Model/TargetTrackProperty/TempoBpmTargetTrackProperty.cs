using J.TempoSyncer.Core.Interface;

namespace J.TempoSyncer.Core.Model.TargetTrackProperty;

/// <summary>
/// <see cref="ITargetTrackProperty"/> that states that the track must have a specified tempo expressed in beats per 
/// minute (BPM).
/// </summary>
/// <param name="TargetBpm">Target tempo expressed in beats per minute (BPM).</param>
public sealed record TempoBpmTargetTrackProperty(int TargetBpm) : ITargetTrackProperty;