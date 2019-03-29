using UnityEngine;
using static Constants;
public class CameraManager : ICameraManager {

    private GameObject camera;
    private bool needUpdate;
    private bool canChange;
    private Vector2 cameraPosition;
    private Vector2 movie;
    private Vector2 oldPosition;
    private float distance;
    public CameraManager() {
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