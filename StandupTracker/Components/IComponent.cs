using System.Windows;

namespace StandupTracker.Components;

public interface IComponent
{
    string Name { get; set; }

    void Design();
}
