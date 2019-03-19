public interface IGridManager {
    IObjectCreator ObjectCreator { get; }
    BaseCell GetCell(int x, int y);
    
}