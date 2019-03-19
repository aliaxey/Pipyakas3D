using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour {

    void Start() {
        IObjectCreator objectCreator = new ObjectCreator();
        IGridManager gridManager = new GridManager(objectCreator,Constants.MAP_WIDTH,Constants.MAP_HEIGHT);
        IObjectStorage objectStorage = new ObjectStorage();
        ICameraManager cameraManager = new CameraManager(objectStorage);
        IWeaponManager weaponManager = new WeaponManager(objectStorage);
        objectStorage.ObjectCreator = objectCreator;
        objectStorage.WeaponManager = weaponManager;
        objectStorage.Camera = cameraManager;
        objectStorage.GridManager = gridManager;
        ICharacter pipyaka = new Player(objectStorage, 3, 3);
        pipyaka.SetSubscriber(cameraManager);
        objectStorage.Player = pipyaka;

        var updateManagerHolder = new GameObject("UpdateManager");
        updateManagerHolder.AddComponent<UpdateManager>();
        IUpdateManager updateManager = updateManagerHolder.GetComponent<UpdateManager>();
        IInputManager inputManager = new InputManager();
        updateManager.AddSubscriber(weaponManager);
        updateManager.AddSubscriber(inputManager);
        updateManager.AddSubscriber(pipyaka);
        inputManager.AddSubscriber(pipyaka); 
    }


}
