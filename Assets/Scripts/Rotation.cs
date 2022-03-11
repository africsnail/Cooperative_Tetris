using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Rotation : MonoBehaviour
{
    public static float RotationOffsetX;
    public static float RotationOffsetY;

    public string keybindRotateC = "d";
    public string keybindRotateAc = "a";


    public static int FutureRotationC { get; set; }
    public static int FutureRotationAc { get; set; }
    public static int[,] RGridCache { get; set; }

    public static bool CanRotate(int fromState, int intoState, int xOffset, int yOffset)
    {
        int count;
        if (Math.Abs(intoState - fromState) == 2)
            count = 2;
        else if (intoState - fromState == -1 || intoState - fromState == 3)
            count = -1;
        else
            count = 1;

        var canRotate = true;

        foreach (var block in Blocks.Tetrominos.Where(block => block.IsActive))
        {
            int size;
            if (block.Type == "I" || block.Type == "O")
                size = 4;
            else
                size = 3;
            RGridCache = new int[size, size];
            if (count == -1)
                for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++)
                {
                    var newX = size - 1 - y;
                    RGridCache[newX, x] = RotateGridAc(size, block.RGrid, x, y)[newX, x];
                }
            else
                for (var c = 0; c <= count; c++)
                for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++)
                {
                    var newY = size - 1 - x;
                    RGridCache[y, newY] = RotateGridC(size, block.RGrid, x, y)[y, newY];
                }


            for (var x = 0; x < size; x++)
            for (var y = 0; y < size; y++)
                if (canRotate)
                    if (RGridCache[x, y] == 1)
                    {
                        int yWithSizeOffset;
                        if (size == 4)
                            yWithSizeOffset = y - 1;
                        else
                            yWithSizeOffset = y;
                        var locationX = (int) block.Location[0] + x + xOffset + 1;
                        var locationY = (int) block.Location[1] + yWithSizeOffset + yOffset - 2;
                        //int value = playGrid[locationX, locationY];

                        if (locationX <= TileMap.PlayGrid.GetUpperBound(0) &&
                            locationX >= TileMap.PlayGrid.GetLowerBound(0) &&
                            locationY <= TileMap.PlayGrid.GetUpperBound(1) &&
                            locationY >= TileMap.PlayGrid.GetLowerBound(1))
                        {
                            if (TileMap.PlayGrid[(int) block.Location[0] + x + xOffset + 1,
                                    (int) block.Location[1] + yWithSizeOffset + yOffset - 2] != 0)
                                canRotate = false;
                        }
                        else
                        {
                            Debug.Log("Detected out of bounds collision");
                            canRotate = false;
                        }
                    }
        }


        return canRotate;
    }

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

    private void Rotate()
    {
        if (Input.GetKeyDown(keybindRotateC) || Input.GetKeyDown(keybindRotateAc))
            if (Blocks.IsFalling && Blocks.ActiveSpawn == false)
                foreach (var block in Blocks.Tetrominos.Where(block => block.IsActive))
                {
                    if (block.RotationState == 3)
                        FutureRotationC = 0;
                    else
                        FutureRotationC = block.RotationState + 1;

                    if (block.RotationState == 0)
                        FutureRotationAc = 3;
                    else
                        FutureRotationAc = block.RotationState - 1;

                    if (Input.GetKeyDown(keybindRotateC))
                    {
                        if (block.Type != "I")
                        {
                            // Rotate clockwise for non I tetrominos
                            if (block.RotationState == 0 && FutureRotationC == 1)
                            {
                                if (CanRotate(block.RotationState, FutureRotationC, 0, 0))
                                    Rotate("C", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, 0))
                                    Rotate("C", -1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, 1))
                                    Rotate("C", -1, 1);
                                else if (CanRotate(block.RotationState, FutureRotationC, 0, -2))
                                    Rotate("C", 0, -2);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, -2))
                                    Rotate("C", -1, -2);
                            }
                            else if (block.RotationState == 1 && FutureRotationC == 2)
                            {
                                if (CanRotate(block.RotationState, FutureRotationC, 0, 0))
                                    Rotate("C", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, 0))
                                    Rotate("C", 1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, -1))
                                    Rotate("C", 1, -1);
                                else if (CanRotate(block.RotationState, FutureRotationC, 0, 2))
                                    Rotate("C", 0, 2);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, 2))
                                    Rotate("C", 1, 2);
                            }
                            else if (block.RotationState == 2 && FutureRotationC == 3)
                            {
                                if (CanRotate(block.RotationState, FutureRotationC, 0, 0))
                                    Rotate("C", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, 0))
                                    Rotate("C", 1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, 1))
                                    Rotate("C", 1, 1);
                                else if (CanRotate(block.RotationState, FutureRotationC, 0, -2))
                                    Rotate("C", 0, -2);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, -2))
                                    Rotate("C", 1, -2);
                            }
                            else if (block.RotationState == 3 && FutureRotationC == 0)
                            {
                                if (CanRotate(block.RotationState, FutureRotationC, 0, 0))
                                    Rotate("C", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, 0))
                                    Rotate("C", -1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, -1))
                                    Rotate("C", -1, -1);
                                else if (CanRotate(block.RotationState, FutureRotationC, 0, 2))
                                    Rotate("C", 0, 2);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, 2))
                                    Rotate("C", -1, 2);
                            }
                        }
                        else
                        {
                            // Rotate clockwise for I tetrominos
                            if (block.RotationState == 0 && FutureRotationC == 1)
                            {
                                if (CanRotate(block.RotationState, FutureRotationC, 0, 0))
                                    Rotate("C", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -2, 0))
                                    Rotate("C", -2, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, 0))
                                    Rotate("C", 1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -2, -1))
                                    Rotate("C", -2, -1);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, 2))
                                    Rotate("C", 1, 2);
                            }
                            else if (block.RotationState == 1 && FutureRotationC == 2)
                            {
                                if (CanRotate(block.RotationState, FutureRotationC, 0, 0))
                                    Rotate("C", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, 0))
                                    Rotate("C", -1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 2, 0))
                                    Rotate("C", 2, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, 2))
                                    Rotate("C", -1, 2);
                                else if (CanRotate(block.RotationState, FutureRotationC, 2, -1))
                                    Rotate("C", 2, -1);
                            }
                            else if (block.RotationState == 2 && FutureRotationC == 3)
                            {
                                if (CanRotate(block.RotationState, FutureRotationC, 0, 0))
                                    Rotate("C", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 2, 0))
                                    Rotate("C", 2, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, 0))
                                    Rotate("C", -1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 2, 1))
                                    Rotate("C", 2, 1);
                                else if (CanRotate(block.RotationState, FutureRotationC, -1, 2))
                                    Rotate("C", -1, 2);
                            }
                            else if (block.RotationState == 3 && FutureRotationC == 0)
                            {
                                if (CanRotate(block.RotationState, FutureRotationC, 0, 0))
                                    Rotate("C", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, 0))
                                    Rotate("C", 1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, -2, 0))
                                    Rotate("C", -2, 0);
                                else if (CanRotate(block.RotationState, FutureRotationC, 1, -2))
                                    Rotate("C", 1, -2);
                                else if (CanRotate(block.RotationState, FutureRotationC, -2, 1))
                                    Rotate("C", -2, 1);
                            }
                        }
                    }
                    else if (Input.GetKeyDown(keybindRotateAc))
                    {
                        if (block.Type != "I")
                        {
                            //Rotate anticlockwise for non I tetrominos
                            if (block.RotationState == 1 && FutureRotationAc == 0)
                            {
                                if (CanRotate(block.RotationState, FutureRotationAc, 0, 0))
                                    Rotate("Ac", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, 0))
                                    Rotate("Ac", 1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, -1))
                                    Rotate("Ac", 1, -1);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 0, 2))
                                    Rotate("Ac", 0, 2);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, 2))
                                    Rotate("Ac", 1, 2);
                            }
                            else if (block.RotationState == 2 && FutureRotationAc == 1)
                            {
                                if (CanRotate(block.RotationState, FutureRotationAc, 0, 0))
                                    Rotate("Ac", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, 0))
                                    Rotate("Ac", -1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, 1))
                                    Rotate("Ac", -1, 1);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 0, -2))
                                    Rotate("Ac", 0, -2);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, -2))
                                    Rotate("Ac", -1, -2);
                            }
                            else if (block.RotationState == 3 && FutureRotationAc == 2)
                            {
                                if (CanRotate(block.RotationState, FutureRotationAc, 0, 0))
                                    Rotate("Ac", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, 0))
                                    Rotate("Ac", -1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, -1))
                                    Rotate("Ac", -1, -1);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 0, 2))
                                    Rotate("Ac", 0, 2);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, 2))
                                    Rotate("Ac", -1, 2);
                            }
                            else if (block.RotationState == 0 && FutureRotationAc == 3)
                            {
                                if (CanRotate(block.RotationState, FutureRotationAc, 0, 0))
                                    Rotate("Ac", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, 0))
                                    Rotate("Ac", 1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, 1))
                                    Rotate("Ac", 1, 1);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 0, -2))
                                    Rotate("Ac", 0, -2);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, -2))
                                    Rotate("Ac", 1, -2);
                            }
                        }
                        else
                        {
                            // Rotate anticlockwise for I tetrominos
                            if (block.RotationState == 1 && FutureRotationAc == 0)
                            {
                                if (CanRotate(block.RotationState, FutureRotationAc, 0, 0))
                                    Rotate("Ac", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 2, 0))
                                    Rotate("Ac", 2, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, 0))
                                    Rotate("Ac", -1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 2, 1))
                                    Rotate("Ac", 2, 1);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, -2))
                                    Rotate("Ac", -1, -2);
                            }
                            else if (block.RotationState == 2 && FutureRotationAc == 1)
                            {
                                if (CanRotate(block.RotationState, FutureRotationAc, 0, 0))
                                    Rotate("Ac", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, 0))
                                    Rotate("Ac", 1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -2, 0))
                                    Rotate("Ac", -2, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, -2))
                                    Rotate("Ac", 1, -2);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -2, 1))
                                    Rotate("Ac", -2, 1);
                            }
                            else if (block.RotationState == 3 && FutureRotationAc == 2)
                            {
                                if (CanRotate(block.RotationState, FutureRotationAc, 0, 0))
                                    Rotate("Ac", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -2, 0))
                                    Rotate("Ac", -2, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, 0))
                                    Rotate("Ac", 1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -2, -1))
                                    Rotate("Ac", -2, -1);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 1, 2))
                                    Rotate("Ac", 1, 2);
                            }
                            else if (block.RotationState == 0 && FutureRotationAc == 3)
                            {
                                if (CanRotate(block.RotationState, FutureRotationAc, 0, 0))
                                    Rotate("Ac", 0, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, 0))
                                    Rotate("Ac", -1, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 2, 0))
                                    Rotate("Ac", 2, 0);
                                else if (CanRotate(block.RotationState, FutureRotationAc, -1, 2))
                                    Rotate("Ac", -1, 2);
                                else if (CanRotate(block.RotationState, FutureRotationAc, 2, -1))
                                    Rotate("Ac", 2, -1);
                            }
                        }
                    }
                }
    }

    public static void Rotate(string direction, int xMove, int yMove)
    {
        foreach (var block in Blocks.Tetrominos.Where(block => block.IsActive || block.AtSpawn))
            if (block.IsLocked == false && Blocks.ActiveSpawn == false || block.AtSpawn)
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

                    if (block.AtSpawn == false) block.RotationState = FutureRotationC;

                    if (block.Type == "T" && block.Type == "T" && block.AtSpawn == false)
                    {
                        Debug.Log("Checking for T-Spin");
                        if (IsTSpin(new[] {(int) block.Location[0], (int) block.Location[1]}, block.RotationState) == 2)
                        {
                            Debug.Log("Mini T-Spin");
                            ScoreSystem.IsTSpinLastMove = 2;
                            ScoreSystem.CurrentAction += 1;
                            ScoreSystem.Score += 100;
                        }
                        else if (IsTSpin(new[] {(int) block.Location[0], (int) block.Location[1]},
                                     block.RotationState) == 1)
                        {
                            Debug.Log("T-Spin");
                            ScoreSystem.IsTSpinLastMove = 1;
                            ScoreSystem.CurrentAction += 4;
                            ScoreSystem.Score += 400;
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

                    if (block.AtSpawn == false) block.RotationState = FutureRotationAc;

                    if (block.Type == "T" && block.AtSpawn == false)
                    {
                        Debug.Log("Checking for T-Spin");
                        if (IsTSpin(new[] {(int) block.Location[0], (int) block.Location[1]}, block.RotationState) == 2)
                        {
                            Debug.Log("Mini T-Spin");
                            ScoreSystem.IsTSpinLastMove = 2;
                            ScoreSystem.CurrentAction += 1;
                            ScoreSystem.Score += 100;
                        }
                        else if (IsTSpin(new[] {(int) block.Location[0], (int) block.Location[1]},
                                     block.RotationState) == 1)
                        {
                            Debug.Log("T-Spin");
                            ScoreSystem.IsTSpinLastMove = 1;
                            ScoreSystem.CurrentAction += 4;
                            ScoreSystem.Score += 400;
                        }
                    }
                }

                Blocks.TimeLock = 0.0f;
                Blocks.LockCounter++;
            }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {
        if (!Menu.Menus[0].IsPaused && !Menu.Menus[2].IsPaused)
            Rotate();
    }
}