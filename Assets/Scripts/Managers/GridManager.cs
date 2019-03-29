using System;
using UnityEngine;
using static Constants;

public class GridManager :IGridManager{
    private IObjectCreator objectCreator;
    private BaseCell[,] walls;
    public GridManager(IObjectCreator creator,ILevelLoader levelLoader) {
        objectCreator = creator;
        walls = new BaseCell[levelLoader.Size.x,levelLoader.Size.y];
        InitWalls(levelLoader);
    }

    public IObjectCreator ObjectCreator {
        get {
            return objectCreator;
        }
    }
    public BaseCell GetCell(Vector2 pos) {
        return GetCell((int)pos.x, (int)pos.y);
    }
    public BaseCell GetCell(int x, int y) {
        try {
            var wall = walls[x, y];
            return wall;
        } catch (IndexOutOfRangeException) {
            return null;
        }
    }
    public void CreateWall(int x,int y) {
        var block = objectCreator.CreateWall(new Vector3(x * BLOCK_SIZE, y * BLOCK_SIZE, Z_DISTANCE));
        walls[x, y] = new WallCell(block);
    }
    public void ClearCell(int x,int y) {
        UnityEngine.Object.Destroy(GetCell(x,y).Block);
        walls[x, y] = null;
    }
    private void InitWalls(ILevelLoader levelLoader) {
        foreach(Vector2Int wall in levelLoader.Level.walls) {
            CreateWall(wall.x, wall.y);
        }
    }
}
