using J.TempoSyncer.Core.Interface;
using System.Collections.ObjectModel;

namespace J.TempoSyncer.Core.Model;

/// <summary>
/// Collection of <see cref="ITargetTrackProperty"/> instances.
/// </summary>
public class TargetTrackPropertyCollection
{
    public ReadOnlyObservableCollection<ITargetTrackProperty> Properties { get; }
    private readonly ObservableCollection<ITargetTrackProperty> _properties;

    public TargetTrackPropertyCollection(IEnumerable<ITargetTrackProperty>? properties = null)
    {
        _properties = (properties is null) ? new() : new(properties);
        Properties = new(_properties);
    }

    /// <summary>
    /// Adds a <see cref="ITargetTrackProperty"/> to the collection.
    /// </summary>
    /// <param name="property"><see cref="ITargetTrackProperty"/> to add to the collection.</param>
    /// <exception cref="ArgumentException">Exception thrown when trying to add more than one instance of the same 
    /// target track property type.</exception>
    /// <remarks>Only one instance per target track property type is allowed.</remarks>
    public void Add(ITargetTrackProperty property)
    {
        Type type = property.GetType();
        if (_properties.Any(p => p.GetType() == type))
        {
            throw new ArgumentException($"Only one instance per target track property type is allowed. Target track property type '{type}' is already present.");
        }

        _properties.Add(property);
    }

    /// <summary>
    /// Removes a <see cref="ITargetTrackProperty"/> from the collection.
    /// </summary>
    /// <param name="property"><see cref="ITargetTrackProperty"/> to remove from the collection.</param>
    /// <returns>Whether the <see cref="ITargetTrackProperty"/> was removed form the collection.</returns>
    public bool Remove(ITargetTrackProperty property)
    {
        return _properties.Remove(property);
    }

    /// <summary>
    /// Clear the entire collection of <see cref="ITargetTrackProperty"/> instances.
    /// </summary>
    public void Clear()
    {
        _properties.Clear();
    }
}
