using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelModel {
    public Vector2Int player;
    public Vector2Int size;
    public List<Vector2Int> walls;
    public LevelModel() {
        walls = new List<Vector2Int>();
    }
}