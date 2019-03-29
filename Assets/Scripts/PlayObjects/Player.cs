using System.Collections;
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
    private bool attackPossible;
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

    public Player(IObjectStorage storage, Vector2 pos) {
        objectStorage = storage;
        grid = storage.GridManager;
        movieController = new MovieContrller(grid, this, Direction.UP);
        position = pos;
        var playerPosition = new Vector3(position.x * BLOCK_SIZE, position.y * BLOCK_SIZE, Z_DISTANCE);
        instance = objectStorage.ObjectCreator.CreatePlayer(playerPosition, Quaternion.identity);
        animator = instance.GetComponent<Animator>();
        health = PIPYAKA_HELTH;
        movieController.MovieDirection = Direction.IDLE;
        controlAvailable = true;
        attackPossible = true;
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
        if (controlAvailable&&attackPossible) {
            objectStorage.WeaponManager.CreateWeapon(WeaponType.WATERMELON, position, movieController.DirectionVector);
            attackPossible = false;
            objectStorage.Corutinier.StartCoroutine(StartCooldown(COOLDOWN));
        }
    }

    public void SetSubscriber(ICameraSubscriber subscriber) {
        movieController.CameraSubscriber = subscriber;
    }

    public void RemoveSubscriber(ICameraSubscriber subscriber) {
        movieController.CameraSubscriber = null;
    }
    private IEnumerator StartCooldown(float time) {
        yield return new WaitForSeconds(time);
        attackPossible = true;
    }
}