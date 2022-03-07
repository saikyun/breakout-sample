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
        var margin = 0.1f;

        for (int row = 0; row < 7; row++) {
            for (int column = 0; x < nof_columns; column++) {
                var tile = Instantiate(tilePrefab);
                tile.name = "Tile " + column + "/" + row;
                tile.transform.parent = grid.transform;
                tile.transform.position = new Vector3(x, 0, 0);

                // set pos of tile
                x += tile_size.x + margin;
            }
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
