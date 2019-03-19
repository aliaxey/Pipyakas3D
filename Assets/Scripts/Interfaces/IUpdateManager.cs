using UnityEngine;
using UnityEditor;

public interface IUpdateManager {
    bool IsUpdating { get; set; }
    void Update();
    void AddSubscriber(IUpdatable updatable);
    void RemoveSubscriber(IUpdatable updatable);
}

