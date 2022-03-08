using System;
// ReSharper disable once RedundantUsingDirective
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class Blocks : MonoBehaviour
{
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    public static bool isFalling;
    public static bool activeSpawn;

    public string[] randomType =
    {
        "I", "O", "J", "L", "S", "Z", "T"
    };

    // Gravity timer
    public float timeFall;
    public float timeToFall = 0.5f;
    public bool smoothFallCoroutine;

    // Auto repeat timer
    public float timeAutoRepeat;
    public float timeToAutoRepeat = 0.05f;

    // Lock timer
    public static float timeLock;
    public float timeToLock = 0.5f;
    public static int lockCounter;
    public int lockDeepestRow;

    // Auto repeat delay timer
    public float timeBeginAutoRepeat;
    public float timeToBeginAutoRepeat = 0.3f;
    public bool lastDir;

    // Soft drop timer
    public float timeSoftDrop;
    public float timeToSoftDrop = 0.025f;

    // Spawn timer
    public float timeSpawn;
    public float timeToSpawn = 0.375f;


    // Hold
    public string holdType;
    public bool holdUsed = false;
    public bool holdSpawn = false;

    // Offsets
    public bool move;
    public bool spawn;

    // Keybindings
    public string keybindRight = "right";
    public string keybindLeft = "left";
    public string keybindSoftDrop = "down";
    public string keybindHardDrop = "space";

    // Colors

    // Coroutines
    public bool lineClearCoroutine;

    // Spawn coordinates
    public static Vector3 spawnArea = new Vector3(3, 30, 0);

    // Start are coordinates
    public Vector3 startAre = new Vector3(3, 17, 0);

    // Holding area coordinates
    public Vector3 holdArea = new Vector3(15, 17, 0);

    //List<Tetromino> tetrominos = new List<Tetromino>();
    public static readonly List<Tetromino> _tetrominos = new List<Tetromino>();


    //public int[] debug { get; set; }

    private GameObject HoldBlock = null;

    // Start is called before the first frame update
    private void Start()
    {
        InitializeBlocks();
    }


// Update is called once per frame
    private void Update()
    {
        SpawnMino("random");
        Falling();
        Controls();
        Hold();
    }


    private void InitializeBlocks()
    {
        // Definition of Tetromino types
        var x = 0;
        isFalling = true;
        activeSpawn = true;
        smoothFallCoroutine = false;
        _tetrominos.Add(new Tetromino
        {
            RGrid = new[,]
            {
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 0}
            },
            Id = x, Type = "I", IsActive = false,
            TetrominoGo = new GameObject("BlockI"),
            CubeGo = new GameObject[4, 4],
            Location = new float[] {spawnArea[0], spawnArea[1], spawnArea[2]},
            IsHold = false
        });
        x++;
        _tetrominos.Add(new Tetromino
        {
            RGrid = new[,]
            {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 0, 0}
            },
            Id = x, Type = "O", IsActive = false,
            TetrominoGo = new GameObject("BlockO"),
            CubeGo = new GameObject[4, 4],
            Location = new float[] {spawnArea[0], spawnArea[1], spawnArea[2]},
            IsHold = false
        });
        x++;
        _tetrominos.Add(new Tetromino
        {
            RGrid = new[,]
            {
                {0, 1, 1},
                {0, 1, 0},
                {0, 1, 0}
            },
            Id = x, Type = "J", IsActive = false,
            TetrominoGo = new GameObject("BlockJ"),
            CubeGo = new GameObject[3, 3],
            Location = new float[] {spawnArea[0], spawnArea[1], spawnArea[2]},
            IsHold = false
        });
        x++;
        _tetrominos.Add(new Tetromino
        {
            RGrid = new[,]
            {
                {0, 1, 0},
                {0, 1, 0},
                {0, 1, 1}
            },
            Id = x, Type = "L", IsActive = false,
            TetrominoGo = new GameObject("BlockL"),
            CubeGo = new GameObject[3, 3],
            Location = new float[] {spawnArea[0], spawnArea[1], spawnArea[2]},
            IsHold = false
        });
        x++;
        _tetrominos.Add(new Tetromino
        {
            RGrid = new[,]
            {
                {0, 1, 0},
                {0, 1, 1},
                {0, 0, 1}
            },
            Id = x, Type = "S", IsActive = false,
            TetrominoGo = new GameObject("BlockS"),
            CubeGo = new GameObject[3, 3],
            Location = new float[] {spawnArea[0], spawnArea[1], spawnArea[2]},
            IsHold = false
        });
        x++;
        _tetrominos.Add(new Tetromino
        {
            RGrid = new[,]
            {
                {0, 0, 1},
                {0, 1, 1},
                {0, 1, 0}
            },
            Id = x, Type = "Z", IsActive = false,
            TetrominoGo = new GameObject("BlockZ"),
            CubeGo = new GameObject[3, 3],
            Location = new float[] {spawnArea[0], spawnArea[1], spawnArea[2]},
            IsHold = false
        });
        x++;
        _tetrominos.Add(new Tetromino
        {
            RGrid = new[,]
            {
                {0, 1, 0},
                {0, 1, 1},
                {0, 1, 0}
            },
            Id = x, Type = "T", IsActive = false,
            TetrominoGo = new GameObject("BlockT"),
            CubeGo = new GameObject[3, 3],
            Location = new float[] {spawnArea[0], spawnArea[1], spawnArea[2]},
            IsHold = false
        });

        // Generating cubes for each Tetromino
        foreach (var block in _tetrominos)
            // x2 is the x address of the array
            for (var x2 = 0; x2 < 4; x2++)
                // y2 is the y address of the array
            for (var y2 = 0; y2 < 4; y2++)
                // Check if the block is 3x3 or 4x4 and don't do the generation out of bounds
                if ((x2 == 3) | (y2 == 3) && block.Type != "O" && block.Type != "I")
                {
                    //Debug.Log("Out of the array range, skipping block...");
                }
                else
                {
                    // Generating the cubes (checking if the addresses are 1 and generating corresponding cubes
                    if (block.RGrid[x2, y2] == 1)
                    {
                        block.CubeGo[x2, y2] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        block.CubeGo[x2, y2].name = block.Type;
                        block.RotationState = 0;
                        block.CubeGo[x2, y2].transform.position = new Vector3(x2, y2, 0);
                        // Color + Parent Block
                        var cubeRenderer = block.CubeGo[x2, y2].GetComponent<Renderer>();
                        if (block.Type == "I")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.cyan);
                            block.Color = Color.cyan;
                            block.CubeGo[x2, y2].transform.parent =
                                _tetrominos.Find(mino => mino.Type == "I").TetrominoGo.transform;
                        }
                        else if (block.Type == "O")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.yellow);
                            block.Color = Color.yellow;
                            block.CubeGo[x2, y2].transform.parent =
                                _tetrominos.Find(mino => mino.Type == "O").TetrominoGo.transform;
                        }
                        else if (block.Type == "J")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.blue);
                            block.Color = Color.blue;
                            block.CubeGo[x2, y2].transform.parent =
                                _tetrominos.Find(mino => mino.Type == "J").TetrominoGo.transform;
                        }
                        else if (block.Type == "L")
                        {
                            cubeRenderer.material.SetColor(Color1,
                                new Color(255f / 255f, 130f / 255f, 0f / 255f));
                            block.Color = new Color(255f / 255f, 130f / 255f, 0f / 255f);
                            block.CubeGo[x2, y2].transform.parent =
                                _tetrominos.Find(mino => mino.Type == "L").TetrominoGo.transform;
                        }
                        else if (block.Type == "S")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.green);
                            block.Color = Color.green;
                            block.CubeGo[x2, y2].transform.parent =
                                _tetrominos.Find(mino => mino.Type == "S").TetrominoGo.transform;
                        }
                        else if (block.Type == "Z")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.red);
                            block.Color = Color.red;
                            block.CubeGo[x2, y2].transform.parent =
                                _tetrominos.Find(mino => mino.Type == "Z").TetrominoGo.transform;
                        }
                        else if (block.Type == "T")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.magenta);
                            block.Color = Color.magenta;
                            block.CubeGo[x2, y2].transform.parent =
                                _tetrominos.Find(mino => mino.Type == "T").TetrominoGo.transform;
                        }
                    }
                }

        // Moving the Tetrominos to spawn location
        foreach (var block in _tetrominos)
            block.TetrominoGo.transform.position =
                new Vector3(block.Location[0], block.Location[1], block.Location[2]);
    }


    private bool CanMove(string direction)
    {
        move = true;
        foreach (var block in _tetrominos.Where(block => block.IsActive))
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
                    if (direction == "down")
                        if (Grid.PlayGrid[(int) block.Location[0] + x + 1, (int) block.Location[1] + newY - 3] == 1)
                            move = false;
                    if (direction == "left")
                        if (Grid.PlayGrid[(int) block.Location[0] + x,
                                (int) block.Location[1] + newY - 2] == 1)
                            move = false;
                    if (direction == "right")
                        if (Grid.PlayGrid[(int) block.Location[0] + x + 2,
                                (int) block.Location[1] + newY - 2] == 1)
                            move = false;
                }
        }

        if (move) return true;
        return false;
    }

    private bool CanSpawn()
    {
        spawn = true;
        //FINISH THIS ASAP
        foreach (var block in _tetrominos.Where(block => block.Type == "O"))
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

                    if (Grid.PlayGrid[4 + x + 1, 20 + newY - 2] == 1)
                    {
                        spawn = false;
                        Debug.Log(Grid.PlayGrid[4 + x + 1, 20 + newY - 2]);
                    }
                }
        }

        if (spawn) return true;
        return false;
    }


    private void SpawnMino(string type)
    {
        if ((activeSpawn || holdSpawn) && Grid._gameOver == false)
        {
            if (CanSpawn())
            {
                timeSpawn += Time.deltaTime;
                if (timeSpawn >= timeToSpawn)
                {
                    if (type == "random")
                    {
                        var rIndex = new Random().Next(randomType.Length);
                        _tetrominos.Find(mino => mino.Type == randomType[rIndex]).IsActive = true;
                        _tetrominos.Find(mino => mino.IsActive).TetrominoGo.transform.position = new Vector3(3, 17, 0);
                        foreach (var block in _tetrominos.Where(block => block.Type == randomType[rIndex]))
                            block.IsActive = true;
                    }
                    else
                    {
                        _tetrominos.Find(mino => mino.Type == type).IsActive = true;
                        _tetrominos.Find(mino => mino.IsActive).TetrominoGo.transform.position = new Vector3(3, 17, 0);
                        foreach (var block in _tetrominos.Where(block => block.Type == type)) ;
                    }

                    foreach (var block in _tetrominos.Where(block => block.IsActive))
                    {
                        block.AtSpawn = false;
                        if (block.Type == "I" || block.Type == "O")
                            block.Location = new[] {3.0f, 21.0f, 0.0f};
                        else
                            block.Location = new[] {3.0f, 20.0f, 0.0f};
                        if (holdSpawn)
                        {
                            block.IsHold = false;
                            Debug.Log("Clearing hold type");
                        }
                    }


                    activeSpawn = false;
                    holdSpawn = false;
                    isFalling = true;
                    timeFall = 0.0f;
                    timeAutoRepeat = 0.0f;
                    timeLock = 0.0f;
                    lockCounter = 0;
                    lockDeepestRow = 20;
                }
            }
            else
            {
                Grid.GameOver();
            }
        }
    }

    private void Falling()
    {
        timeFall += Time.deltaTime;
        if (timeFall >= timeToFall)
        {
            timeFall = 0.0f;

            if (isFalling && activeSpawn == false)
                foreach (var block in _tetrominos.Where(block => block.IsActive))
                    if (CanMove("down") == false && timeLock >= timeToLock ||
                        lockCounter >= 15 && CanMove("down") == false)
                    {
                        block.IsLocked = true;
                        block.IsActive = false;
                        isFalling = false;
                        activeSpawn = true;
                        timeLock = 0.0f;
                        holdUsed = false;
                    }
                    else if (CanMove("down"))
                    {
                        timeLock = 0.0f;
                        /*var position = block.TetrominoGo.transform.position;
                        //Debug.Log(position);
                        //Debug.Log(block.Location[0] + ", " + block.Location[1]);
                        if (smoothFallCoroutine == false)
                        {
                            StartCoroutine(smooth_move(0.05f, position, position + Vector3.down));
                            smoothFallCoroutine = true;
                            
                        }*/
                        block.TetrominoGo.transform.Translate(Vector3.down * 1, Space.World);
                        block.Location = new[] {block.Location[0], block.Location[1] - 1.0f, block.Location[2]};
                    }
        }
    }


    private void Controls()
    {
        timeAutoRepeat += Time.deltaTime;
        timeSoftDrop += Time.deltaTime;
        timeBeginAutoRepeat += Time.deltaTime;


        // Not able to Soft Drop or Hard Drop
        foreach (var block in _tetrominos.Where(block => block.IsActive))
        {
            if (CanMove("down") == false && activeSpawn == false)
            {
                timeLock += Time.deltaTime;
                if (timeLock >= timeToLock)
                {
                    block.IsLocked = true;
                    activeSpawn = true;
                    block.IsActive = false;
                    holdUsed = false;
                }
            }

            if (lockDeepestRow > (int) block.Location[1])
            {
                lockDeepestRow = (int) block.Location[1];
                lockCounter = 0;
            }
        }

        if (Input.GetKeyUp(keybindHardDrop) || Input.GetKeyDown(keybindHardDrop) || Input.GetKey(keybindLeft) ||
            Input.GetKey(keybindRight) || Input.GetKey(keybindSoftDrop) || Input.GetKeyUp(keybindSoftDrop) ||
            Input.GetKeyDown(keybindLeft) || Input.GetKeyDown(keybindRight) || Input.GetKeyDown(keybindSoftDrop))
            if (activeSpawn == false)
                foreach (var block in _tetrominos.Where(block => block.IsActive))
                {
                    // Hard Drop
                    if (Input.GetKeyDown(keybindHardDrop))
                        while (CanMove("down"))
                        {
                            isFalling = false;
                            block.TetrominoGo.transform.Translate(Vector3.down * 1, Space.World);
                            block.Location = new[] {block.Location[0], block.Location[1] - 1f, block.Location[2]};
                        }

                    // Falling disable
                    if (Input.GetKeyUp(keybindSoftDrop) || Input.GetKeyUp(keybindHardDrop) && CanMove("down"))
                    {
                        isFalling = true;
                        timeFall = 0.0f;
                    }

                    // Left Movement
                    if (Input.GetKeyDown(keybindLeft) && CanMove("left"))
                    {
                        block.TetrominoGo.transform.Translate(Vector3.left * 1, Space.World);
                        block.Location = new[] {block.Location[0] - 1f, block.Location[1], block.Location[2]};
                        timeLock = 0.0f;
                        lockCounter++;

                        if (Menu.IsPaused)
                            Debug.Log("lmao");
                    }
                    // Right Movement
                    else if (Input.GetKeyDown(keybindRight) && CanMove("right"))
                    {
                        block.TetrominoGo.transform.Translate(Vector3.right * 1, Space.World);
                        block.Location = new[] {block.Location[0] + 1f, block.Location[1], block.Location[2]};
                        timeLock = 0.0f;
                        lockCounter++;
                    }

                    // Auto Repeat direction control
                    if (Input.GetKeyUp(keybindLeft) && Input.GetKey(keybindRight))
                    {
                        lastDir = true;
                        timeBeginAutoRepeat = 0.0f;
                    }

                    if (Input.GetKeyUp(keybindRight) && Input.GetKey(keybindLeft))
                    {
                        lastDir = false;
                        timeBeginAutoRepeat = 0.0f;
                    }

                    if (Input.GetKeyDown(keybindLeft))
                    {
                        lastDir = false;
                        timeBeginAutoRepeat = 0.0f;
                    }

                    if (Input.GetKeyDown(keybindRight))
                    {
                        lastDir = true;
                        timeBeginAutoRepeat = 0.0f;
                    }

                    // Auto Repeat
                    if (timeAutoRepeat >= timeToAutoRepeat && timeBeginAutoRepeat >= timeToBeginAutoRepeat)
                    {
                        timeAutoRepeat = 0.0f;
                        if (Input.GetKey(keybindLeft) && CanMove("left") && lastDir == false)
                        {
                            block.TetrominoGo.transform.Translate(Vector3.left * 1, Space.World);
                            block.Location = new[] {block.Location[0] - 1f, block.Location[1], block.Location[2]};
                            timeLock = 0.0f;
                            lockCounter++;
                        }

                        if (Input.GetKey(keybindRight) && CanMove("right") && lastDir)
                        {
                            block.TetrominoGo.transform.Translate(Vector3.right * 1, Space.World);
                            block.Location = new[] {block.Location[0] + 1f, block.Location[1], block.Location[2]};
                            timeLock = 0.0f;
                            lockCounter++;
                        }
                    }

                    // Soft Drop
                    if (timeSoftDrop >= timeToSoftDrop)
                        if (Input.GetKey(keybindSoftDrop) && CanMove("down") && timeLock <= timeToLock)
                        {
                            isFalling = false;
                            timeLock = 0.0f;
                            timeFall = 0.0f;
                            timeSoftDrop = 0.0f;
                            block.TetrominoGo.transform.Translate(Vector3.down * 1, Space.World);
                            block.Location = new[] {block.Location[0], block.Location[1] - 1f, block.Location[2]};
                        }
                }
    }

    private void Hold()
    {
        if (holdUsed == false && Input.GetKeyDown(KeyCode.LeftShift))
        {
            foreach (var block in _tetrominos.Where(block => block.IsActive))
            {
                block.IsHold = true;
                block.IsActive = false;
                block.Location = new float[] {holdArea[0], holdArea[1], holdArea[2]};
                if (HoldBlock != null) DestroyImmediate(HoldBlock);

                block.TetrominoGo.transform.position = holdArea;
                while (block.RotationState != 0)
                {
                    block.AtSpawn = true;
                    Debug.Log("Attempting a rotation at spawn");
                    Rotation.Rotate("Ac", 0, 0);
                    block.RotationState -= 1;
                }

                HoldBlock = Instantiate(block.TetrominoGo);
                block.TetrominoGo.transform.position = spawnArea;

                if (block.RotationState == 0) block.AtSpawn = false;

                holdSpawn = true;

                Debug.Log(holdType);
                if (randomType.Contains(holdType))
                {
                    SpawnMino(holdType);
                }
                else
                {
                    SpawnMino("random");
                    Debug.Log("spawning random");
                }

                holdUsed = true;
                break;
            }

            holdType = _tetrominos.Find(block => block.IsHold).Type;
        }
    }


    /*IEnumerator smooth_move(float time, Vector3 startPos, Vector3 endPos)
    {
        float elapsedTime = 0;
        Debug.Log("Starting fall coroutine");
        foreach (var block in _tetrominos.Where(block => block.IsActive))
        {
            while (elapsedTime < time)
            {
                block.TetrominoGo.transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                Debug.Log(elapsedTime + ", " + time);

                smoothFallCoroutine = false;

                Debug.Log("Coroutine has concluded");

                yield return null;
            }
        }
    }*/
}