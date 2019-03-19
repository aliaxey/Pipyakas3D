using System;
using UnityEngine;
using static Constants;

public class MovieContrller :IMovieContrller{
    private readonly IGridManager gridManager;
    private readonly ICharacter movableInstance;
    private Direction direction;
    private bool isMovie;
    private Vector2 target;
    private Vector2 movieVector;
    private Direction movieDirection;
    public ICameraSubscriber CameraSubscriber { get; set; }

    public MovieContrller(IGridManager grid, ICharacter character, Direction startDirection) {
        gridManager = grid;
        movableInstance = character;
        direction = Direction.UP;
        movieDirection = Direction.IDLE;
        character.ControlAvailable = true;
        isMovie = false;
    }

    public Direction Direction {
        get { return direction; }
        set { direction = value; }
    }
    public Direction MovieDirection {
        get { return movieDirection; }
        set { movieDirection = value; }
       }
    public Vector2 DirectionVector {
        get { return GetVector(direction); }
    }
    
    public void MovieToDirection() {
        float deltaMovie = Time.deltaTime * MOVIE_SPEED;
        if (!isMovie) {
            movieVector = GetVector(movieDirection);
            if (CanMovie(movieVector)) {
                target = (movableInstance.Position + movieVector) * BLOCK_SIZE;
                isMovie = true;
                movableInstance.ControlAvailable = false;
                
            } else {                      
                target = movableInstance.Position * BLOCK_SIZE;
                deltaMovie = 0;
                movieDirection = Direction.IDLE;
                isMovie = false;
                movableInstance.ControlAvailable = true;
            }  
        }
        var currentPosition = movableInstance.Instance.transform.position;
        if (((currentPosition.x + (deltaMovie * movieVector.x)) * movieVector.x > target.x * movieVector.x) || //magic of logic
           ((currentPosition.y + (deltaMovie * movieVector.y)) * movieVector.y > target.y * movieVector.y)) {
            movableInstance.Instance.transform.position = new Vector3(target.x, target.y, Z_DISTANCE);         //end of movie
            movableInstance.Position += movieVector;
            movieDirection = Direction.IDLE;
            movableInstance.ControlAvailable = true;
            isMovie = false;
            CameraSubscriber.NotifyFinishMovie(movieVector);
        } else {                            //continue movie
            var deltaVector = movieVector * deltaMovie;
            var newPosition = new Vector3(currentPosition.x + deltaVector.x, currentPosition.y + deltaVector.y, Z_DISTANCE);
            movableInstance.Instance.transform.position = newPosition;
            CameraSubscriber.NotifyStartMovie(movableInstance.Position, movieVector, deltaVector);
        }
    }


    public void RotateToDirection() {
        float deltaRotate = Time.deltaTime * ROTATION_SPEED;
        bool reverse = false;
        float target = 0;
        switch (movieDirection) {
            case Direction.UP:
                reverse = direction == Direction.LEFT;
                if (reverse) {
                    target = 0;
                } else {
                    target = 360;
                }
                break;
            case Direction.DOWN:
                reverse = direction == Direction.RIGHT;
                target = 180;
                break;
            case Direction.LEFT:
                reverse = direction == Direction.DOWN || direction == Direction.RIGHT;
                target = 90;
                break;
            case Direction.RIGHT:
                reverse = direction == Direction.UP;
                target = 270;
                break;
        }
        //test for end rotation
        var rotation = movableInstance.Instance.transform.rotation.eulerAngles.z;
        if (reverse) {
            deltaRotate = -deltaRotate;
            if (direction == Direction.UP) {
                rotation = 360;
                direction = Direction.IDLE;
            }
        }
        if (direction == Direction.IDLE && reverse == false) {
            deltaRotate = -deltaRotate;
            reverse = true;
        }
        if (((rotation + deltaRotate > target) != reverse) || (rotation + deltaRotate == target)) { //it's incridebal
            movableInstance.Instance.transform.rotation = Quaternion.AngleAxis(target, Vector3.forward);
            direction = movieDirection;
            //lastDirection = movieDirection;
            movieDirection = Direction.IDLE;
            movableInstance.ControlAvailable = true;
        } else {
            var rotationVector = new Vector3(0, 0, deltaRotate);
            movableInstance.Instance.transform.Rotate(rotationVector);
        }
    }
    private Vector2 GetVector(Direction direction) {
        Vector2 vector;
        switch (direction) {
            case Direction.UP:
                vector = Vector2.up;
                break;
            case Direction.DOWN:
                vector = Vector2.down;
                break;
            case Direction.LEFT:
                vector = Vector2.left;
                break;
            case Direction.RIGHT:
                vector = Vector2.right;
                break;
            default:
                vector = Vector2.zero;
                break;
        }
        return vector;
    }
    private bool CanMovie(Vector2 intent) {
        var possiblePosition = movableInstance.Position + intent;
        try {
            var cell = gridManager.GetCell((int)possiblePosition.x, (int)possiblePosition.y);
            if (cell != null && cell.IsBarrier) {
                return false;
            }
        }catch(IndexOutOfRangeException) {
            return false;
        }
        return true;
    }
}