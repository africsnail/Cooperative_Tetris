using UnityEngine;

namespace Tetris
{
    public class SubTileMap
    {
        public bool[,] IsActive { get; set; }
        public Color[,] Color { get; set; }
        public bool[,] IsClear { get; set; }
        public bool[,] CollisionMap { get; set; }
        public GameObject[,] GridCube { get; set; }
    }
}