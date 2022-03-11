using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class Blocks : MonoBehaviour
{
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    public static bool IsFalling;
    public static bool ActiveSpawn;

    // Block with textures etc.
    //public GameObject blockPrefab;
    public Material blockWithTexture;

    public string[] randomType =
    {
        "I", "O", "J", "L", "S", "Z", "T"
    };

    // Gravity timer
    public float timeFall;
    public static float TimeToFall = 1f;
    public bool smoothFallCoroutine;

    // Auto repeat timer
    public float timeAutoRepeat;
    public float timeToAutoRepeat = 0.05f;

    // Lock timer
    public static float TimeLock;
    public float timeToLock = 0.5f;
    public static int LockCounter;
    public int lockDeepestRow;

    // Auto repeat delay timer
    public float timeBeginAutoRepeat;
    public float timeToBeginAutoRepeat = 0.3f;
    public bool lastDir;

    // Soft drop timer
    public float timeSoftDrop;
    public float timeToSoftDrop = 0.025f;

    // Spawn 
    public float timeSpawn;
    public float timeToSpawn = 0.375f;
    public static GameObject PreviewBlock;


    // Hold
    public static string HoldType;
    public bool holdUsed;
    public bool holdSpawn;
    public static GameObject HoldBlock;

    // Offsets
    public bool move;
    public bool spawn;

    // Keybindings
    public string keybindRight = "right";
    public string keybindLeft = "left";
    public string keybindSoftDrop = "down";
    public string keybindHardDrop = "space";

    // Random type
    public int rIndex;

    // Colors

    // Coroutines
    public bool lineClearCoroutine;

    // Spawn coordinates
    public static Vector3 SpawnArea = new Vector3(3, 30, 0);

    // Start are coordinates
    public Vector3 startArea = new Vector3(3, 17, 0);
    public Vector3 previewArea = new Vector3(-6, 17, 0);

    // Holding area coordinates
    public Vector3 holdArea = new Vector3(13, 17, 0);

    //List<Tetromino> tetrominos = new List<Tetromino>();
    public static readonly List<Tetromino> Tetrominos = new List<Tetromino>();


    //public int[] debug { get; set; }


    // Start is called before the first frame update
    private void Start()
    {
        InitializeBlocks();
    }


// Update is called once per frame
    private void Update()
    {
        if (!Menu.Menus[0].IsPaused && !Menu.Menus[2].IsPaused)
        {
            SpawnMino("random");
            Falling();
            Controls();
            Hold();
        }
    }


    private void InitializeBlocks()
    {
        // Definition of Tetromino types
        var x = 0;
        IsFalling = true;
        ActiveSpawn = true;
        smoothFallCoroutine = false;
        rIndex = new Random().Next(randomType.Length);
        Tetrominos.Add(new Tetromino
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
            Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
            IsHold = false
        });
        x++;
        Tetrominos.Add(new Tetromino
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
            Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
            IsHold = false
        });
        x++;
        Tetrominos.Add(new Tetromino
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
            Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
            IsHold = false
        });
        x++;
        Tetrominos.Add(new Tetromino
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
            Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
            IsHold = false
        });
        x++;
        Tetrominos.Add(new Tetromino
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
            Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
            IsHold = false
        });
        x++;
        Tetrominos.Add(new Tetromino
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
            Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
            IsHold = false
        });
        x++;
        Tetrominos.Add(new Tetromino
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
            Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
            IsHold = false
        });

        // Generating cubes for each Tetromino
        foreach (var block in Tetrominos)
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
                        cubeRenderer.material = blockWithTexture;
                        if (block.Type == "I")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.cyan);
                            block.Color = Color.cyan;
                            block.CubeGo[x2, y2].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "I").TetrominoGo.transform;
                        }
                        else if (block.Type == "O")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.yellow);
                            block.Color = Color.yellow;
                            block.CubeGo[x2, y2].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "O").TetrominoGo.transform;
                        }
                        else if (block.Type == "J")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.blue);
                            block.Color = Color.blue;
                            block.CubeGo[x2, y2].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "J").TetrominoGo.transform;
                        }
                        else if (block.Type == "L")
                        {
                            cubeRenderer.material.SetColor(Color1,
                                new Color(255f / 255f, 130f / 255f, 0f / 255f));
                            block.Color = new Color(255f / 255f, 130f / 255f, 0f / 255f);
                            block.CubeGo[x2, y2].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "L").TetrominoGo.transform;
                        }
                        else if (block.Type == "S")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.green);
                            block.Color = Color.green;
                            block.CubeGo[x2, y2].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "S").TetrominoGo.transform;
                        }
                        else if (block.Type == "Z")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.red);
                            block.Color = Color.red;
                            block.CubeGo[x2, y2].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "Z").TetrominoGo.transform;
                        }
                        else if (block.Type == "T")
                        {
                            cubeRenderer.material.SetColor(Color1, Color.magenta);
                            block.Color = Color.magenta;
                            block.CubeGo[x2, y2].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "T").TetrominoGo.transform;
                        }
                    }
                }

        // Moving the Tetrominos to spawn location
        foreach (var block in Tetrominos)
            block.TetrominoGo.transform.position =
                new Vector3(block.Location[0], block.Location[1], block.Location[2]);

        SpawnMino("random");
    }


    private bool CanMove(string direction)
    {
        move = true;
        foreach (var block in Tetrominos.Where(block => block.IsActive))
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
                        if (TileMap.PlayGrid[(int) block.Location[0] + x + 1, (int) block.Location[1] + newY - 3] == 1)
                            move = false;
                    if (direction == "left")
                        if (TileMap.PlayGrid[(int) block.Location[0] + x,
                                (int) block.Location[1] + newY - 2] == 1)
                            move = false;
                    if (direction == "right")
                        if (TileMap.PlayGrid[(int) block.Location[0] + x + 2,
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
        foreach (var block in Tetrominos.Where(block => block.Type == "O"))
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

                    if (TileMap.PlayGrid != null && TileMap.PlayGrid[4 + x + 1, 20 + newY - 2] == 1)
                    {
                        spawn = false;
                        Debug.Log(TileMap.PlayGrid[4 + x + 1, 20 + newY - 2]);
                    }
                }
        }

        if (spawn) return true;
        return false;
    }

    private void Preview()
    {
        PreviewBlock = Instantiate(Tetrominos.Find(mino => mino.Type == randomType[rIndex]).TetrominoGo);
        PreviewBlock.name = "Preview block";
        PreviewBlock.transform.position = previewArea;
    }

    private void SpawnMino(string type)
    {
        if ((ActiveSpawn || holdSpawn) && TileMap.IsGameOver == false)
        {
            if (CanSpawn())
            {
                timeSpawn += Time.deltaTime;
                if (timeSpawn >= timeToSpawn)
                {
                    ScoreSystem.ScoreCounter();
                    if (type == "random")
                    {
                        Tetrominos.Find(mino => mino.Type == randomType[rIndex]).IsActive = true;
                        Tetrominos.Find(mino => mino.IsActive).TetrominoGo.transform.position = new Vector3(3, 17, 0);
                        foreach (var block in Tetrominos.Where(block => block.Type == randomType[rIndex]))
                            block.IsActive = true;
                    }
                    else
                    {
                        Tetrominos.Find(mino => mino.Type == type).IsActive = true;
                        Tetrominos.Find(mino => mino.IsActive).TetrominoGo.transform.position = new Vector3(3, 17, 0);
                        foreach (var block in Tetrominos.Where(block => block.Type == type))
                            block.IsActive = true;
                    }

                    foreach (var block in Tetrominos.Where(block => block.IsActive))
                    {
                        block.AtSpawn = false;
                        if (block.Type == "I" || block.Type == "O")
                            block.Location = new[] {3.0f, 21.0f, 0.0f};
                        else
                            block.Location = new[] {3.0f, 20.0f, 0.0f};
                        if (holdSpawn)
                        {
                            block.IsHold = false;
                        }
                    }

                    if (holdSpawn == false)
                        rIndex = new Random().Next(randomType.Length);
                    DestroyImmediate(PreviewBlock);
                    Preview();
                    ActiveSpawn = false;
                    holdSpawn = false;
                    IsFalling = true;
                    timeFall = 0.0f;
                    timeAutoRepeat = 0.0f;
                    TimeLock = 0.0f;
                    LockCounter = 0;
                    lockDeepestRow = 20;
                }
            }
            else
            {
                TileMap.GameOver(true);
            }
        }
    }

    private void Falling()
    {
        timeFall += Time.deltaTime;
        if (timeFall >= TimeToFall)
        {
            timeFall = 0.0f;

            if (IsFalling && ActiveSpawn == false)
                foreach (var block in Tetrominos.Where(block => block.IsActive))
                    if (CanMove("down") == false && TimeLock >= timeToLock ||
                        LockCounter >= 15 && CanMove("down") == false)
                    {
                        block.IsLocked = true;
                        block.IsActive = false;
                        IsFalling = false;
                        ActiveSpawn = true;
                        TimeLock = 0.0f;
                        holdUsed = false;
                    }
                    else if (CanMove("down"))
                    {
                        TimeLock = 0.0f;
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
        foreach (var block in Tetrominos.Where(block => block.IsActive))
        {
            if (CanMove("down") == false && ActiveSpawn == false)
            {
                TimeLock += Time.deltaTime;
                if (TimeLock >= timeToLock)
                {
                    block.IsLocked = true;
                    ActiveSpawn = true;
                    block.IsActive = false;
                    holdUsed = false;
                    TimeLock = 0.0f;
                }
            }

            if (lockDeepestRow > (int) block.Location[1])
            {
                lockDeepestRow = (int) block.Location[1];
                LockCounter = 0;
            }
        }

        if (Input.GetKeyUp(keybindHardDrop) || Input.GetKeyDown(keybindHardDrop) || Input.GetKey(keybindLeft) ||
            Input.GetKey(keybindRight) || Input.GetKey(keybindSoftDrop) || Input.GetKeyUp(keybindSoftDrop) ||
            Input.GetKeyDown(keybindLeft) || Input.GetKeyDown(keybindRight) || Input.GetKeyDown(keybindSoftDrop))
            if (ActiveSpawn == false)
                foreach (var block in Tetrominos.Where(block => block.IsActive))
                {
                    // Hard Drop
                    if (Input.GetKeyDown(keybindHardDrop))
                        while (CanMove("down"))
                        {
                            IsFalling = false;
                            TimeLock = timeToLock - 0.0001f;
                            block.TetrominoGo.transform.Translate(Vector3.down * 1, Space.World);
                            block.Location = new[] {block.Location[0], block.Location[1] - 1f, block.Location[2]};
                            // Adding two score points per line for hard dropping
                            ScoreSystem.Score += 2;
                            ScoreSystem.IsTSpinLastMove = 0;
                        }

                    // Soft Drop
                    if (timeSoftDrop >= timeToSoftDrop)
                        if (Input.GetKey(keybindSoftDrop) && CanMove("down") && TimeLock <= timeToLock)
                        {
                            IsFalling = false;
                            TimeLock = 0.0f;
                            timeFall = 0.0f;
                            timeSoftDrop = 0.0f;
                            block.TetrominoGo.transform.Translate(Vector3.down * 1, Space.World);
                            block.Location = new[] {block.Location[0], block.Location[1] - 1f, block.Location[2]};
                            // Adding one score point per line for soft dropping
                            ScoreSystem.Score += 1;
                            ScoreSystem.IsTSpinLastMove = 0;
                        }

                    // Falling disable for Soft Drop and Hard Drop
                    if (Input.GetKeyUp(keybindSoftDrop) || Input.GetKeyUp(keybindHardDrop) && CanMove("down"))
                    {
                        IsFalling = true;
                        timeFall = 0.0f;
                    }

                    // Left Movement
                    if (Input.GetKeyDown(keybindLeft) && CanMove("left"))
                    {
                        block.TetrominoGo.transform.Translate(Vector3.left * 1, Space.World);
                        block.Location = new[] {block.Location[0] - 1f, block.Location[1], block.Location[2]};
                        ScoreSystem.IsTSpinLastMove = 0;
                        TimeLock = 0.0f;
                        LockCounter++;
                    }
                    // Right Movement
                    else if (Input.GetKeyDown(keybindRight) && CanMove("right"))
                    {
                        block.TetrominoGo.transform.Translate(Vector3.right * 1, Space.World);
                        block.Location = new[] {block.Location[0] + 1f, block.Location[1], block.Location[2]};
                        ScoreSystem.IsTSpinLastMove = 0;
                        TimeLock = 0.0f;
                        LockCounter++;
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
                            ScoreSystem.IsTSpinLastMove = 0;
                            TimeLock = 0.0f;
                            LockCounter++;
                        }

                        if (Input.GetKey(keybindRight) && CanMove("right") && lastDir)
                        {
                            block.TetrominoGo.transform.Translate(Vector3.right * 1, Space.World);
                            block.Location = new[] {block.Location[0] + 1f, block.Location[1], block.Location[2]};
                            ScoreSystem.IsTSpinLastMove = 0;
                            TimeLock = 0.0f;
                            LockCounter++;
                        }
                    }
                }
    }

    private void Hold()
    {
        if (holdUsed == false && Input.GetKeyDown(KeyCode.LeftShift))
        {
            foreach (var block in Tetrominos.Where(block => block.IsActive))
            {
                block.IsHold = true;
                block.IsActive = false;
                block.Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]};
                if (HoldBlock != null) DestroyImmediate(HoldBlock);

                block.TetrominoGo.transform.position = SpawnArea;
                while (block.RotationState != 0)
                {
                    block.AtSpawn = true;
                    Rotation.Rotate("Ac", 0, 0);
                    block.RotationState -= 1;
                }

                HoldBlock = Instantiate(block.TetrominoGo);
                HoldBlock.transform.position = holdArea;

                if (block.RotationState == 0) block.AtSpawn = false;

                holdSpawn = true;
                
                if (randomType.Contains(HoldType))
                {
                    SpawnMino(HoldType);
                }
                else
                {
                    SpawnMino("random");
                }

                holdUsed = true;
                break;
            }

            if (Tetrominos.Exists(block => block.IsHold))
                HoldType = Tetrominos.Find(block => block.IsHold).Type;
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