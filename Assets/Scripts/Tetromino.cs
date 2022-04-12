using UnityEngine;

namespace Tetris
{
    public class Tetromino
    {
        // Spawn coordinates
        /// <summary>
        /// Get block's player id
        /// </summary>
        public int Id;
        /// <summary>
        /// Gets block's location
        /// </summary>
        public float[] Location { get; set; }

        // Tetromino variables
        /// <summary>
        /// Gets block rotational grid, used for rotating the block
        /// </summary>
        public int[,] RGrid { get; set; }
        /// <summary>
        /// Gets block's array size
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Gets block's type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Array for the individual cube GameObjects
        /// </summary>
        public GameObject[,] CubeGo { get; set; }
        /// <summary>
        /// Gets block's activity state
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets block's hold state
        /// </summary>
        public bool IsHold { get; set; }
        /// <summary>
        /// Gets block's lock state
        /// </summary>
        public bool IsLocked { get; set; }
        /// <summary>
        /// Gets block's spawn state
        /// </summary>
        public bool AtSpawn { get; set; }
        /// <summary>
        /// parent GameObject for the individual cubes
        /// </summary>
        public GameObject TetrominoGo { get; set; }
        /// <summary>
        /// Gets block's rotation state
        /// </summary>
        public int RotationState { get; set; }
        /// <summary>
        /// stores color of the block
        /// </summary>
        public Color Color { get; set; }
    }
}