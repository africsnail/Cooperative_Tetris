using UnityEngine;

namespace Tetris
{
    /// <summary>
    /// Class used for playing field
    /// </summary>
    public class SubTileMap
    {
        /// <summary>
        /// Gets box's active status
        /// </summary>
        public bool[,] IsActive { get; set; }
        /// <summary>
        /// Gets box's color
        /// </summary>
        public Color[,] Color { get; set; }
        /// <summary>
        /// Gets box's clear status, used for clearing rows
        /// </summary>
        public bool[,] IsClear { get; set; }
        /// <summary>
        /// Gets collision map, used for player to player collisions
        /// </summary>
        public bool[,] CollisionMap { get; set; }
        /// <summary>
        /// Gets play grid cubes
        /// </summary>
        public GameObject[,] GridCube { get; set; }
    }
}