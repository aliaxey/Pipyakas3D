using UnityEngine;
public interface ILevelLoader {
    Vector2Int Size { get; }
    LevelModel Level { get; }
    LevelModel ReadLevel(int level);
}