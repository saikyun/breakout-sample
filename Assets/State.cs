using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class State : MonoBehaviour
{
    public GameObject grid;
    public int nof_columns = 10;
    public GameObject tilePrefab;

    void Init()
    {
        Debug.Log("initing");

        if (grid) { Destroy(grid); }

        grid = new GameObject("Grid");

        var tile_size = Math.CalcBounds(tilePrefab).size;

        var x = 0f;
        var y = 0f;
        var margin = 0.1f;

        //y x x x x x x x 
        //y x x x x x x x 
        //y x x x x x x x 

        // for each row
        for (int row = 0; row < 7; row++) {
            // for each column, in each row
            for (int column = 0; column < nof_columns; column++) {
                var tile = Instantiate(tilePrefab);
                tile.name = "Tile " + column + "/" + row;
                tile.transform.parent = grid.transform;
                tile.transform.position = new Vector3(x, y, 0);

                // set pos of tile
                x += tile_size.x + margin;
            }

            // after a row is done, reset x to the far left of the grid
            x = 0f;
            y += tile_size.y + margin;
        }
    }

    public static State instance;

    [InitializeOnLoadMethod]
    static void InitOnReload()
    {
        if (!Application.isPlaying) { Debug.Log("in editor, returning..."); return; }

        if (instance == null)
        {
            instance = FindObjectsOfType<State>()[0];
        }

        instance.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
