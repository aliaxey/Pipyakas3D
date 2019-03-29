using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour {

    void Start() {
        IObjectCreator objectCreator = new ObjectCreator();
        ILevelLoader levelLoader = new LevelLoader(LevelHolder.level);
        IGridManager gridManager = new GridManager(objectCreator,levelLoader);
        IObjectStorage objectStorage = new ObjectStorage();
        ICameraManager cameraManager = new CameraManager();
        IWeaponManager weaponManager = new WeaponManager(objectStorage);
        objectStorage.ObjectCreator = objectCreator;
        objectStorage.WeaponManager = weaponManager;
        objectStorage.Camera = cameraManager;
        objectStorage.GridManager = gridManager;
        ICharacter pipyaka = new Player(objectStorage,levelLoader.Level.player);
        pipyaka.SetSubscriber(cameraManager);
        objectStorage.Player = pipyaka;

        var managersHolder = new GameObject("ManagersHolder");
        managersHolder.AddComponent<UpdateManager>();
        managersHolder.AddComponent<Corutinier>();
        IUpdateManager updateManager = managersHolder.GetComponent<UpdateManager>();
        IInputManager inputManager = new InputManager();
        updateManager.AddSubscriber(weaponManager);
        updateManager.AddSubscriber(inputManager);
        updateManager.AddSubscriber(pipyaka);
        inputManager.AddSubscriber(pipyaka); 
        ICorutinier corutinier = managersHolder.GetComponent<Corutinier>();
        objectStorage.Corutinier = corutinier;

    }


}
