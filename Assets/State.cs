using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class State : MonoBehaviour
{
    public GameObject grid;
    public int nof_columns = 10;
    public GameObject tilePrefab;
    public Ball ballPrefab;
    public List<Ball> balls = new List<Ball>();
    public PaddleMovement paddle;

    void InitGrid()
    {

        if (grid) { Destroy(grid); }

        grid = new GameObject("Grid");

        var tile_size = Math.CalcBounds(tilePrefab).size;

        var margin = 0.1f;
        var total_w = (nof_columns * (tile_size.x + margin)) - margin;
        var start_x = -total_w * 0.5f + (tile_size.x * 0.5f);
        var x = start_x;
        var y = 0f;

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
            x = start_x;
            y += tile_size.y + margin;
        }
    }

    void CreateBalls()
    {
        var b = Instantiate(ballPrefab);
        b.transform.position = paddle.transform.position + new Vector3(0, 1f, 0);
        balls.Add(b);
    }

    public void Init()
    {
        Debug.Log("initing");
        InitGrid();

        foreach (var b in balls)
        {
            Destroy(b.gameObject);
        }

        balls = new List<Ball>();

        CreateBalls();
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

        if (instance != null)
        {
            instance.Init();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
