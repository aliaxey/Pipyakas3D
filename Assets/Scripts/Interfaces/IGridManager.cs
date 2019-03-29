using UnityEngine;
public interface IGridManager {
    IObjectCreator ObjectCreator { get; }
    BaseCell GetCell(int x, int y);
    BaseCell GetCell(Vector2 pos);


}