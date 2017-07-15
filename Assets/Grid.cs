using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public char[,] grid { get; private set; }
    public char[,] newGrid;
    System.Random pseudoRandom = new System.Random(DateTime.Now.Ticks.ToString().GetHashCode());
	
    public void GenerateGrid (int width, int height)
    {
        grid = new char[width, height];
        newGrid = new char[width, height];
        int random;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                random = pseudoRandom.Next(0, 100);
                if (random < 20)
                    grid[x, y] = '#';
                else if (random < 40)
                    grid[x, y] = '*';
                else
                    grid[x, y] = '.';
            }
        }
    }
}
