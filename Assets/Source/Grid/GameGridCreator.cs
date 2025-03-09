using UnityEngine;

public class GameGridCreator : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _cellSize;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Transform _gridPosition;

    private Cell[,] _grid;

    public Cell[,] Grid => _grid;

    public void Init()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        _grid = new Cell[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Vector3 position = _gridPosition.position + new Vector3(_cellSize * x, _cellSize * y, 0);
                var cell = Instantiate(_cellPrefab, position, Quaternion.identity);
                cell.transform.SetParent(transform);
                _grid[x, y] = cell;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(_grid == null)
            return;

        Gizmos.color = Color.red;
        Vector3 size = new Vector3(_cellSize / 2, _cellSize / 2, 0);

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Gizmos.DrawCube(_grid[x, y].transform.position, size);
            }
        }
    }
}