using UnityEngine;

public interface IMovieContrller {
    Direction Direction { get; set; }
    Direction MovieDirection { get; set; }
    Vector2 DirectionVector { get; }
    ICameraSubscriber CameraSubscriber { get; set; }
    void MovieToDirection();
    void RotateToDirection();

}