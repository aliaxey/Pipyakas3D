using UnityEngine;
using static Constants;
public class CameraManager : ICameraManager {
    private IObjectStorage objectStorage;
    private GameObject camera;
    private bool needUpdate;
    private bool canChange;
    private Vector2 cameraPosition;
    private Vector2 movie;
    private Vector2 oldPosition;
    private float distance;
    public CameraManager(IObjectStorage storage) {
        objectStorage = storage;
        camera = GameObject.Find("Main Camera");
        needUpdate = false;
        cameraPosition = new Vector2(CAMERA_CENTER_X, CAMERA_CENTER_Y);
    }

    public void NotifyStartMovie(Vector2 position, Vector2 direction, Vector2 delta) {
        var target = position + direction;
        if ((Mathf.Abs(target.x - cameraPosition.x) > CAMERA_OFFSET_X) ||(Mathf.Abs(target.y - cameraPosition.y) > CAMERA_OFFSET_Y)) {
            needUpdate = true;
        }
        if (needUpdate) {
            var newPosition = new Vector3(camera.transform.position.x + delta.x, camera.transform.position.y + delta.y, CAMERA_Z_DISTANCE);
            camera.transform.position = newPosition;
        }
    }

    public void NotifyFinishMovie(Vector2 direction) {
        if (needUpdate) { 
        cameraPosition = cameraPosition + direction;
        needUpdate = false;
        }
    }


}
/*    
 *    private void StartMovie(float x,float y) {
        movie = new Vector2(x, y);
        oldPosition = new Vector2(camera.transform.position.x, camera.transform.position.y);
        distance = 0;
        needUpdate = true;
    }
    private void StopMovie(Vector2 movie) {
        cameraPosition += movie;
        needUpdate = false;
    }
    public void CheckCamera(Vector2 pos) {
        if (!needUpdate) {
            if (pos.x > cameraPosition.x + CAMERA_OFFSET_X) {
                StartMovie(1, 0);
                return;
            }
            if (pos.x < cameraPosition.x - CAMERA_OFFSET_X) {
                StartMovie(-1, 0);
                return;
            }
            if (pos.y > cameraPosition.y + CAMERA_OFFSET_Y) {
                StartMovie(0, 1);
                return;
            }
            if (pos.y < cameraPosition.y - CAMERA_OFFSET_Y) {
                StartMovie(0, -1);
                return;
            }
        }
    }

    public void FrameUpdate() {
        if (needUpdate) {
            float deltaDistance = Time.deltaTime * CAMERA_SPEED;
            if (distance >= BLOCK_SIZE) {
                var doneMovie = movie * BLOCK_SIZE;
                camera.transform.position = new Vector3(oldPosition.x + doneMovie.x,oldPosition.y + doneMovie.y,CAMERA_Z_DISTANCE);
                StopMovie(movie);
            } else {
                var deltaMovie = movie * deltaDistance;
                distance += deltaDistance;
                camera.transform.position = new Vector3(oldPosition.x + deltaMovie.x, oldPosition.y + deltaMovie.y, CAMERA_Z_DISTANCE);
            }
        }
    } */