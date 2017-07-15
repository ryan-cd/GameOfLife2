using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    public int width = 10;
    public int height = 10;
    public int simulationCount = 20;
    public Grid grid;
	// Use this for initialization
	void Start () {
        grid = GetComponent<Grid>();
        grid.GenerateGrid(width, height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid.grid[x, y] == '#')
                    Gizmos.color = Color.red;
                else if (grid.grid[x, y] == '*')
                    Gizmos.color = Color.blue;
                else
                    Gizmos.color = Color.black;
                Vector3 position = new Vector3(-width / 2 + x, -height / 2 + y, 0);
                Gizmos.DrawCube(position, Vector3.one);
            }
        }
    }
}
