using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace Tetris
{
    /// <summary>
    ///     Manages all block and their movement
    /// </summary>
    public class Blocks : MonoBehaviour
    {
        /// <summary>
        ///     Cached property id for changing colors in <see cref="InitializeBlocks" />
        /// </summary>
        private static readonly int ColorId = Shader.PropertyToID("_Color");

        /// <summary>
        ///     List for IsFalling bool, false when soft dropping
        /// </summary>
        public static readonly List<bool> IsFalling = new List<bool>();

        /// <summary>
        ///     List for ActiveSpawn bool, a request for <see cref="SpawnMino" />
        /// </summary>
        public static readonly List<bool> ActiveSpawn = new List<bool>();

        /// <summary>
        ///     Time for a block to fall one block down
        /// </summary>
        public static float TimeToFall = 1f;

        // Lock timer
        /// <summary>
        ///     Lock timers for <see cref="Controls" /> and <see cref="Falling" />
        /// </summary>
        public static List<float> TimeLock = new List<float>();

        /// <summary>
        ///     Counter of how many rotations/moves happened when the lock conditions are met and <see cref="TimeLock" /> was
        ///     running
        /// </summary>
        /// <remarks>
        ///     After reaching 15, block locks immediately after a rotation or a move
        /// </remarks>
        public static List<int> LockCounter = new List<int>();

        /// <summary>
        ///     Time for a block to fall when soft drop key is held down
        /// </summary>
        public static float TimeToSoftDrop = TimeToFall / 20f;

        // Spawn 
        /// <summary>
        ///     List for PreviewBlock GameObject
        ///     Stores block for <see cref="Preview" />
        /// </summary>
        public static List<GameObject> PreviewBlock = new List<GameObject>();

        // Hold
        /// <summary>
        ///     Array for HoldType strings
        /// </summary>
        public static readonly string[] HoldType = new string[10];

        /// <summary>
        ///     List for HoldBlock GameObjects
        /// </summary>
        public static readonly List<GameObject> HoldBlock = new List<GameObject>();

        public static string[] KeybindRight = {"right", "[6]", "[6]"};
        public static string[] KeybindLeft = {"left", "[4]", "[4]"};
        public static string[] KeybindSoftDrop = {"down", "[5]", "[5]"};
        public static string[] KeybindHardDrop = {"space", "[0]", "[0]"};
        public static string[] KeybindHold = {"left shift", "[+]", "[+]"};

        // Multiplayer
        /// <summary>
        ///     List of player ids, used to get player count
        /// </summary>
        public static List<int> PlayerIds = new List<int>();

        // Spawn coordinates
        /// <summary>
        ///     Coordinates for area above the game space where all blocks remain when not in use
        /// </summary>
        /// <value>
        ///     x, y, z
        /// </value>
        public static Vector3 SpawnArea = new Vector3(3, 30, 0);

        // Start area
        /// <summary>
        ///     Coordinates for area where each player starts
        /// </summary>
        /// <value>
        ///     x, y, z
        /// </value>
        public static List<Vector3> StartArea = new List<Vector3>();

        // Preview area
        /// <summary>
        ///     Coordinates for area where each player has it's next prepared block
        /// </summary>
        /// <value>
        ///     x, y, z
        /// </value>
        public static List<Vector3> PreviewArea = new List<Vector3>();

        // Holding area
        /// <summary>
        ///     Coordinates for area where each player have it's held block, if such a block exists
        /// </summary>
        public static List<Vector3> HoldArea = new List<Vector3>();

        /// <summary>
        ///     List of all blocks
        /// </summary>
        /// <remarks>
        ///     Each player has one of each type, locked blocks don't exist in this list
        /// </remarks>
        public static readonly List<Tetromino> Tetrominos = new List<Tetromino>();


        /// <summary>
        ///     Gets a Unity prefab for a cube with pre-applied material etc.
        /// </summary>
        public GameObject blockPrefab;

        /// <summary>
        ///     Array of block types used in <see cref="SpawnMino" />
        /// </summary>
        public string[] randomType =
        {
            "I", "O", "J", "L", "S", "Z", "T"
        };

        /// <summary>
        ///     Timers for <see cref="Falling" />
        /// </summary>
        // Gravity timer
        public List<float> timeFall = new List<float>();

        // Auto repeat timer{
        /// <summary>
        ///     Auto-repeat timers for <see cref="Controls" />
        /// </summary>
        public List<float> timeAutoRepeat = new List<float>();

        /// <summary>
        ///     Time for a block to move to side when auto-repeat is active
        /// </summary>
        public float timeToAutoRepeat = 0.05f;

        /// <summary>
        ///     Time for a block to lock in place
        /// </summary>
        public float timeToLock = 0.5f;

        /// <summary>
        ///     Deepest row reached by currently active block
        /// </summary>
        /// <remarks>
        ///     The <see cref="LockCounter" /> resets if the block reaches a new deepest floor
        /// </remarks>
        public List<int> lockDeepestRow = new List<int>();

        // Auto repeat delay timer
        /// <summary>
        ///     List for timeBeginAutoRepeat float
        /// </summary>
        public List<float> timeBeginAutoRepeat = new List<float>();

        /// <summary>
        ///     Time for a block to begin auto-repeat after a direction key is held
        /// </summary>
        public float timeToBeginAutoRepeat = 0.3f;

        /// <summary>
        ///     List for LastDir Bool, describes direction for auto-repeat
        /// </summary>
        public List<bool> lastDir = new List<bool>();

        // Soft drop timer
        /// <summary>
        ///     Soft drop timers for <see cref="Controls" />
        /// </summary>
        public List<float> timeSoftDrop = new List<float>();

        /// <summary>
        ///     List for holdUsed bool
        /// </summary>
        public static List<bool> HoldUsed = new List<bool>();

        /// <summary>
        ///     List for holdSpawn bool
        /// </summary>
        public List<bool> holdSpawn = new List<bool>();

        // Offsets
        /// <summary>
        ///     Used for <see cref="CanMove" />
        /// </summary>
        public bool move;

        /// <summary>
        ///     Used for <see cref="CanSpawn" />
        /// </summary>
        public bool spawn;

        // Random type
        /// <summary>
        ///     Random integer for picking from <see cref="randomType" />
        /// </summary>
        public List<int> rIndex = new List<int>();

        //Multiplayer

        public Material otherMat;

        private Color _playerColor;
        private Random rnd = new Random();


        // Start is called before the first frame update
        private void Awake()
        {
            InitializePlayer(0);
        }


        // Update is called once per frame
        private void Update()
        {
            if (Menu.NeedToAddPlayer)
            {
                Menu.NeedToAddPlayer = false;
                InitializePlayer(PlayerIds.Count);
            }

            if (Menu.NeedToRemovePlayer)
            {
                Menu.NeedToRemovePlayer = false;
                RemovePlayer(PlayerIds.Count - 1);
            }

            if (!Menu.Menus[0].IsPaused && !Menu.Menus[1].IsPaused && !Menu.Menus[2].IsPaused)
            {
                for (int playerId = 0; playerId < PlayerIds.Count; playerId++)
                    SpawnMino(playerId, "random");
                Falling();
                Controls();
                Hold();
            }
        }

        /// <summary>
        ///     Initializes all variables needed for given player
        /// </summary>
        /// <param name="playerId">Player id</param>
        public void InitializePlayer(int playerId)
        {
            // Movement and location variables
            PlayerIds.Add(playerId);
            StartArea.Add(new Vector3(3 + 10 * playerId, 17, 0));
            PreviewArea.Add(new Vector3(-6, 17 - 5 * playerId, 0));
            HoldArea.Add(new Vector3(TileMap.GridWidth + 1, 17 - 5 * playerId, 0));
            IsFalling.Add(new bool());
            ActiveSpawn.Add(new bool());
            timeFall.Add(new float());
            timeAutoRepeat.Add(new float());
            TimeLock.Add(new float());
            lastDir.Add(new bool());
            LockCounter.Add(new int());
            lockDeepestRow.Add(new int());
            timeBeginAutoRepeat.Add(new float());
            timeSoftDrop.Add(new float());
            HoldUsed.Add(new bool());
            holdSpawn.Add(new bool());
            PreviewBlock.Add(new GameObject());
            HoldBlock.Add(new GameObject());
            rIndex.Add(new int());
            // Rotation variables
            Rotation.FutureRotationAc.Add(new int());
            Rotation.FutureRotationC.Add(new int());
            // Tetriminos
            InitializeBlocks(playerId);
        }

        /// <summary>
        ///     Removes all variables needed for given player
        /// </summary>
        /// <param name="playerId">Player id</param>
        public void RemovePlayer(int playerId)
        {
            // Movement and location variables
            PlayerIds.RemoveAt(playerId);
            StartArea.RemoveAt(playerId);
            PreviewArea.RemoveAt(playerId);
            HoldArea.RemoveAt(playerId);
            IsFalling.RemoveAt(playerId);
            ActiveSpawn.RemoveAt(playerId);
            timeFall.RemoveAt(playerId);
            timeAutoRepeat.RemoveAt(playerId);
            TimeLock.RemoveAt(playerId);
            lastDir.RemoveAt(playerId);
            LockCounter.RemoveAt(playerId);
            lockDeepestRow.RemoveAt(playerId);
            timeBeginAutoRepeat.RemoveAt(playerId);
            timeSoftDrop.RemoveAt(playerId);
            HoldUsed.RemoveAt(playerId);
            holdSpawn.RemoveAt(playerId);
            PreviewBlock.RemoveAt(playerId);
            HoldBlock.RemoveAt(playerId);
            rIndex.RemoveAt(playerId);
            // Rotation variables
            Rotation.FutureRotationAc.RemoveAt(playerId);
            Rotation.FutureRotationC.RemoveAt(playerId);
            // Tetriminos
            Tetrominos.RemoveRange(Tetrominos.Count - 7, 7);
        }

        /// <summary>
        ///     Initializes blocks and their variables for given player
        /// </summary>
        /// <param name="playerId">Player id</param>
        private void InitializeBlocks(int playerId)
        {
            // Definition of Tetromino types
            IsFalling[playerId] = true;
            ActiveSpawn[playerId] = true;
            rIndex[playerId] = rnd.Next(randomType.Length);
            Tetrominos.Add(new Tetromino
            {
                RGrid = new[,]
                {
                    {0, 0, 1, 0},
                    {0, 0, 1, 0},
                    {0, 0, 1, 0},
                    {0, 0, 1, 0}
                },
                Id = playerId, Type = "I", IsActive = false,
                TetrominoGo = new GameObject("Block I " + playerId),
                CubeGo = new GameObject[4, 4],
                Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
                IsHold = false, Size = 4
            });
            Tetrominos.Add(new Tetromino
            {
                RGrid = new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 1, 0},
                    {0, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                Id = playerId, Type = "O", IsActive = false,
                TetrominoGo = new GameObject("Block O " + playerId),
                CubeGo = new GameObject[4, 4],
                Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
                IsHold = false, Size = 4
            });
            Tetrominos.Add(new Tetromino
            {
                RGrid = new[,]
                {
                    {0, 1, 1},
                    {0, 1, 0},
                    {0, 1, 0}
                },
                Id = playerId, Type = "J", IsActive = false,
                TetrominoGo = new GameObject("Block J " + playerId),
                CubeGo = new GameObject[3, 3],
                Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
                IsHold = false, Size = 3
            });
            Tetrominos.Add(new Tetromino
            {
                RGrid = new[,]
                {
                    {0, 1, 0},
                    {0, 1, 0},
                    {0, 1, 1}
                },
                Id = playerId, Type = "L", IsActive = false,
                TetrominoGo = new GameObject("Block L " + playerId),
                CubeGo = new GameObject[3, 3],
                Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
                IsHold = false, Size = 3
            });
            Tetrominos.Add(new Tetromino
            {
                RGrid = new[,]
                {
                    {0, 1, 0},
                    {0, 1, 1},
                    {0, 0, 1}
                },
                Id = playerId, Type = "S", IsActive = false,
                TetrominoGo = new GameObject("Block S " + playerId),
                CubeGo = new GameObject[3, 3],
                Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
                IsHold = false, Size = 3
            });
            Tetrominos.Add(new Tetromino
            {
                RGrid = new[,]
                {
                    {0, 0, 1},
                    {0, 1, 1},
                    {0, 1, 0}
                },
                Id = playerId, Type = "Z", IsActive = false,
                TetrominoGo = new GameObject("Block Z " + playerId),
                CubeGo = new GameObject[3, 3],
                Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
                IsHold = false, Size = 3
            });
            Tetrominos.Add(new Tetromino
            {
                RGrid = new[,]
                {
                    {0, 1, 0},
                    {0, 1, 1},
                    {0, 1, 0}
                },
                Id = playerId, Type = "T", IsActive = false,
                TetrominoGo = new GameObject("Block T " + playerId),
                CubeGo = new GameObject[3, 3],
                Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]},
                IsHold = false, Size = 3
            });

            // Generating cubes for each Tetromino
            foreach (var block in Tetrominos.Where(block => block.Id == playerId))
            {
                // x2 is the x address of the array
                for (var x = 0; x < block.Size; x++)
                for (var y = 0; y < block.Size; y++)
                    if (block.RGrid[x, y] == 1)
                    {
                        block.CubeGo[x, y] = Instantiate(blockPrefab);
                        block.CubeGo[x, y].name = block.Type;
                        block.RotationState = 0;
                        block.CubeGo[x, y].transform.position = new Vector3(x, y, 0);
                        // Color + Parent Block
                        var cubeRenderer = block.CubeGo[x, y].GetComponent<Renderer>();

                        if (playerId == 1)
                        {
                            _playerColor = Color.red;
                        }
                        else if (playerId == 2)
                        {
                            _playerColor = Color.green;
                        }

                        if (block.Type == "I")
                        {
                            cubeRenderer.material.SetColor(ColorId, _playerColor);
                            block.Color = _playerColor;
                            block.CubeGo[x, y].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "I" && mino.Id == playerId).TetrominoGo
                                    .transform;
                        }
                        else if (block.Type == "O")
                        {
                            cubeRenderer.material.SetColor(ColorId, _playerColor);
                            block.Color = _playerColor;
                            block.CubeGo[x, y].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "O" && mino.Id == playerId).TetrominoGo
                                    .transform;
                        }
                        else if (block.Type == "J")
                        {
                            cubeRenderer.material.SetColor(ColorId, _playerColor);
                            block.Color = _playerColor;
                            block.CubeGo[x, y].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "J" && mino.Id == playerId).TetrominoGo
                                    .transform;
                        }
                        else if (block.Type == "L")
                        {
                            cubeRenderer.material.SetColor(ColorId, _playerColor);
                            block.Color = _playerColor;
                            block.CubeGo[x, y].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "L" && mino.Id == playerId).TetrominoGo
                                    .transform;
                        }
                        else if (block.Type == "S")
                        {
                            cubeRenderer.material.SetColor(ColorId, _playerColor);
                            block.Color = _playerColor;
                            block.CubeGo[x, y].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "S" && mino.Id == playerId).TetrominoGo
                                    .transform;
                        }
                        else if (block.Type == "Z")
                        {
                            cubeRenderer.material.SetColor(ColorId, _playerColor);
                            block.Color = _playerColor;
                            block.CubeGo[x, y].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "Z" && mino.Id == playerId).TetrominoGo
                                    .transform;
                        }
                        else if (block.Type == "T")
                        {
                            cubeRenderer.material.SetColor(ColorId, _playerColor);
                            block.Color = _playerColor;
                            block.CubeGo[x, y].transform.parent =
                                Tetrominos.Find(mino => mino.Type == "T" && mino.Id == playerId).TetrominoGo
                                    .transform;
                        }
                    }
            }

            if (playerId == 0)
                OriginalColors(0);

            // Moving the Tetrominos to spawn location
            foreach (var block in Tetrominos.Where(block => block.Id == playerId))
                block.TetrominoGo.transform.position =
                    new Vector3(block.Location[0], block.Location[1], block.Location[2]);
            SpawnMino(playerId, "random");
        }

        public static void OriginalColors(int playerId)
        {
            foreach (var block in Tetrominos.Where(block => block.Id == playerId))
            {
                for (var x = 0; x < block.Size; x++)
                for (var y = 0; y < block.Size; y++)
                {
                    if (block.RGrid[x, y] == 1)
                    {
                        var cubeRenderer = block.CubeGo[x, y].GetComponent<Renderer>();
                        if (block.Type == "I")
                        {
                            cubeRenderer.material.SetColor(ColorId, Color.cyan);
                            block.Color = Color.cyan;
                        }
                        else if (block.Type == "O")
                        {
                            cubeRenderer.material.SetColor(ColorId, Color.yellow);
                            block.Color = Color.yellow;
                        }
                        else if (block.Type == "J")
                        {
                            cubeRenderer.material.SetColor(ColorId, Color.blue);
                            block.Color = Color.blue;
                        }
                        else if (block.Type == "L")
                        {
                            cubeRenderer.material.SetColor(ColorId, new Color(255f / 255f, 130f / 255f, 0f / 255f));
                            block.Color = new Color(255f / 255f, 130f / 255f, 0f / 255f);
                        }
                        else if (block.Type == "S")
                        {
                            cubeRenderer.material.SetColor(ColorId, Color.green);
                            block.Color = Color.green;
                        }
                        else if (block.Type == "Z")
                        {
                            cubeRenderer.material.SetColor(ColorId, Color.red);
                            block.Color = Color.red;
                        }
                        else if (block.Type == "T")
                        {
                            cubeRenderer.material.SetColor(ColorId, Color.magenta);
                            block.Color = Color.magenta;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Checks if a player's block can move in a given direction without colliding with a wall
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="direction">right, left or down</param>
        /// <returns>bool</returns>
        private bool CanMove(int playerId, string direction)
        {
            move = true;
            foreach (var block in Tetrominos.Where(block => block.IsActive && block.Id == playerId))
            {
                for (var x = 0; x < block.Size; x++)
                for (var y = 0; y < block.Size; y++)
                    if (block.RGrid[x, y] == 1)
                    {
                        int newY;
                        if (block.Size == 4)
                            newY = y - 1;
                        else
                            newY = y;
                        if (direction == "down")
                            if (TileMap.PlayGrid[(int) block.Location[0] + x + 1, (int) block.Location[1] + newY - 3] ==
                                1)
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

        /// <summary>
        ///     Check if a player's block can move in a given direction without colliding with an other block
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="direction">right, left or down</param>
        /// <returns>bool</returns>
        private bool CanMoveToPlayer(int playerId, string direction)
        {
            foreach (var block in Tetrominos.Where(block => block.IsActive && block.Id != playerId))
            {
                for (int sizeX = 0; sizeX < block.Size; sizeX++)
                {
                    for (int sizeY = 0; sizeY < block.Size; sizeY++)
                    {
                        if (block.RGrid[sizeX, sizeY] == 1)
                        {
                            TileMap.MovementTileMap.CollisionMap[sizeX + (int) block.Location[0],
                                (int) block.Location[1] + sizeY - block.Size] = true;
                        }
                    }
                }
            }

            move = true;
            foreach (var block in Tetrominos.Where(block => block.IsActive && block.Id == playerId))
            {
                for (var player = 0; player < PlayerIds.Count; player++)
                {
                    if (player != playerId)
                    {
                        for (var x = 0; x < block.Size; x++)
                        for (var y = 0; y < block.Size; y++)
                            if (block.RGrid[x, y] == 1)
                            {
                                if (direction == "down")
                                {
                                    if (TileMap.MovementTileMap.CollisionMap[x + (int) block.Location[0],
                                            (int) block.Location[1] - 1 + y - block.Size])
                                    {
                                        move = false;
                                    }
                                }

                                if (direction == "left")
                                {
                                    if (TileMap.MovementTileMap.CollisionMap[x + (int) block.Location[0] - 1,
                                            (int) block.Location[1] + y - block.Size])
                                    {
                                        move = false;
                                    }
                                }

                                if (direction == "right")
                                {
                                    if (TileMap.MovementTileMap.CollisionMap[x + (int) block.Location[0] + 1,
                                            (int) block.Location[1] + y - block.Size])
                                    {
                                        move = false;
                                    }
                                }
                            }
                    }
                }
            }
            TileMap.ClearCollisionMap();
            if (move) return true;
            return false;
        }

        /// <summary>
        ///     Checks if player's <see cref="StartArea" /> are occupied by locked blocks
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="type">Block type</param>
        /// <returns>bool</returns>
        private bool CanSpawn(int playerId, string type)
        {
            spawn = true;
            if (type == "random")
                type = randomType[rIndex[playerId]];
            foreach (var block in Tetrominos.Where(block => block.Type == type && block.Id == playerId))
            {
                for (var x = 0; x < block.Size; x++)
                for (var y = 0; y < block.Size; y++)
                    if (block.RGrid[x, y] == 1)
                        if (TileMap.PlayGrid != null && TileMap.PlayGrid[(int)StartArea[playerId][0] + x + 1, (int)StartArea[playerId][1] + y + 1] == 1)
                            spawn = false;
            }

            if (spawn) return true;
            return false;
        }

        private void Preview(int playerId)
        {
            PreviewBlock[playerId] =
                Instantiate(Tetrominos.Find(mino => mino.Type == randomType[rIndex[playerId]] && mino.Id == playerId)
                    .TetrominoGo);
            PreviewBlock[playerId].name = "Preview block " + playerId;
            PreviewBlock[playerId].transform.position = PreviewArea[playerId];
        }

        /// <summary>
        ///     Spawns a block
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="type">Type of a block</param>
        protected void SpawnMino(int playerId, string type)
        {
            if ((ActiveSpawn[playerId] || holdSpawn[playerId]) && TileMap.IsGameOver == false)
            {
                if (CanSpawn(playerId, type))
                {
                    // timeSpawn += Time.deltaTime;
                    // if (timeSpawn >= timeToSpawn)
                    {
                        ScoreSystem.ScoreCounter();
                        if (type == "random")
                        {
                            Tetrominos.Find(mino => mino.Type == randomType[rIndex[playerId]] && mino.Id == playerId).IsActive =
                                true;
                            Tetrominos.Find(mino => mino.IsActive && mino.Id == playerId).TetrominoGo.transform
                                    .position =
                                StartArea[playerId];
                            foreach (var block in Tetrominos.Where(block =>
                                         block.Type == randomType[rIndex[playerId]] && block.Id == playerId))
                                block.IsActive = true;
                        }
                        else
                        {
                            Tetrominos.Find(mino => mino.Type == type && mino.Id == playerId).IsActive = true;
                            Tetrominos.Find(mino => mino.IsActive && mino.Id == playerId).TetrominoGo.transform
                                    .position =
                                StartArea[playerId];
                            foreach (var block in Tetrominos.Where(block => block.Type == type && block.Id == playerId))
                                block.IsActive = true;
                        }

                        foreach (var block in Tetrominos.Where(block => block.IsActive && block.Id == playerId))
                        {
                            block.AtSpawn = false;
                            if (block.Type == "I" || block.Type == "O")
                                block.Location = new[] {StartArea[playerId][0], StartArea[playerId][1] + 4, 0.0f};
                            else
                                block.Location = new[] {StartArea[playerId][0], StartArea[playerId][1] + 3, 0.0f};
                            if (holdSpawn[playerId])
                            {
                                block.IsHold = false;
                            }
                        }

                        if (holdSpawn[playerId] == false)
                        {
                            rIndex[playerId] = rnd.Next(randomType.Length);
                        }

                        DestroyImmediate(PreviewBlock[playerId]);
                        Preview(playerId);
                        ActiveSpawn[playerId] = false;
                        holdSpawn[playerId] = false;
                        IsFalling[playerId] = true;
                        timeAutoRepeat[playerId] = 0.0f;
                        timeFall[playerId] = 0.0f;
                        TimeLock[playerId] = 0.0f;
                        LockCounter[playerId] = 0;
                        lockDeepestRow[playerId] = 20;
                    }
                }
                else
                {
                    TileMap.GameOver(true);
                }
            }
        }

        /// <summary>
        ///     Controls gravity
        /// </summary>
        private void Falling()
        {
            for (int playerId = 0; playerId < PlayerIds.Count; playerId++)
            {
                timeFall[playerId] += Time.deltaTime;
                if (timeFall[playerId] >= TimeToFall)
                {
                    timeFall[playerId] = 0.0f;

                    if (IsFalling[playerId] && ActiveSpawn[playerId] == false)
                        foreach (var block in Tetrominos.Where(block => block.IsActive && block.Id == playerId))
                        {
                            if (CanMove(playerId, "down") == false && TimeLock[playerId] >= timeToLock ||
                                LockCounter[playerId] >= 15 && CanMove(playerId, "down") == false)
                            {
                                block.IsLocked = true;
                                block.IsActive = false;
                                IsFalling[playerId] = false;
                                ActiveSpawn[playerId] = true;
                                TimeLock[playerId] = 0.0f;
                                HoldUsed[playerId] = false;
                            }
                            if (CanMove(playerId, "down") && CanMoveToPlayer(playerId, "down"))
                            {
                                TimeLock[playerId] = 0.0f;
                                block.TetrominoGo.transform.Translate(Vector3.down * 1, Space.World);
                                block.Location = new[] {block.Location[0], block.Location[1] - 1.0f, block.Location[2]};
                            }
                        }
                }
            }
        }

        /// <summary>
        ///     User controls
        /// </summary>
        private void Controls()
        {
            for (int playerId = 0; playerId < PlayerIds.Count; playerId++)
            {
                timeAutoRepeat[playerId] += Time.deltaTime;
                timeSoftDrop[playerId] += Time.deltaTime;
                timeBeginAutoRepeat[playerId] += Time.deltaTime;


                // Not able to Soft Drop or Hard Drop
                foreach (var block in Tetrominos.Where(block => block.IsActive && block.Id == playerId))
                {
                    if (CanMove(playerId, "down") == false && ActiveSpawn[playerId] == false)
                    {
                        TimeLock[playerId] += Time.deltaTime;
                        if (TimeLock[playerId] >= timeToLock)
                        {
                            block.IsLocked = true;
                            ActiveSpawn[playerId] = true;
                            block.IsActive = false;
                            HoldUsed[playerId] = false;
                            TimeLock[playerId] = 0.0f;
                        }
                    }

                    if (lockDeepestRow[playerId] > (int) block.Location[1])
                    {
                        lockDeepestRow[playerId] = (int) block.Location[1];
                        LockCounter[playerId] = 0;
                    }
                }


                if (Input.GetKeyUp(KeybindHardDrop[playerId]) || Input.GetKeyDown(KeybindHardDrop[playerId]) ||
                    Input.GetKey(KeybindLeft[playerId]) ||
                    Input.GetKey(KeybindRight[playerId]) || Input.GetKey(KeybindSoftDrop[playerId]) ||
                    Input.GetKeyUp(KeybindSoftDrop[playerId]) ||
                    Input.GetKeyDown(KeybindLeft[playerId]) || Input.GetKeyDown(KeybindRight[playerId]) ||
                    Input.GetKeyDown(KeybindSoftDrop[playerId]) ||
                    Input.GetKeyUp(KeybindLeft[playerId]) || Input.GetKeyUp(KeybindRight[playerId]))
                {
                    // Auto Repeat direction control
                    if (Input.GetKeyUp(KeybindLeft[playerId]) && Input.GetKey(KeybindRight[playerId]))
                    {
                        lastDir[playerId] = true;
                        timeBeginAutoRepeat[playerId] = 0.0f;
                    }

                    if (Input.GetKeyDown(KeybindRight[playerId]))
                    {
                        lastDir[playerId] = true;
                        timeBeginAutoRepeat[playerId] = 0.0f;
                    }

                    if (Input.GetKeyUp(KeybindRight[playerId]) && Input.GetKey(KeybindLeft[playerId]))
                    {
                        lastDir[playerId] = false;
                        timeBeginAutoRepeat[playerId] = 0.0f;
                    }

                    if (Input.GetKeyDown(KeybindLeft[playerId]))
                    {
                        lastDir[playerId] = false;
                        timeBeginAutoRepeat[playerId] = 0.0f;
                    }

                    if (ActiveSpawn[playerId] == false)
                    {
                        foreach (var block in Tetrominos.Where(block => block.IsActive && block.Id == playerId))
                        {
                            // Hard Drop
                            if (Input.GetKeyDown(KeybindHardDrop[playerId]))
                                while (CanMove(playerId, "down"))
                                {
                                    IsFalling[playerId] = false;
                                    TimeLock[playerId] = timeToLock - 0.0001f;
                                    block.TetrominoGo.transform.Translate(Vector3.down * 1, Space.World);
                                    block.Location = new[]
                                        {block.Location[0], block.Location[1] - 1f, block.Location[2]};
                                    // Adding two score points per line for hard dropping
                                    ScoreSystem.Score += 2;
                                    ScoreSystem.IsTSpinLastMove = 0;
                                }

                            // Soft Drop
                            if (timeSoftDrop[playerId] >= TimeToSoftDrop)
                                if (Input.GetKey(KeybindSoftDrop[playerId]) && CanMove(playerId, "down") &&
                                    CanMoveToPlayer(playerId, "down") && TimeLock[playerId] <= timeToLock)
                                {
                                    IsFalling[playerId] = false;
                                    TimeLock[playerId] = 0.0f;
                                    timeFall[playerId] = 0.0f;
                                    timeSoftDrop[playerId] = 0.0f;
                                    block.TetrominoGo.transform.Translate(Vector3.down * 1, Space.World);
                                    block.Location = new[]
                                        {block.Location[0], block.Location[1] - 1f, block.Location[2]};
                                    // Adding one score point per line for soft dropping
                                    ScoreSystem.Score += 1;
                                    ScoreSystem.IsTSpinLastMove = 0;
                                }

                            // Falling disable for Soft Drop and Hard Drop
                            if (Input.GetKeyUp(KeybindSoftDrop[playerId]) ||
                                Input.GetKeyUp(KeybindHardDrop[playerId]) && CanMove(playerId, "down") &&
                                CanMoveToPlayer(playerId, "down"))
                            {
                                IsFalling[playerId] = true;
                                timeFall[playerId] = 0.0f;
                            }

                            // Left Movement
                            if (Input.GetKeyDown(KeybindLeft[playerId]) && CanMove(playerId, "left") &&
                                CanMoveToPlayer(playerId, "left"))
                            {
                                block.TetrominoGo.transform.Translate(Vector3.left * 1, Space.World);
                                block.Location = new[] {block.Location[0] - 1f, block.Location[1], block.Location[2]};
                                ScoreSystem.IsTSpinLastMove = 0;
                                TimeLock[playerId] = 0.0f;
                                LockCounter[playerId]++;
                            }
                            // Right Movement
                            else if (Input.GetKeyDown(KeybindRight[playerId]) && CanMove(playerId, "right") &&
                                     CanMoveToPlayer(playerId, "right"))
                            {
                                block.TetrominoGo.transform.Translate(Vector3.right * 1, Space.World);
                                block.Location = new[] {block.Location[0] + 1f, block.Location[1], block.Location[2]};
                                ScoreSystem.IsTSpinLastMove = 0;
                                TimeLock[playerId] = 0.0f;
                                LockCounter[playerId]++;
                            }

                            // Auto Repeat
                            if (timeAutoRepeat[playerId] >= timeToAutoRepeat &&
                                timeBeginAutoRepeat[playerId] >= timeToBeginAutoRepeat)
                            {
                                timeAutoRepeat[playerId] = 0.0f;
                                if (Input.GetKey(KeybindLeft[playerId]) && CanMove(playerId, "left") &&
                                    CanMoveToPlayer(playerId, "left") && lastDir[playerId] == false)
                                {
                                    block.TetrominoGo.transform.Translate(Vector3.left * 1, Space.World);
                                    block.Location = new[]
                                        {block.Location[0] - 1f, block.Location[1], block.Location[2]};
                                    ScoreSystem.IsTSpinLastMove = 0;
                                    TimeLock[playerId] = 0.0f;
                                    LockCounter[playerId]++;
                                }

                                if (Input.GetKey(KeybindRight[playerId]) && CanMove(playerId, "right") &&
                                    CanMoveToPlayer(playerId, "right") && lastDir[playerId])
                                {
                                    block.TetrominoGo.transform.Translate(Vector3.right * 1, Space.World);
                                    block.Location = new[]
                                        {block.Location[0] + 1f, block.Location[1], block.Location[2]};
                                    ScoreSystem.IsTSpinLastMove = 0;
                                    TimeLock[playerId] = 0.0f;
                                    LockCounter[playerId]++;
                                }
                            }
                        }
                    }
                }
            }
        } // ReSharper disable Unity.PerformanceAnalysis
        /// <summary>
        ///     Controls block holding
        /// </summary>
        private void Hold()
        {
            for (int playerId = 0; playerId < PlayerIds.Count; playerId++)
            {
                if (HoldUsed[playerId] == false && Input.GetKeyDown(KeybindHold[playerId]))
                {
                    foreach (var block in Tetrominos.Where(block => block.IsActive && block.Id == playerId))
                    {
                        block.IsHold = true;
                        block.IsActive = false;
                        block.Location = new[] {SpawnArea[0], SpawnArea[1], SpawnArea[2]};
                        if (HoldBlock[playerId] != null) DestroyImmediate(HoldBlock[playerId]);

                        block.TetrominoGo.transform.position = SpawnArea;
                        while (block.RotationState != 0)
                        {
                            block.AtSpawn = true;
                            Rotation.Rotate(playerId, "Ac", 0, 0);
                            block.RotationState -= 1;
                        }

                        HoldBlock[playerId] = Instantiate(block.TetrominoGo);
                        HoldBlock[playerId].transform.position = HoldArea[playerId];

                        if (block.RotationState == 0) block.AtSpawn = false;



                        if (randomType.Contains(HoldType[playerId]))
                        {
                            holdSpawn[playerId] = true;
                            SpawnMino(playerId, HoldType[playerId]);
                        }

                        else
                        {
                            ActiveSpawn[playerId] = true;
                            SpawnMino(playerId, "random");
                        }

                        HoldUsed[playerId] = true;
                        break;
                    }

                    if (Tetrominos.Exists(block => block.IsHold && block.Id == playerId))
                        HoldType[playerId] = Tetrominos.Find(block => block.IsHold && block.Id == playerId).Type;
                }
            }
        }
    }
}