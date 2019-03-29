

public class ObjectStorage :IObjectStorage{
    private IGridManager gridManager;
    private ICharacter player;
    private IObjectCreator creator;
    private ICameraManager camera;
    private IWeaponManager weaponManager;
    private ICorutinier corutinier;

    public  IGridManager GridManager {
        get { return gridManager; }
        set { gridManager = value; }
    }
    public ICharacter Player {
        get { return player; }
        set { player = value; }
    }

    public IObjectCreator ObjectCreator {
        get { return creator; }
        set { creator = value; }
    }
    public ICameraManager Camera {
        get { return camera; }
        set { camera = value; }
    }
    public IWeaponManager WeaponManager {
        get { return weaponManager; }
        set { weaponManager = value; }
    }

    public ICorutinier Corutinier {
        get { return corutinier; }
        set { corutinier = value; }
    }
}