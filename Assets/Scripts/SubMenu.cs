using UnityEngine;
using UnityEngine.UI;

public class SubMenu
{
    public GameObject Canvas { get; set; }
    public Canvas CanvasCanvas { get; set; }
    public Text[] MenuItem { get; set; }
    public GameObject[] Menu { get; set; }
    public int SelectedIndex { get; set; } = 1;
    public Text MenuItemSelected { get; set; }
    public int MenuItemCount { get; set; }

    public bool IsPaused { get; set; }
}