using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // VARIABLES
    public static bool IsPaused;
    private GameObject _canvas;
    private Canvas _canvasCanvas;
    private AudioSource _musicMusic;
    private Text[] _menuItem;
    private GameObject[] _menu;
    private int _selectedIndex;
    private Text _menuItemSelected;
    private int _menuItemCount;
    private int _sizeActiveBlocks;

    private GameObject[,] _animationCube;
    private GameObject[,] _animationCube2;


    private void Start()
    {
        _selectedIndex = 0;
        _canvas = transform.GetChild(0).gameObject;
        _menuItemCount = _canvas.transform.childCount;
        // Creating GameObject array menu
        _menu = new GameObject[_menuItemCount];
        _menuItem = new Text[_menuItemCount];

        // Creating each menu item
        for (int x = 0; x < _canvas.transform.childCount; x++)
        {
            _menu[x] = _canvas.transform.GetChild(x).gameObject;
            _menuItem[x] = _menu[x].GetComponent<Text>();
        }

        _menuItemSelected = _menuItem[_selectedIndex];
        _canvasCanvas = _canvas.GetComponent<Canvas>();
        _musicMusic = GetComponent<AudioSource>();
        _canvasCanvas.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == false)
            {
                //Time.timeScale = 0f;
                IsPaused = true;
                _sizeActiveBlocks = Blocks.Tetrominos.Find(block => block.IsActive).RGrid.GetUpperBound(0);
                _canvasCanvas.enabled = true;
                _musicMusic.Pause();
                StartCoroutine(MenuOpenAnimation(Grid.gridWidth - 1, Grid.gridHeight - 1));
                GetRenderer(Grid.gridWidth - 1, Grid.gridHeight - 1);
            }
            else
            {
                //Time.timeScale = 1f;
                IsPaused = false;
                _canvasCanvas.enabled = false;
                _musicMusic.Play();
                GetRenderer(Grid.gridWidth - 1, Grid.gridHeight - 1);
                ClearAnimationCubes(Grid.gridWidth - 1, Grid.gridHeight - 1);
            }
        }

        if (IsPaused)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _menuItemSelected.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                MenuScroll("up");
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                _menuItemSelected.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                MenuScroll("down");
            }

            _menuItemSelected.color = new Color(94f / 255f, 92f / 255f, 214f / 255f);
        }
    }

    void MenuScroll(string direction)
    {
        if (direction == "up")
            _selectedIndex -= 1;
        if (direction == "down")
            _selectedIndex += 1;
        if (_selectedIndex > _menuItemCount - 1)
            _selectedIndex = 0;
        if (_selectedIndex < 0)
            _selectedIndex = _menuItemCount - 1;
        _menuItemSelected = _menuItem[_selectedIndex];
    }

    private void ClearAnimationCubes(int w, int h)
    {
        for (var x = 0; x < w; x++)
        for (var y = 0; y < h; y++)
        {
            if (_animationCube[x, y] != null)
            {
                Destroy(_animationCube[x, y]);
            }

            if (x <= _sizeActiveBlocks && y <= _sizeActiveBlocks)
            {
                if (_animationCube2[x, y] != null)
                {
                    Destroy(_animationCube2[x, y]);
                }
            }
        }
    }

    public void GetRenderer(int w, int h)
    {
        var animationRenderer = new Renderer[w, h];
        var animationRenderer2 = new Renderer[_sizeActiveBlocks + 1, _sizeActiveBlocks + 1];
        var animationCollider = new Collider[w, h];
        var animationCollider2 = new Collider[_sizeActiveBlocks + 1, _sizeActiveBlocks + 1];
        for (var x = 1; x < w; x++)
        for (var y = 1; y < h; y++)
        {
            if (Grid.MovementGrid.GridCube[x, y] != null)
            {
                animationRenderer[x, y] = Grid.MovementGrid.GridCube[x, y].GetComponent<Renderer>();
                animationRenderer[x, y].enabled = !IsPaused;
                animationCollider[x, y] = Grid.MovementGrid.GridCube[x, y].GetComponent<Collider>();
                animationCollider[x, y].enabled = !IsPaused;
            }
        }

        for (var x = 0; x <= _sizeActiveBlocks; x++)
        for (var y = 0; y <= _sizeActiveBlocks; y++)
        {
            if (Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y] != null)
            {
                animationRenderer2[x, y] = Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y]
                    .GetComponent<Renderer>();
                animationRenderer2[x, y].enabled = !IsPaused;
                animationCollider2[x, y] = Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y]
                    .GetComponent<Collider>();
                animationCollider2[x, y].enabled = !IsPaused;
            }
        }
    }

    private IEnumerator MenuOpenAnimation(int w, int h)
    {
        _animationCube = new GameObject[w, h];
        _animationCube2 = new GameObject[_sizeActiveBlocks + 1, _sizeActiveBlocks + 1];
        for (var x = 1; x < w; x++)
        for (var y = 1; y < h; y++)
        {
            if (Grid.MovementGrid.GridCube[x, y] != null)
            {
                _animationCube[x, y] = Instantiate(Grid.MovementGrid.GridCube[x, y]);
                var animationRigidbody = _animationCube[x, y].AddComponent<Rigidbody>();
                animationRigidbody.AddForce(0, 0, -1, ForceMode.Impulse);
                animationRigidbody.AddTorque(0, 0, 0.5f, ForceMode.Impulse);
            }
        }

        for (var x = 0; x <= _sizeActiveBlocks; x++)
        for (var y = 0; y <= _sizeActiveBlocks; y++)
        {
            if (Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y] != null)
            {
                _animationCube2[x, y] = Instantiate(Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y]);
                var animationRigidbody2 = _animationCube2[x, y].AddComponent<Rigidbody>();
                _animationCube2[x, y].transform.position += Blocks.Tetrominos.Find(block => block.IsActive)
                    .TetrominoGo.transform.position;
                animationRigidbody2.AddForce(0, 0, -1, ForceMode.Impulse);
                animationRigidbody2.AddTorque(0, 0, 0.5f, ForceMode.Impulse);
            }
        }

        float time = new float();
        float duration = 5f;
        while (time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }
    }
}