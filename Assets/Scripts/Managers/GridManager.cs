using UnityEngine;
using static Constants;

public class GridManager :IGridManager{
    private IObjectCreator objectCreator;
    private BaseCell[,] walls;
    //private Player player;
    public GridManager(IObjectCreator creator, int width, int height) {
        objectCreator = creator;
        walls = new BaseCell[width,height]; start();
    }

    public IObjectCreator ObjectCreator {
        get {
            return objectCreator;
        }
    }

    public BaseCell GetCell(int x, int y) {
        return walls[x, y];
    }
    public void CreateWall(int x,int y) {
        var block = objectCreator.CreateWall(new Vector3(x * BLOCK_SIZE, y * BLOCK_SIZE, Z_DISTANCE));
        walls[x, y] = new WallCell(block);
    }
    public void ClearCell(int x,int y) {
        Object.Destroy(GetCell(x,y).Block);
        walls[x, y] = null;
    }








    public void start() {
        //player = new Player(objectCreator.CreatePlayer(new Vector3(0,0*Constants.BLOCK_SIZE,0),Quaternion.identity));
        CreateWall(0, 1);
        CreateWall(0, 2);
        CreateWall(1, 0);
        CreateWall(2, 0);
        CreateWall(3, 0);
        //walls[0, 0] = new WallCell(objectCreator.CreateWall(new Vector3(0, 1* Constants.BLOCK_SIZE, 0)));
        //walls[0, 0] = new WallCell(objectCreator.CreateWall(new Vector3(0, 2 * Constants.BLOCK_SIZE, 0)));
       // walls[0, 0] = new WallCell(objectCreator.CreateWall(new Vector3(1* Constants.BLOCK_SIZE, 0 , 0)));
        //walls[0, 0] = new WallCell(objectCreator.CreateWall(new Vector3(-1* Constants.BLOCK_SIZE, 0, 0)));

    }
}
