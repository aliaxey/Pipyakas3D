using UnityEngine;
public interface IWeaponManager:IUpdatable {
    IObjectCreator ObjectCreator { get; }
    void CreateWeapon(WeaponType type, Vector2 pos, Vector2 direction);
    void RemoveWeapon(Weapon weapon);
    void DamageCell(Vector2 position, float damage);
    bool CheckCell(Vector2 position);
}