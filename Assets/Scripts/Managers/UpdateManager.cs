using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UpdateManager : MonoBehaviour, IUpdateManager
{
    public bool IsUpdating { get; set; } = true;
    private IList<IUpdatable> subscribers = new List<IUpdatable>();
    public void Update() {
        if (IsUpdating) {
            foreach (IUpdatable subscriber in subscribers) {
                subscriber.FrameUpdate();
            }
        }
    }

    public void AddSubscriber(IUpdatable updatable) {
        if (!subscribers.Contains(updatable)) {
            subscribers.Add(updatable);
        }
        
    }

    public void RemoveSubscriber(IUpdatable updatable) {
        subscribers.Remove(updatable);
    }
}