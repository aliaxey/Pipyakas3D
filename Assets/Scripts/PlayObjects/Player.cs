using UnityEngine;
using static Constants;

public class Player : ICharacter{
    private IObjectStorage objectStorage;
    private IGridManager grid;
    private GameObject instance;
    private Vector2 position;
    private float health;
    private IMovieContrller movieController;
    private bool controlAvailable;
    private Animator animator;
    
    public GameObject Instance {
        get { return instance; }
        set { instance = value; }
    }

    public Vector2 Position {
        get { return position; }
        set { position = value; }
    }

    public bool ControlAvailable {
        get { return controlAvailable; }
        set { controlAvailable = value; }
    }

    public Player(IObjectStorage storage, int x, int y) {
        objectStorage = storage;
        grid = storage.GridManager;
        movieController = new MovieContrller(grid, this, Direction.UP);
        position = new Vector2(x, y);
        var playerPosition = new Vector3(position.x * BLOCK_SIZE, position.y * BLOCK_SIZE, Z_DISTANCE);
        instance = objectStorage.ObjectCreator.CreatePlayer(playerPosition, Quaternion.identity);
        animator = instance.GetComponent<Animator>();
        health = PIPYAKA_HELTH;
        movieController.MovieDirection = Direction.IDLE;
        controlAvailable = true;
    }


    public void FrameUpdate() {
        if (movieController.MovieDirection != Direction.IDLE) {
            if (movieController.Direction.Equals(movieController.MovieDirection)) {
                movieController.MovieToDirection();
                animator.SetBool("walk", true);
            } else {
                animator.SetBool("walk", false);
                movieController.RotateToDirection();
            }
        }
    }

    public void DamageRecive(float damage) {
        health -= damage;
        if (health <= 0) {
            Debug.Log("dead");
        }
    }

    public void NotifyMovie(Direction direction) {
        if (controlAvailable) {
            movieController.MovieDirection = direction;
            controlAvailable = false;
        }
    }

    public void NotifyAttack() {
        if (controlAvailable) {
            objectStorage.WeaponManager.CreateWeapon(WeaponType.WATERMELON, position, movieController.DirectionVector); 
        }
    }

    public void SetSubscriber(ICameraSubscriber subscriber) {
        movieController.CameraSubscriber = subscriber;
    }

    public void RemoveSubscriber(ICameraSubscriber subscriber) {
        movieController.CameraSubscriber = null;
    }
}












/*
 *         if (possiblePosition.x < 0 || possiblePosition.y < 0) {
            return false;
        }
    private void MovieToDirection() {
        float deltaMovie = Time.deltaTime * MOVIE_SPEED;
        if(!isMovie) {
            controlAvailable = false;
            switch (movieDirection) {
                case Direction.UP:
                    movieVector = Vector2.up;
                    break;
                case Direction.DOWN:
                    movieVector = Vector2.down;
                    break;
                case Direction.LEFT:
                    movieVector = Vector2.left;
                    break;
                case Direction.RIGHT:
                    movieVector = Vector2.right;
                    break;         
            }
            target = (position + movieVector) * BLOCK_SIZE; Debug.Log(">>>>>>>>>>>>>>>>>" + position+" "+ movieVector + ">>>>>>>>>" + (position+movieVector));
            isMovie = true;
        }
        var currentPosition = instance.transform.position; 
        if(((currentPosition.x + (deltaMovie * movieVector.x))*movieVector.x > target.x * movieVector.x)||
           ((currentPosition.y + (deltaMovie * movieVector.y))*movieVector.y > target.y * movieVector.y)){ 
            instance.transform.position = new Vector3(target.x, target.y, Z_DISTANCE);
            position += movieVector;
            movieDirection = Direction.IDLE;
            controlAvailable = true;
            isMovie = false; Debug.Log("stand" + position);
        } else {
            var deltaVector = movieVector * deltaMovie;
            var newPosition = new Vector3(currentPosition.x + deltaVector.x, currentPosition.y + deltaVector.y, Z_DISTANCE);
            instance.transform.position = newPosition; Debug.Log("movie");
        }
    }

    //oops =)
    private void RotateToDirection() {
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
                reverse = direction == Direction.DOWN||direction == Direction.RIGHT;
                target = 90;
                break;
            case Direction.RIGHT:
                reverse = direction == Direction.UP;
                target = 270;
                break;
        }
        //test for end rotation
        var rotation = instance.transform.rotation.eulerAngles.z;
        if (reverse) {
            deltaRotate = -deltaRotate;
            if (direction == Direction.UP) {
                rotation = 360;
                direction = Direction.IDLE;
            }
        }
        if(direction == Direction.IDLE && reverse==false) {
            deltaRotate = -deltaRotate;
            reverse = true;
        }
        if(((rotation + deltaRotate > target)!=reverse)|| (rotation + deltaRotate == target)) { //it's incridebal
            instance.transform.rotation = Quaternion.AngleAxis(target, Vector3.forward);
            direction = movieDirection;
            movieDirection = Direction.IDLE;
            controlAvailable = true;
        } else {
            var rotationVector = new Vector3(0, 0, deltaRotate);
            instance.transform.Rotate(rotationVector); 
        }  
    }
}
/*        
 *        
                    target = (y + 1) * BLOCK_SIZE;
                    target = (y - 1) * BLOCK_SIZE;
                    target = (x - 1) * BLOCK_SIZE;
                    target = (x + 1) * BLOCK_SIZE;
 *        ebug.Log("done------------"+direction+reverse+" "+rotation+" "+deltaRotate+" "+ target);
 *        Debug.Log(rotationVector);
 *        switch (direction) {
            case Direction.UP:
                if() {
                    reverse = movieDirection == Direction.RIGHT;
                }
                break;
            case Direction.DOWN:
                if(movieDirection == Direction.LEFT) {
                    deltaRotate *= -1;
                }
                break;
            case Direction.LEFT:
                if(movieDirection == Direction.UP) {
                    deltaRotate *= -1;
                }
                break;
            case Direction.RIGHT:
                if(movieDirection == Direction.DOWN) {
                    deltaRotate *= -1;
                }
                break;
        }*/
