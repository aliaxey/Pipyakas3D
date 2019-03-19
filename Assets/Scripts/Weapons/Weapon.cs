using System;
using UnityEngine;

public abstract class Weapon :IUpdatable{
    protected IWeaponManager weaponManager;
    protected GameObject instance;
    protected Vector2 position;
    
    protected Weapon(IWeaponManager manager, Vector2 pos) {
        weaponManager = manager;
        position = pos; 
    }
    protected void DamageCell(Vector2 position, float damage) {
        weaponManager.DamageCell(position, damage);
    }
    protected bool CheckCell(Vector2 position) {
        return weaponManager.CheckCell(position);
    }
    protected void Destroy() {
        GameObject.Destroy(instance);
        weaponManager.RemoveWeapon(this);
    }

    

    public abstract void FrameUpdate();
}
/*    public GameObject Instance { get => instance; set => instance = value; }
    public Vector2 Position { get => position; set => position = value; }
    public bool ControlAvailable { get => true; set {} }*/
