using System;
using UnityEngine;

public class Grid : MonoBehaviour {
    public enum CellTypes { EMPTY, ONE, TWO };
    public CellTypes[,] grid { get; private set; }
    public CellTypes[,] newGrid;
    System.Random pseudoRandom = new System.Random(DateTime.Now.Ticks.ToString().GetHashCode());

    public void GenerateGrid (int width, int height)
    {
        grid = new CellTypes[width, height];
        newGrid = new CellTypes[width, height];
        int random;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                random = pseudoRandom.Next(0, 100);
                if (random < 20)
                    grid[x, y] = CellTypes.ONE;
                else if (random < 40)
                    grid[x, y] = CellTypes.TWO;
                else
                    grid[x, y] = CellTypes.EMPTY;
            }
        }
    }

    public void CalculateNextState ()
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                newGrid[x, y] = CalculateCell(x, y);
            }
        }
        grid = newGrid.Clone() as CellTypes[,];
    }

    private CellTypes CalculateCell(int x, int y)
    {
        int[] surroundings = new int[2];
        int width = grid.GetLength(0);
        int height = grid.GetLength(1);
        int[] neighbourCoords = new int[2];

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i == x && j == y)
                    continue;
                neighbourCoords[0] = i;
                neighbourCoords[1] = j;
                if (i < 0)
                    neighbourCoords[0] = width - 1;
                else if (i > width - 1)
                    neighbourCoords[0] = 0;
                if (j < 0)
                    neighbourCoords[1] = grid.GetLength(1) - 1;
                else if (j > grid.GetLength(1) - 1)
                    neighbourCoords[1] = 0;
                if (grid[neighbourCoords[0], neighbourCoords[1]] == CellTypes.ONE)
                    surroundings[0]++;
                else if (grid[neighbourCoords[0], neighbourCoords[1]] == CellTypes.TWO)
                    surroundings[1]++;
            }
        }

        /* Activation */
        if (grid[x, y] == CellTypes.EMPTY && (surroundings[0] + surroundings[1] == 3))
        {
            return surroundings[0] > surroundings[1] ? CellTypes.ONE : CellTypes.TWO;
        }
        /* Deactivation */
        else if (grid[x, y] != CellTypes.EMPTY && surroundings[0] + surroundings[1] < 2)
        {
            return CellTypes.EMPTY;
        }
        else if (grid[x, y] != CellTypes.EMPTY && surroundings[0] + surroundings[1] > 3)
        {
            return CellTypes.EMPTY;
        }
        /* Flip Colors */
        else if (grid[x, y] == CellTypes.ONE && 1 + surroundings[0] <= surroundings[1])
        {
            return CellTypes.TWO;
        }
        else if (grid[x, y] == CellTypes.TWO && 1 + surroundings[1] <= surroundings[0])
        {
            return CellTypes.ONE;
        }
        /* No change */
        else
        {
            return grid[x, y];
        }
    }
}
