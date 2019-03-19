using UnityEngine;
using UnityEditor;

public class WatermelonWeapon : Weapon {
    private Vector2 direction;
    private int doneDistance;
    private Vector3 target;
    public WatermelonWeapon(IWeaponManager weapon, Vector2 pos, Vector2 direction):base(weapon,pos) {
        this.direction = direction;
        var spawnPosition = new Vector3(pos.x * Constants.BLOCK_SIZE, pos.y * Constants.BLOCK_SIZE, Constants.Z_DISTANCE);
        instance = weaponManager.ObjectCreator.CreateWeapon(spawnPosition, WeaponType.WATERMELON);
        doneDistance = 0;
    }
    public override void FrameUpdate() {
        var currPosition = instance.transform.position;
        target = new Vector3(currPosition.x + (direction.x * Constants.BLOCK_SIZE),currPosition.y + (direction.y * Constants.BLOCK_SIZE),Constants.Z_DISTANCE);
        instance.transform.position = Vector3.Lerp(currPosition, target, Constants.WATERMELON_SPEED);
        DamageCell(position, 30);
        
    }

}
