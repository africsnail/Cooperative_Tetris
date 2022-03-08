using UnityEngine;

public class Tetromino
{
    // Spawn coordinates

    public int Id;
    public float[] Location { get; set; }

    // Tetromino variables
    public int[,] RGrid { get; set; }
    public string Type { get; set; }
    public GameObject[,] CubeGo { get; set; }
    public bool IsActive { get; set; }
    public bool IsHold { get; set; }
    public bool IsLocked { get; set; }
    public bool AtSpawn { get; set; }
    public GameObject TetrominoGo { get; set; }
    public int RotationState { get; set; }
    public Color Color { get; set; }
}