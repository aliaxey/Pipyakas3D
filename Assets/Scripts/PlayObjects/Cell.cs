using UnityEngine;

public abstract class BaseCell {
    protected GameObject block;
    protected bool isBarrier;
    public bool IsBarrier {
        get { return isBarrier; }
    }
    public GameObject Block {
        get => block;
    }
    
}