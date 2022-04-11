using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tetris
{
    public class TileMap : MonoBehaviour
    {
        // Grid dimensions
        public static int GridHeight = 21;
        public static int GridWidth = 12;
        public static bool IsGameOver;

        private static readonly int ColorId = Shader.PropertyToID("_Color");

        public static List<int> IsClear;
        // VARIABLES

        public GameObject blockPrefab;

        // Game Over timer
        public float timeGameOver;
        public float timeToGameOver = 10.0f;

        public Material blockWithTexture;
        private static GameObject Border { get; set; }
        public static GameObject[,] LineToAnimate { get; set; }
        public static GameObject[,] GameOverCube { get; set; }

        public static int[,] PlayGrid { get; set; }
        public static SubTileMap MovementTileMap { get; set; }


        // Update is called once per frame
        private void Awake()
        {
            InitializeGrid();
        }

        private void Update()
        {
            if (!Menu.Menus[0].IsPaused && !Menu.Menus[2].IsPaused)
            {
                LockManager();
                GridManager(GridWidth, GridHeight);
            }
        }

        public void InitializeGrid()
        {
            Border = new GameObject
            {
                name = "Border"
            };
            PlayGrid = new int[GridWidth, GridHeight];
            MovementTileMap = new SubTileMap
            {
                Color = new Color[GridWidth, GridHeight],
                IsActive = new bool[GridWidth, GridHeight],
                IsClear = new bool[GridWidth, GridHeight],
                GridCube = new GameObject[GridWidth, GridHeight],
                CollisionMap = new bool[GridWidth, GridHeight]
            };
            LineToAnimate = new GameObject[GridWidth, GridHeight];
            for (var x = 0; x < GridWidth; x++)
            for (var y = 0; y < GridHeight; y++)
                if (x < 1 || x > GridWidth - 2 || y < 1)
                {
                    PlayGrid[x, y] = 1;
                    if (PlayGrid[x, y] == 1)
                    {
                        MovementTileMap.GridCube[x, y] = Instantiate(blockPrefab);
                        MovementTileMap.GridCube[x, y].name = "Border cube";
                        MovementTileMap.GridCube[x, y].transform.parent = Border.transform;
                        MovementTileMap.GridCube[x, y].transform.position = new Vector3(x - 1, y - 1, 0);
                        var cubeRenderer = MovementTileMap.GridCube[x, y].GetComponent<Renderer>();
                        cubeRenderer.material.SetColor(ColorId, Color.gray);
                        var cubeCollider = MovementTileMap.GridCube[x, y].GetComponent<Collider>();
                        DestroyImmediate(cubeCollider);
                        MovementTileMap.Color[x, y] = Color.gray;
                        MovementTileMap.IsActive[x, y] = true;
                        MovementTileMap.IsClear[x, y] = false;
                    }
                }
        }

        public static void ClearCollisionMap()
        {
            for (int x = 0; x < GridWidth; x++)
            for (int y = 0; y < GridHeight; y++)
                MovementTileMap.CollisionMap[x, y] = false;
        }

        public static void GameOver(bool isReal)
        {
            if (IsGameOver == false)
            {
                var kick = 3f;
                GameOverCube = new GameObject[GridWidth - 1, GridHeight];
                for (var x = 1; x < GridWidth - 1; x++)
                for (var y = 1; y < GridHeight; y++)
                    if (MovementTileMap.GridCube[x, y] != null)
                    {
                        GameOverCube[x, y] = Instantiate(MovementTileMap.GridCube[x, y]);
                        DestroyImmediate(MovementTileMap.GridCube[x, y]);
                        var gameOverRigidbody = GameOverCube[x, y].AddComponent<Rigidbody>();

                        gameOverRigidbody.AddForce(0, 0, -kick, ForceMode.Impulse);
                        gameOverRigidbody.AddTorque(0, 5, 5, ForceMode.Impulse);

                        MovementTileMap.IsActive[x, y] = false;
                        MovementTileMap.IsClear[x, y] = false;
                        PlayGrid[x, y] = 0;
                    }

                if (isReal)
                {
                    foreach (var block in Blocks.Tetrominos.Where(block => block.IsActive))
                        block.TetrominoGo.transform.position = Blocks.SpawnArea;
                    IsGameOver = true;
                }
            }
        }

        private void GridManager(int w, int h)
        {
            IsClear = new List<int>();
            for (var y = 1; y < h - 1; y++)
            {
                var lineClear = true;
                for (var x = 1; x < w - 1; x++)
                    if (PlayGrid[x, y] == 1)
                    {
                        if (MovementTileMap.IsActive[x, y] == false)
                        {
                            MovementTileMap.GridCube[x, y] =
                                Instantiate(Blocks.Tetrominos.Find(block => block.Type == "O").CubeGo[2, 2]);
                            MovementTileMap.GridCube[x, y].name = "Grid cube " + (x - 1) + "_" + (y - 1);
                            MovementTileMap.GridCube[x, y].transform.position = new Vector3(x - 1, y - 1, 0);
                            var cubeRenderer = MovementTileMap.GridCube[x, y].GetComponent<Renderer>();
                            cubeRenderer.material.SetColor(ColorId, MovementTileMap.Color[x, y]);
                            MovementTileMap.IsActive[x, y] = true;
                        }

                        var cubeRenderer2 = MovementTileMap.GridCube[x, y].GetComponent<Renderer>();
                        cubeRenderer2.material.SetColor(ColorId, MovementTileMap.Color[x, y]);
                    }
                    else if (PlayGrid[x, y] == 0)
                    {
                        lineClear = false;
                    }

                if (lineClear)
                {
                    IsClear.Add(y);
                    for (var x = 1; x < w - 1; x++)
                    {
                        MovementTileMap.IsClear[x, y] = true;
                        if (MovementTileMap.IsClear[x, y])
                        {
                            LineToAnimate[x, y] = Instantiate(MovementTileMap.GridCube[x, y]);
                            StartCoroutine(lineClearAnimation(x, y));
                            DestroyImmediate(MovementTileMap.GridCube[x, y]);
                            PlayGrid[x, y] = 0;
                            MovementTileMap.IsClear[x, y] = false;
                            MovementTileMap.IsActive[x, y] = false;
                        }
                    }
                }
            }

            IsClear.Reverse();
            if (IsClear.Count > 0)
            {
                if (IsClear.Count == 1)
                {
                    ScoreSystem.CurrentAction += 1;
                    ScoreSystem.Score += 100 * ScoreSystem.CurrentLevel;
                    Debug.Log("Single");
                    ScoreSystem.IsB2B = false;
                }
                else if (IsClear.Count == 2)
                {
                    ScoreSystem.CurrentAction += 3;
                    ScoreSystem.Score += 300 * ScoreSystem.CurrentLevel;
                    Debug.Log("Double");
                    ScoreSystem.IsB2B = false;
                }
                else if (IsClear.Count == 3)
                {
                    ScoreSystem.CurrentAction += 5;
                    ScoreSystem.Score += 500 * ScoreSystem.CurrentLevel;
                    Debug.Log("Triple");
                    ScoreSystem.IsB2B = false;
                }
                else if (IsClear.Count == 4)
                {
                    ScoreSystem.CurrentAction += 8;
                    ScoreSystem.Score += 800 * ScoreSystem.CurrentLevel;
                    Debug.Log("Tetris");
                    if (ScoreSystem.IsB2B)
                    {
                        ScoreSystem.CurrentAction += 4;
                        ScoreSystem.Score += 400 * ScoreSystem.CurrentLevel;
                        Debug.Log("Back-To-Back");
                    }

                    ScoreSystem.IsB2B = true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

                // Checking for T-Spin Line Clear
                if (ScoreSystem.IsTSpinLastMove == 1)
                    // Writes 0 to IsTSpin for the last T-Spin to not be counted twice
                    switch (IsClear.Count)
                    {
                        case 1:
                            ScoreSystem.CurrentAction += 4;
                            ScoreSystem.Score += 400 * ScoreSystem.CurrentLevel;
                            if (ScoreSystem.IsB2B)
                            {
                                ScoreSystem.CurrentAction += 4;
                                ScoreSystem.Score += 400 * ScoreSystem.CurrentLevel;
                                Debug.Log("Back-To-Back");
                            }

                            ScoreSystem.IsB2B = true;
                            Debug.Log("T-Spin Single");
                            break;
                        case 2:
                            ScoreSystem.CurrentAction += 8;
                            ScoreSystem.Score += 800 * ScoreSystem.CurrentLevel;
                            if (ScoreSystem.IsB2B)
                            {
                                ScoreSystem.CurrentAction += 6;
                                ScoreSystem.Score += 600 * ScoreSystem.CurrentLevel;
                                Debug.Log("Back-To-Back");
                            }

                            ScoreSystem.IsB2B = true;
                            Debug.Log("T-Spin Double");
                            break;
                        case 3:
                            ScoreSystem.CurrentAction += 12;
                            ScoreSystem.Score += 1200 * ScoreSystem.CurrentLevel;
                            if (ScoreSystem.IsB2B)
                            {
                                ScoreSystem.CurrentAction += 8;
                                ScoreSystem.Score += 800 * ScoreSystem.CurrentLevel;
                                Debug.Log("Back-To-Back");
                            }

                            ScoreSystem.IsB2B = true;
                            Debug.Log("T-Spin Triple");
                            break;
                    }

                // Checking for Mini T-Spin Line Clear
                if (ScoreSystem.IsTSpinLastMove == 2)
                    // Writes 0 to IsTSpin for the last T-Spin to not be counted twice
                    if (IsClear.Count == 1)
                    {
                        ScoreSystem.CurrentAction += 1;
                        if (ScoreSystem.IsB2B)
                            ScoreSystem.CurrentAction += 1;
                        Debug.Log("Mini T-Spin Single");
                    }

                for (var numberOfLine = 0; numberOfLine < IsClear.Count; numberOfLine++)
                for (var y = 0; y < h - 1; y++)
                for (var x = 1; x < w - 1; x++)
                    if (y >= IsClear[numberOfLine])
                    {
                        PlayGrid[x, y] = PlayGrid[x, y + 1];
                        MovementTileMap.Color[x, y] = MovementTileMap.Color[x, y + 1];
                        MovementTileMap.IsActive[x, y] = MovementTileMap.IsActive[x, y + 1];
                        {
                            if (MovementTileMap.GridCube[x, y] != null)
                                //remove the block on x,y
                                DestroyImmediate(MovementTileMap.GridCube[x, y]);

                            if (MovementTileMap.GridCube[x, y + 1] != null)
                            {
                                // If there is a block above, move it down and copy it, then remove it.
                                MovementTileMap.GridCube[x, y + 1].transform.Translate(Vector3.down * 1, Space.World);
                                MovementTileMap.GridCube[x, y] = Instantiate(MovementTileMap.GridCube[x, y + 1]);
                                DestroyImmediate(MovementTileMap.GridCube[x, y + 1]);
                                MovementTileMap.GridCube[x, y].name = "Grid cube " + (x - 1) + "_" + (y - 1) +
                                                                      "_CreatedAtRound_ " + numberOfLine;
                                MovementTileMap.IsActive[x, y] = true;
                            }
                            else if (MovementTileMap.IsActive[x, y])
                            {
                                // If there isn't a block above, deactivate the field.
                                MovementTileMap.IsActive[x, y] = false;
                            }
                        }
                    }

                IsClear.Clear();
            }
        }

        private void LockManager()
        {
            foreach (var block in Blocks.Tetrominos.Where(block => block.IsLocked))
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
                        MovementTileMap.Color[(int) block.Location[0] + x + 1, (int) block.Location[1] + newY - 2] =
                            block.Color;
                    }

                block.TetrominoGo.transform.position = Blocks.SpawnArea;
                block.Location = new float[] {3, 30, 0};
                while (block.RotationState != 0)
                {
                    block.AtSpawn = true;
                    Rotation.Rotate(block.Id, "Ac", 0, 0);
                    block.RotationState -= 1;
                }

                if (block.RotationState == 0) block.AtSpawn = false;

                block.IsLocked = false;
            }
        }

        private IEnumerator lineClearAnimation(int x, int y)
        {
            {
                var lineClearRigidbody = LineToAnimate[x, y].AddComponent<Rigidbody>();
                lineClearRigidbody.position += Vector3.back;
                //lineClearRigidbody.AddForce(0, 0, 0, ForceMode.Impulse);
                lineClearRigidbody.AddForce(0, 0, -0.5f, ForceMode.Impulse);
                lineClearRigidbody.AddTorque(0, -10, 1.1f, ForceMode.Impulse);

                while (LineToAnimate[x, y].transform.position[1] > -10)
                {
                    lineClearRigidbody.AddForce(0, -2, 0, ForceMode.Acceleration);
                    yield return null;
                }

                Destroy(LineToAnimate[x, y]);
            }
        }
    }
}