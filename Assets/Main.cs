using UnityEngine;

public class Main : MonoBehaviour {
    public int width = 10;
    public int height = 10;
    [Range(1, 60)]
    public int frameRate = 10;
    public int simulationCount = 20;
    public bool limitSimulations;
    public Grid grid;

	// Use this for initialization
	void Start () {
        grid = GetComponent<Grid>();
        grid.GenerateGrid(width, height);
	}

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void Update () {
		if (!limitSimulations 
            || limitSimulations && simulationCount > 0 
            || Input.GetMouseButtonDown(0))
        {
            grid.CalculateNextState();
            if (simulationCount > 0)
                simulationCount--;
        }
	}

    private void OnDrawGizmos()
    {
        if (grid != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (grid.grid[x, y] == Grid.CellTypes.ONE)
                        Gizmos.color = Color.red;
                    else if (grid.grid[x, y] == Grid.CellTypes.TWO)
                        Gizmos.color = Color.blue;
                    else
                        Gizmos.color = Color.black;
                    Vector3 position = new Vector3(-width / 2 + x, -height / 2 + y, 0);
                    Gizmos.DrawCube(position, Vector3.one);
                }
            }
        }
    }
}
