using UnityEngine;

public interface ICharacter :IUpdatable, IInputSubscriber, IDamagable, ICameraPublisher { //, IMovable IDamagable
    GameObject Instance { get; set; }
    Vector2 Position { get; set; }
    bool ControlAvailable { get; set; }
}