using UnityEngine;
using UnityEngine.UI;

namespace Tetris
{
    /// <summary>
    ///     Class used for each menu
    /// </summary>
    public class SubMenu
    {
        /// <summary>
        ///     Gets the Canvas's parent GameObject
        /// </summary>
        public GameObject Canvas { get; set; }

        /// <summary>
        ///     Gets the Canvas
        /// </summary>
        public Canvas CanvasCanvas { get; set; }

        /// <summary>
        ///     Gets the Text of a menu item
        /// </summary>
        public Text[] MenuItem { get; set; }

        /// <summary>
        ///     Gets the GameObject of a menu item
        /// </summary>
        public GameObject[] Menu { get; set; }

        /// <summary>
        ///     Gets index of a currently selected <see cref="MenuItem" />
        /// </summary>
        public int SelectedIndex { get; set; } = 1;

        /// <summary>
        ///     Gets the Text of a currently selected <see cref="MenuItem" />
        /// </summary>
        public Text MenuItemSelected { get; set; }

        /// <summary>
        ///     Gets the number of <see cref="MenuItem" />s in the submenu
        /// </summary>
        public int MenuItemCount { get; set; }

        /// <summary>
        ///     Gets menu's pause state
        /// </summary>
        public bool IsPaused { get; set; }
    }
}