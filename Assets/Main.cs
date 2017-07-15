using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    public int width = 10;
    public int height = 10;
	// Use this for initialization
	void Start () {
		
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
                Gizmos.color = x % 2 == 0 ? Color.black : Color.white;
                Vector3 position = new Vector3(-width / 2 + x, -height / 2 + y, 0);
                Gizmos.DrawCube(position, Vector3.one);
            }
        }
    }
}
