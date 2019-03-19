using System.Collections.Generic;
using UnityEngine;
using static Constants;
public class InputManager : IInputManager {
    private IList<IInputSubscriber> subscribers;
    public InputManager() {
        subscribers = new List<IInputSubscriber>();
    }
    public void AddSubscriber(IInputSubscriber subscriber) {
        subscribers.Add(subscriber);
    }
    public void FrameUpdate() {
        if (Input.GetKey(KEY_UP)){
            NotifyMovie(Direction.UP);
        }
        if (Input.GetKey(KEY_DOWN)) {
            NotifyMovie(Direction.DOWN);
        }
        if (Input.GetKey(KEY_LEFT)) {
            NotifyMovie(Direction.LEFT);
        }
        if (Input.GetKey(KEY_RIGHT)) {
            NotifyMovie(Direction.RIGHT);
        }
        if (Input.GetKey(KEY_ATTACK)) {
            foreach(IInputSubscriber subscriber in subscribers) {
                subscriber.NotifyAttack();
            }
        }
    }
    private void NotifyMovie(Direction direction) {
        foreach(IInputSubscriber subscriber in subscribers) {
            subscriber.NotifyMovie(direction);
        }
    }
}