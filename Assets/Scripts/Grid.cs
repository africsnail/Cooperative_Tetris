using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // VARIABLES

    private static GameObject Border { get; set; }
    private static GameObject[,] lineToAnimate { get; set; }

    // Grid dimensions
    public static int gridHeight = 21;
    private static int gridWidth = 12;

    // Game Over timer
    public float timeGameOver;
    public float timeToGameOver = 10.0f;

    public static int[,] PlayGrid { get; set; }
    public static bool _gameOver;
    public static SubGrid MovementGrid { get; set; }

    private static readonly int ColorBlack = Shader.PropertyToID("_Color");

    private void InitializeGrid()
    {
        Border = new GameObject();
        Border.name = "Border";
        PlayGrid = new int[gridWidth, gridHeight];
        // Play area dimensions
        // const int w = 12;
        // const int h = 22;
        // Generating play area grid
        //Generating cubes 
        MovementGrid = new SubGrid
        {
            Color = new Color[gridWidth, gridHeight],
            IsActive = new bool[gridWidth, gridHeight],
            IsClear = new bool[gridWidth, gridHeight],
            GridCube = new GameObject[gridWidth, gridHeight]
        };
        lineToAnimate = new GameObject[gridWidth, gridHeight];
        for (var x = 0; x < gridWidth; x++)
        for (var y = 0; y < gridHeight; y++)
            if (x < 1 || x > 10 || y < 1)
            {
                PlayGrid[x, y] = 1;
                if (PlayGrid[x, y] == 1)
                {
                    MovementGrid.GridCube[x, y] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    MovementGrid.GridCube[x, y].name = "Border cube";
                    MovementGrid.GridCube[x, y].transform.parent = Border.transform;
                    MovementGrid.GridCube[x, y].transform.position = new Vector3(x - 1, y - 1, 0);
                    var cubeRenderer = MovementGrid.GridCube[x, y].GetComponent<Renderer>();
                    cubeRenderer.material.SetColor(ColorBlack, Color.black);
                    var cubeCollider = MovementGrid.GridCube[x, y].GetComponent<Collider>();
                    DestroyImmediate(cubeCollider);
                    MovementGrid.Color[x, y] = Color.black;
                    MovementGrid.IsActive[x, y] = true;
                    MovementGrid.IsClear[x, y] = false;
                }
            }
    }

    public static void GameOver()
    {
        if (_gameOver == false)
        {
            var kick = 3f;
            for (var x = 1; x < gridWidth - 1; x++)
            for (var y = 1; y < gridHeight - 1; y++)
                if (MovementGrid.GridCube[x, y] != null)
                {
                    var gameOverRigidbody = MovementGrid.GridCube[x, y].AddComponent<Rigidbody>();
                    gameOverRigidbody.AddForce(0, 0, -kick, ForceMode.Impulse);
                    gameOverRigidbody.AddTorque(0, 5, 5, ForceMode.Impulse);
                    Debug.Log("Game Over!");
                }

            _gameOver = true;
            /*if (gameOver)
                while (gameOver)
                {
                    {
                        timeGameOver += Time.deltaTime;
                        if (timeGameOver >= timeToGameOver)
                        {
                            for (int x = 1; x < gridWidth - 1; x++)
                            for (int y = 1; y < gridHeight - 1; y++)
                            {
                                if (MovementGrid.GridCube[x, y] != null)
                                    Destroy(MovementGrid.GridCube[x, y]);
                                PlayGrid[x, y] = 0;
                            }
                            gameOver = false;
                        }
                    }
                }*/
        }
    }

    private void GridManager(int w, int h)
    {
        var isClear = new List<int>();
        //Debug.Log("......");
        for (var y = 1; y < h - 1; y++)
        {
            var lineClear = true;
            for (var x = 1; x < w - 1; x++)
                if (PlayGrid[x, y] == 1)
                {
                    if (MovementGrid.IsActive[x, y] == false)
                    {
                        //Debug.Log("Checking coordinates: " + x + ", " + y + ". Value: " + PlayGrid[x, y]);
                        MovementGrid.GridCube[x, y] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        MovementGrid.GridCube[x, y].name = "Grid cube " + (x - 1) + "_" + (y - 1);
                        MovementGrid.GridCube[x, y].transform.position = new Vector3(x - 1, y - 1, 0);
                        var cubeRenderer = MovementGrid.GridCube[x, y].GetComponent<Renderer>();
                        //var cubeCollider = MovementGrid.GridCube[x, y].GetComponent<Collider>();
                        cubeRenderer.material.SetColor(ColorBlack, MovementGrid.Color[x, y]);
                        //DestroyImmediate(cubeCollider);
                        MovementGrid.IsActive[x, y] = true;
                    }

                    var cubeRenderer2 = MovementGrid.GridCube[x, y].GetComponent<Renderer>();
                    cubeRenderer2.material.SetColor(ColorBlack, MovementGrid.Color[x, y]);
                }
                else if (PlayGrid[x, y] == 0)
                {
                    lineClear = false;
                }

            if (lineClear)
            {
                //Debug.Log("xd2");
                isClear.Add(y);
                for (var x = 1; x < w - 1; x++)
                {
                    MovementGrid.IsClear[x, y] = true;
                    if (MovementGrid.IsClear[x, y])
                    {
                        lineToAnimate[x, y] = Instantiate(MovementGrid.GridCube[x, y]);
                        StartCoroutine(lineClearAnimation(x, y, gridWidth));
                        DestroyImmediate(MovementGrid.GridCube[x, y]);
                        PlayGrid[x, y] = 0;
                        MovementGrid.IsClear[x, y] = false;
                        MovementGrid.IsActive[x, y] = false;
                    }
                }
            }
        }

        isClear.Reverse();
        if (isClear.Count > 0)
        {
            for (var numberOfLine = 0; numberOfLine < isClear.Count; numberOfLine++)
            {
                Debug.Log("Moving one row down:" + numberOfLine);
                for (var y = 0; y < h - 1; y++)
                for (var x = 1; x < w - 1; x++)
                    if (y >= isClear[numberOfLine])
                    {
                        PlayGrid[x, y] = PlayGrid[x, y + 1];
                        MovementGrid.Color[x, y] = MovementGrid.Color[x, y + 1];
                        MovementGrid.IsActive[x, y] = MovementGrid.IsActive[x, y + 1];
                        {
                            if (MovementGrid.GridCube[x, y] != null)
                                //remove the block on x,y
                                DestroyImmediate(MovementGrid.GridCube[x, y]);

                            if (MovementGrid.GridCube[x, y + 1] != null)
                            {
                                // If there is a block above, move it down and copy it, then remove it.
                                MovementGrid.GridCube[x, y + 1].transform.Translate(Vector3.down * 1, Space.World);
                                MovementGrid.GridCube[x, y] = Instantiate(MovementGrid.GridCube[x, y + 1]);
                                DestroyImmediate(MovementGrid.GridCube[x, y + 1]);
                                MovementGrid.GridCube[x, y].name = "Grid cube " + (x - 1) + "_" + (y - 1) +
                                                                   "_CreatedAtRound_ " + numberOfLine;
                                MovementGrid.IsActive[x, y] = true;
                            }
                            else if (MovementGrid.IsActive[x, y])
                            {
                                // If there isn't a block above, deactivate the field.
                                MovementGrid.IsActive[x, y] = false;
                            }
                        }
                    }
            }

            isClear.Clear();
        }
    }

    private void LockManager()
    {
        foreach (var block in Blocks._tetrominos.Where(block => block.IsLocked))
        {
            int size;
            if (block.Type == "I" || block.Type == "O")
                size = 4;
            else
                size = 3;
            for (var x = 0; x < size; x++)
            for (var y = 0; y < size; y++)
                if (block.RGrid[x, y] == 1)
                {
                    int newY;
                    if (size == 4)
                        newY = y - 1;
                    else
                        newY = y;
                    PlayGrid[(int) block.Location[0] + x + 1, (int) block.Location[1] + newY - 2] = 1;
                    MovementGrid.Color[(int) block.Location[0] + x + 1, (int) block.Location[1] + newY - 2] =
                        block.Color;
                }

            block.TetrominoGo.transform.position = Blocks.spawnArea;
            block.Location = new float[] {3, 30, 0};
            while (block.RotationState != 0)
            {
                block.AtSpawn = true;
                Debug.Log("Attempting a rotation at spawn");
                Rotation.Rotate("Ac", 0, 0);
                block.RotationState -= 1;
            }

            if (block.RotationState == 0) block.AtSpawn = false;

            block.IsLocked = false;
        }
    }

    private void Start()
    {
        InitializeGrid();
    }


    // Update is called once per frame
    private void Update()
    {
        LockManager();
        GridManager(gridWidth, gridHeight);
    }

    private IEnumerator lineClearAnimation(int x, int y, int w)
    {
        Debug.Log("Starting line clear coroutine");

        {
            var gameOverRigidbody = lineToAnimate[x, y].AddComponent<Rigidbody>();
            gameOverRigidbody.position += Vector3.back;
            //gameOverRigidbody.AddForce(0, 0, 0, ForceMode.Impulse);
            gameOverRigidbody.AddTorque(0, -10, -2, ForceMode.Impulse);

            while (lineToAnimate[x, y].transform.position[1] > -10)
            {
                Debug.Log("waiting");
                yield return null;
            }

            Debug.Log("Coroutine has concluded");
            Destroy(lineToAnimate[x, y]);
        }
    }
}