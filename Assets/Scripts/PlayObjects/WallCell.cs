
using UnityEngine;

public class WallCell:BaseCell{
    public WallCell(GameObject gameObject) {
        block = gameObject;
        isBarrier = true;
    }
}