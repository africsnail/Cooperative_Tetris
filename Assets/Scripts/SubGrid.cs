using UnityEngine;

public class SubGrid
{
    public bool[,] IsActive { get; set; }
    public Color[,] Color { get; set; }
    public bool[,] IsClear { get; set; }
    public GameObject[,] GridCube { get; set; }
}