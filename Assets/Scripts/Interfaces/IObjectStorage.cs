public interface IObjectStorage {
    IGridManager GridManager{get; set;}
    ICharacter Player { get; set; }
    IObjectCreator ObjectCreator { get; set; }
    ICameraManager Camera { get; set; }
    IWeaponManager WeaponManager { get; set; }
    ICorutinier Corutinier { get; set; }
}