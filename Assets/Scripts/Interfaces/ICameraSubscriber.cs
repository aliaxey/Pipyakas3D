using UnityEngine;
public interface ICameraSubscriber {
    void NotifyStartMovie(Vector2 position, Vector2 direction, Vector2 delta);
    void NotifyFinishMovie(Vector2 direction);
}