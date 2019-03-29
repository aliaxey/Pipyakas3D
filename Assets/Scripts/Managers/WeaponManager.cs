using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WeaponManager : IWeaponManager {
    private IObjectStorage objectStorage;
    private IList weapons;
    private IList removeWeapons;
    private bool needClear;

    public IObjectCreator ObjectCreator {
        get {
            return objectStorage.ObjectCreator;
        }
    }

    public WeaponManager(IObjectStorage storage) {
        objectStorage = storage;
        weapons = new List<Weapon>();
        removeWeapons = new List<Weapon>(); 
    }
    public void CreateWeapon(WeaponType type,Vector2 pos,Vector2 direction) {
        switch (type) {
            case WeaponType.WATERMELON:
                Weapon weapon = new WatermelonWeapon(this, pos, direction);
                AddWeapon(weapon);
                break;
            default:
                throw new UnityException("Weapon selected, but no such weapon."); //hardcoded
        }
    }
    public void AddWeapon(Weapon weapon) {
        weapons.Add(weapon);
    }


    public void RemoveWeapon(Weapon weapon) {
        removeWeapons.Add(weapon);
        needClear = true;
    }
    public void FrameUpdate() {
        if (needClear) {
            ClearUp();
        }
        foreach (Weapon weapon in weapons) {
            weapon.FrameUpdate();
        }
    }
    private void ClearUp() {
        foreach (Weapon weapon in removeWeapons) {
            weapons.Remove(weapon);
        }
        removeWeapons.Clear();
        needClear = false;
    }
    public void DamageCell(Vector2 position, float damage) {
        if (objectStorage.Player.Position.Equals(position)) {
            objectStorage.Player.DamageRecive(damage);
        }
    }
    public bool CheckCell(Vector2 position) {
        var cell = objectStorage.GridManager.GetCell(position);
        if (cell != null && cell.IsBarrier) {
            return true;
        }
        if (objectStorage.Player.Position.Equals(position)) {
            return true;
        }
        return false;
    }
    
}