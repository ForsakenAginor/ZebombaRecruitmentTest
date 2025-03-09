using System;
using System.Collections.Generic;
using UnityEngine;

public class GridMatchFinder
{
    private readonly Cell[,] _grid;

    public GridMatchFinder(Cell[,] grid)
    {
        _grid = grid != null ? grid : throw new ArgumentNullException(nameof(grid));

        if (grid.GetLength(0) < 3 || grid.GetLength(1) < 3)
            throw new ArgumentException(nameof(grid));

        for (int x = 0; x < _grid.GetLength(0); x++)
            for (int y = 0; y < _grid.GetLength(1); y++)
                _grid[x, y].CellsContainChanged += OnGridContainChanged;
    }

    ~GridMatchFinder()
    {
        for (int x = 0; x < _grid.GetLength(0); x++)
            for (int y = 0; y < _grid.GetLength(1); y++)
                _grid[x, y].CellsContainChanged -= OnGridContainChanged;
    }

    public event Action GridBecameFull;
    public event Action<BallColor> BallRemoved;

    private void OnGridContainChanged()
    {
        var matches = FindMatches();

        if (matches.Count != 0)
        {
            foreach (var match in matches)
            {
                BallRemoved?.Invoke(_grid[match.x, match.y].Ball.Color);
                _grid[match.x, match.y].RemoveBall();
            }
        }
        else
        {
            if (IsGridFull())
                GridBecameFull?.Invoke();
        }
    }

    private bool IsGridFull()
    {
        int rows = _grid.GetLength(0);
        int columns = _grid.GetLength(1);

        for (int x = 0; x < columns; x++)        
            for (int y = 0; y < rows; y++)            
                if (_grid[x, y].Ball == null)                
                    return false;      

        return true;
    }

    private void TryAddCell(List<Vector2Int> list, Vector2Int cell)
    {
        if (list.Contains(cell) == false)
            list.Add(cell);
    }

    private List<Vector2Int> FindMatches()
    {
        List<Vector2Int> solution = new List<Vector2Int>();
        int rows = _grid.GetLength(0);
        int columns = _grid.GetLength(1);

        // rows
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns - 2; x++)
            {
                if (_grid[x, y].Ball != null
                    && _grid[x + 1, y].Ball != null
                    && _grid[x + 2, y].Ball != null
                    && _grid[x, y].Ball.Color == _grid[x + 1, y].Ball.Color
                    && _grid[x + 1, y].Ball.Color == _grid[x + 2, y].Ball.Color)
                {
                    TryAddCell(solution, new Vector2Int(x, y));
                    TryAddCell(solution, new Vector2Int(x + 1, y));
                    TryAddCell(solution, new Vector2Int(x + 2, y));
                }
            }
        }

        // columns
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows - 2; y++)
            {
                if (_grid[x, y].Ball != null
                    && _grid[x, y + 1].Ball != null
                    && _grid[x, y + 2].Ball != null
                    && _grid[x, y].Ball.Color == _grid[x, y + 1].Ball.Color
                    && _grid[x, y + 1].Ball.Color == _grid[x, y + 2].Ball.Color)
                {
                    TryAddCell(solution, new Vector2Int(x, y));
                    TryAddCell(solution, new Vector2Int(x, y + 1));
                    TryAddCell(solution, new Vector2Int(x, y + 2));
                }
            }
        }

        // diagonal left-right, top-bottom
        for (int x = 0; x < columns - 2; x++)
        {
            for (int y = 0; y < rows - 2; y++)
            {
                if (_grid[x, y].Ball != null
                    && _grid[x + 1, y + 1].Ball != null
                    && _grid[x + 2, y + 2].Ball != null
                    && _grid[x, y].Ball.Color == _grid[x + 1, y + 1].Ball.Color
                    && _grid[x + 1, y + 1].Ball.Color == _grid[x + 2, y + 2].Ball.Color)
                {
                    TryAddCell(solution, new Vector2Int(x, y));
                    TryAddCell(solution, new Vector2Int(x + 1, y + 1));
                    TryAddCell(solution, new Vector2Int(x + 2, y + 2));
                }
            }
        }

        // diagonal right-left, top-bottom
        for (int x = 2; x < columns; x++)
        {
            for (int y = 0; y < rows - 2; y++)
            {
                if (_grid[x, y].Ball != null
                    && _grid[x - 1, y + 1].Ball != null
                    && _grid[x - 2, y + 2].Ball != null
                    && _grid[x, y].Ball.Color == _grid[x - 1, y + 1].Ball.Color
                    && _grid[x - 1, y + 1].Ball.Color == _grid[x - 2, y + 2].Ball.Color)
                {
                    TryAddCell(solution, new Vector2Int(x, y));
                    TryAddCell(solution, new Vector2Int(x - 1, y + 1));
                    TryAddCell(solution, new Vector2Int(x - 2, y + 2));
                }
            }
        }

        return solution;
    }
}