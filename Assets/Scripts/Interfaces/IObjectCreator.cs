using UnityEngine;
public interface IObjectCreator {
    GameObject CreatePlayer(Vector3 position, Quaternion quaternion);
    GameObject CreateWall(Vector3 position);
    GameObject CreateWeapon(Vector3 position, WeaponType type);
}