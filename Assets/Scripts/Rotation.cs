using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tetris
{
    /// <summary>
    /// Manages rotation of blocks
    /// </summary>
    public class Rotation : MonoBehaviour
    {
        public static float RotationOffsetX;
        public static float RotationOffsetY;

        public static readonly List<string> KeybindRotateC = new List<string> {"d", "right", "right"};
        public static readonly List<string> KeybindRotateAc = new List<string> {"a", "left", "left"};


        public static readonly List<int> FutureRotationC = new List<int>();
        public static readonly List<int> FutureRotationAc = new List<int>();

        public static int[,] RGridCache { get; set; }

        // rotation data for other than "I" block rotations
        private readonly int[][] _rotationSystem = new int[][]
        {
            new[] {0, -1, -1, 0, -1},
            new[] {0, 0, 1, -2, -2},

            new[] {0, 1, 1, 0, 1},
            new[] {0, 0, -1, 2, 2},

            new[] {0, 1, 1, 0, 1},
            new[] {0, 0, 1, -2, -2},

            new[] {0, -1, -1, 0, -1},
            new[] {0, 0, -1, 2, 2}
        };

        // rotation data for "I" block rotations
        private readonly int[][] _rotationSystemI = new int[][]
        {
            new[] {0, -2, 1, -2, 1},
            new[] {0, 0, 0, -1, 2},

            new[] {0, -1, 2, -1, 2},
            new[] {0, 0, 0, 2, -1},

            new[] {0, 2, -1, 2, -1},
            new[] {0, 0, 0, 1, -2},

            new[] {0, 1, -2, 1, -2},
            new[] {0, 0, 0, -2, 1}
        };

        // Rotation states data
        private readonly int[][] _rotationStates = new int[][]
        {
            new[] {0, 1},
            new[] {1, 2},
            new[] {2, 3},
            new[] {3, 0}
        };
        /// <summary>
        /// Attempts a rotation, returns true if successful 
        /// </summary>
        /// <param name="playerId">player id</param>
        /// <param name="fromState">from rotation state</param>
        /// <param name="intoState">into rotation state</param>
        /// <param name="xOffset">x axis move</param>
        /// <param name="yOffset">y axis move</param>
        /// <param name="direction">direction</param>
        /// <returns></returns>
        public bool RotateAttempt(int playerId, int fromState, int intoState, int xOffset, int yOffset,
            string direction)
        {
            Debug.Log("Attempting rotation: " + playerId + " " + direction + " moving by x: " + xOffset + ", y:" +
                      yOffset + " (from state " + fromState + " to " + intoState + ")");
            if (CanRotate(playerId, fromState, intoState, xOffset, yOffset))
            {
                Rotate(playerId, direction, xOffset, yOffset);
                Debug.Log("Rotating player: " + playerId + " " + direction + " moving by x: " + xOffset + ", y:" +
                          yOffset + " (from state " + fromState + " to " + intoState + ")");
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Returns if a block is able to rotate, checks for wall and player collisions
        /// </summary>
        /// <param name="playerId">player id</param>
        /// <param name="fromState">from rotation state</param>
        /// <param name="intoState">into rotation state</param>
        /// <param name="xOffset">x axis move</param>
        /// <param name="yOffset">y axis move</param>
        /// <returns></returns>
        public static bool CanRotate(int playerId, int fromState, int intoState, int xOffset, int yOffset)
        {
            // Getting collision grid for other player collisions
            foreach (var block in Blocks.Tetrominos.Where(block => block.IsActive && block.Id != playerId))
            {
                for (int sizeX = 0; sizeX < block.Size; sizeX++)
                for (int sizeY = 0; sizeY < block.Size; sizeY++)
                {
                    if (block.RGrid[sizeX, sizeY] == 1)
                    {
                        TileMap.MovementTileMap.CollisionMap[sizeX + (int) block.Location[0],
                            (int) block.Location[1] + sizeY - block.Size] = true;
                    }
                }
            }

            int rotationType;
            if (Math.Abs(intoState - fromState) == 2)
                rotationType = 2;
            else if (intoState - fromState == -1 || intoState - fromState == 3)
                rotationType = -1;
            else
                rotationType = 1;

            var canRotate = true;

            // Rotate the grid
            foreach (var block in Blocks.Tetrominos.Where(block => block.IsActive && block.Id == playerId))
            {
                RGridCache = new int[block.Size, block.Size];
                if (rotationType == -1)
                    for (var x = 0; x < block.Size; x++)
                    for (var y = 0; y < block.Size; y++)
                    {
                        var newX = block.Size - 1 - y;
                        RGridCache[newX, x] = RotateGridAc(block.Size, block.RGrid, x, y)[newX, x];
                    }
                else
                    for (var c = 0; c <= rotationType; c++)
                    for (var x = 0; x < block.Size; x++)
                    for (var y = 0; y < block.Size; y++)
                    {
                        var newY = block.Size - 1 - x;
                        RGridCache[y, newY] = RotateGridC(block.Size, block.RGrid, x, y)[y, newY];
                    }

                // Check for collisions
                for (var x = 0; x < block.Size; x++)
                for (var y = 0; y < block.Size; y++)
                    if (canRotate)
                        if (RGridCache[x, y] == 1)
                        {
                            var locationX = (int) block.Location[0] + x + xOffset + 1;
                            var locationY = (int) block.Location[1] + y + yOffset - block.Size + 1;

                            if (locationX <= TileMap.PlayGrid.GetUpperBound(0) &&
                                locationX >= TileMap.PlayGrid.GetLowerBound(0) &&
                                locationY <= TileMap.PlayGrid.GetUpperBound(1) &&
                                locationY >= TileMap.PlayGrid.GetLowerBound(1))
                            {
                                if (TileMap.PlayGrid[locationX, locationY] != 0)
                                {
                                    Debug.Log("Cannot rotate due to player to wall collision" );
                                    canRotate = false;
                                    TileMap.ClearCollisionMap();
                                }
                                else if (TileMap.MovementTileMap.CollisionMap[locationX - 1,
                                             locationY - 1])
                                {
                                    Debug.Log("Cannot rotate due to player to player collision on " + (locationX - 1) + ", " + (locationY - 1));
                                    canRotate = false;
                                    TileMap.ClearCollisionMap();
                                }
                            }
                            else
                            {
                                Debug.Log("Cannot rotate due to outside-bound collision" + (locationX) + ", " + (locationY));
                                canRotate = false;
                                TileMap.ClearCollisionMap();
                            }
                        }
            }

            if (canRotate)
            {
                Debug.Log("Can rotate");
            }
            TileMap.ClearCollisionMap();
            return canRotate;
        }
        /// <summary>
        /// Checks if a block has T-Spun
        /// </summary>
        /// <param name="location">block location</param>
        /// <param name="rotationState">block rotation state</param>
        /// <returns></returns>
        private static int IsTSpin(int[] location, int rotationState)
        {
            // Declaring T-Block sides
            var sideA = new[] {0, 0};
            var sideB = new[] {0, 0};
            var sideC = new[] {0, 0};
            var sideD = new[] {0, 0};
            location[0] += 2;
            location[1] -= 1;

            switch (rotationState)
            {
                case 0:
                    sideA = new[] {-1, 1};
                    sideB = new[] {1, 1};
                    sideC = new[] {-1, -1};
                    sideD = new[] {1, -1};
                    break;
                case 1:
                    sideA = new[] {1, 1};
                    sideB = new[] {1, -1};
                    sideC = new[] {-1, 1};
                    sideD = new[] {-1, -1};
                    break;
                case 2:
                    sideA = new[] {1, 1};
                    sideB = new[] {-1, -1};
                    sideC = new[] {1, 1};
                    sideD = new[] {-1, 1};
                    break;
                case 3:
                    sideA = new[] {-1, -1};
                    sideB = new[] {-1, 1};
                    sideC = new[] {1, -1};
                    sideD = new[] {1, 1};
                    break;
            }

            if (TileMap.PlayGrid[location[0] + sideA[0], location[1] + sideA[1]] == 1 &&
                TileMap.PlayGrid[location[0] + sideB[0], location[1] + sideB[1]] == 1 &&
                TileMap.PlayGrid[location[0] + sideC[0], location[1] + sideC[1]] == 1 &&
                TileMap.PlayGrid[location[0] + sideD[0], location[1] + sideD[1]] == 1)
            {
                return 1;
            }
            else if (TileMap.PlayGrid[location[0] + sideA[0], location[1] + sideA[1]] == 1 &&
                     TileMap.PlayGrid[location[0] + sideB[0], location[1] + sideB[1]] == 1 &&
                     (TileMap.PlayGrid[location[0] + sideC[0], location[1] + sideC[1]] == 1 ||
                      TileMap.PlayGrid[location[0] + sideD[0], location[1] + sideD[1]] == 1))
            {
                return 1;
            }
            else
            {
                if (TileMap.PlayGrid[location[0] + sideC[0], location[1] + sideC[1]] == 1 &&
                    TileMap.PlayGrid[location[0] + sideD[0], location[1] + sideD[1]] == 1 &&
                    (TileMap.PlayGrid[location[0] + sideA[0], location[1] + sideA[1]] == 1 ||
                     TileMap.PlayGrid[location[0] + sideB[0], location[1] + sideB[1]] == 1))
                    return 2;
                else return 0;
            }
        }

        private static int NewY(int size, int x)
        {
            var newY = size - 1 - x;
            return newY;
        }

        private static int NewX(int size, int y)
        {
            var newX = size - 1 - y;
            return newX;
        }

        private static int[,] RotateGridAc(int size, int[,] gridToRotate, int x, int y)
        {
            var rotatedGridAc = new int[size, size];
            rotatedGridAc[NewX(size, y), x] = gridToRotate[x, y];
            return rotatedGridAc;
        }

        private static int[,] RotateGridC(int size, int[,] gridToRotate, int x, int y)
        {
            var rotatedGridC = new int[size, size];
            rotatedGridC[y, NewY(size, x)] = gridToRotate[x, y];
            return rotatedGridC;
        }
        /// <summary>
        /// Governs the [Super Rotation System](https://tetris.fandom.com/wiki/SRS) 
        /// </summary>
        private void DoRotation()
        {
            for (var playerId = 0; playerId < Blocks.PlayerIds.Count; playerId++)
            {
                if (Input.GetKeyDown(KeybindRotateC[playerId]) || Input.GetKeyDown(KeybindRotateAc[playerId]))
                    if (Blocks.IsFalling[playerId] && Blocks.ActiveSpawn[playerId] == false)
                        foreach (var block in Blocks.Tetrominos.Where(block => block.IsActive && block.Id == playerId))
                        {
                            if (block.RotationState == 3)
                                FutureRotationC[playerId] = 0;
                            else
                                FutureRotationC[playerId] = block.RotationState + 1;

                            if (block.RotationState == 0)
                                FutureRotationAc[playerId] = 3;
                            else
                                FutureRotationAc[playerId] = block.RotationState - 1;

                            if (Input.GetKeyDown(KeybindRotateC[playerId]))
                            {
                                if (block.Type != "I")
                                {
                                    // Rotate clockwise for non I tetrominos
                                    for (var x = 0; x < 4; x++)
                                    {
                                        if (block.RotationState == _rotationStates[x][0] &&
                                            FutureRotationC[playerId] == _rotationStates[x][1])
                                        {
                                            for (var c = 0; c < 5; c++)
                                            {
                                                if (RotateAttempt(playerId, block.RotationState,
                                                        FutureRotationC[playerId], _rotationSystem[x * 2][c],
                                                        _rotationSystem[x * 2 + 1][c], "C"))
                                                    break;
                                            }

                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    for (var x = 0; x < 4; x++)
                                    {
                                        if (block.RotationState == _rotationStates[x][0] &&
                                            FutureRotationC[playerId] == _rotationStates[x][1])
                                        {
                                            for (var c = 0; c < 5; c++)
                                            {
                                                if (RotateAttempt(playerId, block.RotationState,
                                                        FutureRotationC[playerId], _rotationSystemI[x * 2][c],
                                                        _rotationSystemI[x * 2 + 1][c], "C"))
                                                    break;
                                            }

                                            break;
                                        }
                                    }
                                }
                            }
                            else if (Input.GetKeyDown(KeybindRotateAc[playerId]))
                            {
                                if (block.Type != "I")
                                {
                                    // Rotate anticlockwise for non I tetrominos
                                    for (var x = 0; x < 4; x++)
                                    {
                                        if (block.RotationState == _rotationStates[x][1] &&
                                            FutureRotationAc[playerId] == _rotationStates[x][0])
                                        {
                                            for (var c = 0; c < 5; c++)
                                            {
                                                Debug.Log("c = " + c + ", x = " + x);
                                                if (RotateAttempt(playerId, block.RotationState,
                                                        FutureRotationAc[playerId], -1 * _rotationSystem[x * 2][c],
                                                         -1 * _rotationSystem[x * 2 + 1][c], "Ac"))
                                                    break;
                                            }

                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    // Rotate anticlockwise for I tetrominos
                                    for (var x = 0; x < 4; x++)
                                    {
                                        if (block.RotationState == _rotationStates[x][1] &&
                                            FutureRotationAc[playerId] == _rotationStates[x][0])
                                        {
                                            for (var c = 0; c < 5; c++)
                                            {
                                                if (RotateAttempt(playerId, block.RotationState,
                                                        FutureRotationAc[playerId], -1 * _rotationSystemI[x * 2][c],
                                                        -1 * _rotationSystemI[x * 2 + 1][c], "Ac"))
                                                    break;
                                            }

                                            break;
                                        }
                                    }
                                }
                            }
                        }
            }
        }
        /// <summary>
        /// Rotates the block
        /// </summary>
        /// <param name="playerId">player id</param>
        /// <param name="direction">direction of rotation</param>
        /// <param name="xMove">x axis move</param>
        /// <param name="yMove">y axis move</param>
        public static void Rotate(int playerId, string direction, int xMove, int yMove)
        {
            foreach (var block in Blocks.Tetrominos.Where(block => block.IsActive || block.AtSpawn)
                         .Where(block => block.Id == playerId))
                if (block.IsLocked == false && Blocks.ActiveSpawn[playerId] == false || block.AtSpawn)
                {
                    if (block.AtSpawn == false)
                        ScoreSystem.IsTSpinLastMove = 0;

                    int size;
                    if (block.Type == "I" || block.Type == "O")
                    {
                        RotationOffsetX = 1.5f;
                        RotationOffsetY = 2.5f;
                        size = 4;
                    }
                    else
                    {
                        RotationOffsetX = 1f;
                        RotationOffsetY = 2f;
                        size = 3;
                    }


                    if (direction == "C")
                    {
                        // Moves the tetromino the required distance for a kick
                        block.TetrominoGo.transform.Translate(new Vector3(xMove, yMove, 0), Space.World);
                        block.Location[0] += xMove;
                        block.Location[1] += yMove;

                        // Rotates the tetromino clockwise
                        block.TetrominoGo.transform.RotateAround(
                            new Vector3(block.Location[0] + RotationOffsetX,
                                block.Location[1] - RotationOffsetY, block.Location[2]), Vector3.back,
                            90.0f);


                        RGridCache = new int[size, size];
                        for (var x = 0; x < size; x++)
                        for (var y = 0; y < size; y++)
                            RGridCache[y, NewY(size, x)] = RotateGridC(size, block.RGrid, x, y)[y, NewY(size, x)];
                        for (var x = 0; x < size; x++)
                        for (var y = 0; y < size; y++)
                        {
                            block.RGrid[x, y] = RGridCache[x, y];
                            if (block.CubeGo[x, y] != null)
                                block.CubeGo[x, y].transform.Rotate(Vector3.back, -90.0f);
                        }

                        if (block.AtSpawn == false) block.RotationState = FutureRotationC[playerId];

                        if (block.Type == "T" && block.Type == "T" && block.AtSpawn == false)
                        {
                            if (IsTSpin(new[] {(int) block.Location[0], (int) block.Location[1]},
                                    block.RotationState) == 2)
                            {
                                if (Menu.Alerts == 1)
                                    Menu.AlertStart("Mini T-Spin");
                                ScoreSystem.IsTSpinLastMove = 2;
                                ScoreSystem.CurrentAction += 1;
                                ScoreSystem.Score += 100 * ScoreSystem.CurrentLevel;
                            }
                            else if (IsTSpin(new[] {(int) block.Location[0], (int) block.Location[1]},
                                         block.RotationState) == 1)
                            {
                                if (Menu.Alerts == 1)
                                    Menu.AlertStart("T-Spin");
                                ScoreSystem.IsTSpinLastMove = 1;
                                ScoreSystem.CurrentAction += 4;
                                ScoreSystem.Score += 400 * ScoreSystem.CurrentLevel;
                            }
                        }
                    }
                    else if (direction == "Ac")
                    {
                        // Moves the tetromino the required distance for a kick
                        block.TetrominoGo.transform.Translate(new Vector3(xMove, yMove, 0), Space.World);
                        block.Location[0] += xMove;
                        block.Location[1] += yMove;

                        // Rotates the tetromino anti-clockwise
                        block.TetrominoGo.transform.RotateAround(
                            new Vector3(block.Location[0] + RotationOffsetX, block.Location[1] - RotationOffsetY,
                                block.Location[2]), Vector3.back, -90.0f);


                        RGridCache = new int[size, size];
                        for (var x = 0; x < size; x++)
                        for (var y = 0; y < size; y++)
                            RGridCache[NewX(size, y), x] = RotateGridAc(size, block.RGrid, x, y)[NewX(size, y), x];
                        for (var x = 0; x < size; x++)
                        for (var y = 0; y < size; y++)
                        {
                            block.RGrid[x, y] = RGridCache[x, y];
                            if (block.CubeGo[x, y] != null)
                                block.CubeGo[x, y].transform.Rotate(Vector3.back, 90.0f);
                        }

                        if (block.AtSpawn == false) block.RotationState = FutureRotationAc[playerId];

                        if (block.Type == "T" && block.AtSpawn == false)
                        {
                            if (IsTSpin(new[] {(int) block.Location[0], (int) block.Location[1]},
                                    block.RotationState) == 2)
                            {
                                if (Menu.Alerts == 1)
                                    Menu.AlertStart("Mini T-Spin");
                                ScoreSystem.IsTSpinLastMove = 2;
                                ScoreSystem.CurrentAction += 1;
                                ScoreSystem.Score += 100 * ScoreSystem.CurrentLevel;
                            }
                            else if (IsTSpin(new[] {(int) block.Location[0], (int) block.Location[1]},
                                         block.RotationState) == 1)
                            {
                                if (Menu.Alerts == 1)
                                    Menu.AlertStart("T-Spin");
                                ScoreSystem.IsTSpinLastMove = 1;
                                ScoreSystem.CurrentAction += 4;
                                ScoreSystem.Score += 400 * ScoreSystem.CurrentLevel;
                            }
                        }
                    }

                    Blocks.TimeLock[playerId] = 0.0f;
                    Blocks.LockCounter[playerId]++;
                }
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Menu.Menus[0].IsPaused && !Menu.Menus[1].IsPaused && !Menu.Menus[2].IsPaused)
                DoRotation();
        }
    }
}