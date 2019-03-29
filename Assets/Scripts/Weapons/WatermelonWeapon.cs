using UnityEngine;
using UnityEditor;
using static Constants;

public class WatermelonWeapon : Weapon {
    private Vector2 direction;
    private float deltaDistance;
    private int doneDistance;
    private Vector3 target;
    public WatermelonWeapon(IWeaponManager weapon, Vector2 pos, Vector2 direction):base(weapon,pos) {
        this.direction = direction;
        var spawnPosition = new Vector3(pos.x * BLOCK_SIZE, pos.y * BLOCK_SIZE, Z_DISTANCE);
        instance = weaponManager.ObjectCreator.CreateWeapon(spawnPosition, WeaponType.WATERMELON);
        var currPosition = instance.transform.position;
        target = new Vector3(currPosition.x + (direction.x * WATERMELON_DISTANCE * BLOCK_SIZE),
            currPosition.y + (direction.y * WATERMELON_DISTANCE * BLOCK_SIZE),
            Z_DISTANCE);
        doneDistance = 0;
    }
    public override void FrameUpdate() {
        var currPosition = instance.transform.position;
        var speed = WATERMELON_SPEED * Time.deltaTime;
        instance.transform.position = Vector3.Lerp(currPosition, target, speed);
        if(instance.transform.position != target) {
            deltaDistance += speed;
            if(deltaDistance > BLOCK_SIZE) {
                deltaDistance = 0;
                position = position + direction;
                if (CheckCell(position)) {
                    DamageCell(position, 30);
                    Destroy();
                }            
            }
        } else {
            Destroy();
        }
        
    }

}
