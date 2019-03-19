using System;
using UnityEngine;
using Object = UnityEngine.Object;


public class ObjectCreator : IObjectCreator {
    
    public GameObject CreatePlayer(Vector3 position, Quaternion quaternion) {
        return CreateSomeObject("Prefabs/pipyaka",position,quaternion);
    }

    public GameObject CreateWall(Vector3 position) {
        return CreateSomeObject("Prefabs/wall", position, Quaternion.identity);
    }
    public GameObject CreateWeapon(Vector3 position, WeaponType type) {
        return CreateSomeObject("Prefabs/" + type.ToString().ToLower(), position, Quaternion.identity);
    }
    private GameObject CreateSomeObject(String path, Vector3 position, Quaternion quaternion) {
        var playerPrefab = Resources.Load(path);
        return Object.Instantiate(playerPrefab, position, quaternion) as GameObject;
    }
}