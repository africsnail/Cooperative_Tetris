using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // VARIABLES
    public static bool IsPaused;

    // Background
    private Renderer _backgroundMaterial;
    public Material materialMenu;
    public Material materialGame;
    
    // Pause menu
    private GameObject _canvas;
    private Canvas _canvasCanvas;
    private AudioSource _musicMusic;
    private Text[] _menuItem;
    private GameObject[] _menu;
    private int _selectedIndex;
    private Text _menuItemSelected;

    private int _menuItemCount;

    // Game Over menu
    public bool isPausedGameOver;
    private GameObject _gameOverCanvas;
    private Canvas _gameOverCanvasCanvas;
    private Text[] _gameOverMenuItem;
    private GameObject[] _gameOverMenu;
    private int _gameOverSelectedIndex;
    private Text _gameOverMenuItemSelected;
    private int _gameOverMenuItemCount;
    private int _sizeActiveBlocks;

    private GameObject[,] _animationCube;
    private GameObject[,] _animationCube2;


    private void Start()
    {
        _backgroundMaterial = GetComponent<Renderer>();
        InitializeMenu();
        InitializeGameOverMenu();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == false && TileMap.IsGameOver == false)
            {
                //Time.timeScale = 0f;
                IsPaused = true;
                _sizeActiveBlocks = Blocks.Tetrominos.Find(block => block.IsActive).RGrid.GetUpperBound(0);
                _canvasCanvas.enabled = true;
                _backgroundMaterial.material = materialMenu;
                _musicMusic.Pause();
                StartCoroutine(MenuOpenAnimation(TileMap.gridWidth - 1, TileMap.gridHeight - 1));
                GetRenderer(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
            }

            else
            {
                //Time.timeScale = 1f;
                IsPaused = false;
                _canvasCanvas.enabled = false;
                _backgroundMaterial.material = materialGame;
                _musicMusic.Play();
                GetRenderer(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
                ClearAnimationCubes(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
            }
        }

        if (TileMap.IsGameOver && isPausedGameOver == false)
        {
            IsPaused = true;
            isPausedGameOver = true;
            _gameOverCanvasCanvas.enabled = true;
            _backgroundMaterial.material = materialMenu;
        }

        if (IsPaused || isPausedGameOver)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isPausedGameOver)
                {
                    _gameOverMenuItemSelected.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                    GameOverMenuScroll("up");
                }
                else if (IsPaused)
                {
                    _menuItemSelected.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                    MenuScroll("up");
                }
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (isPausedGameOver)
                {
                    _gameOverMenuItemSelected.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                    GameOverMenuScroll("down");
                }
                else if (IsPaused)
                {
                    _menuItemSelected.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                    MenuScroll("down");
                }
            }


            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                if (_selectedIndex == 2 || _gameOverSelectedIndex == 2)
                {
                    Application.Quit();
                    Debug.Log("Quitting");
                }

                if (_selectedIndex == 1 && isPausedGameOver == false)
                {
                    RestartGame();
                }

                if (_gameOverSelectedIndex == 1 && isPausedGameOver)
                {
                    RestartGameOver();
                }
            }


            if (isPausedGameOver)
                _gameOverMenuItemSelected.color = new Color(94f / 255f, 92f / 255f, 214f / 255f);
            else if (IsPaused)
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

    void GameOverMenuScroll(string direction)
    {
        if (direction == "up")
            _gameOverSelectedIndex -= 1;
        if (direction == "down")
            _gameOverSelectedIndex += 1;

        if (_gameOverSelectedIndex > _gameOverMenuItemCount - 1)
            _gameOverSelectedIndex = 1;
        if (_gameOverSelectedIndex < 1)
            _gameOverSelectedIndex = _gameOverMenuItemCount - 1;
        _gameOverMenuItemSelected = _gameOverMenuItem[_gameOverSelectedIndex];

        Debug.Log(_menuItemCount + ", " + _gameOverSelectedIndex);
    }

    private void InitializeMenu()
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
        _backgroundMaterial.material = materialGame;
    }

    private void InitializeGameOverMenu()
    {
        _gameOverSelectedIndex = 1;
        _gameOverCanvas = transform.GetChild(1).gameObject;
        _gameOverMenuItemCount = _gameOverCanvas.transform.childCount;
        // Creating GameObject array menu
        _gameOverMenu = new GameObject[_gameOverMenuItemCount];
        _gameOverMenuItem = new Text[_gameOverMenuItemCount];

        // Creating each menu item
        for (int x = 0; x < _gameOverCanvas.transform.childCount; x++)
        {
            _gameOverMenu[x] = _gameOverCanvas.transform.GetChild(x).gameObject;
            _gameOverMenuItem[x] = _gameOverMenu[x].GetComponent<Text>();
        }

        _gameOverMenuItemSelected = _gameOverMenuItem[_gameOverSelectedIndex];
        _gameOverCanvasCanvas = _gameOverCanvas.GetComponent<Canvas>();
        _gameOverCanvasCanvas.enabled = false;
        _backgroundMaterial.material = materialGame;
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

    private void RestartGame()
    {
        // Clear currently active falling blocks
        Blocks.Tetrominos.Find(block => block.IsActive).TetrominoGo.transform.position = Blocks.SpawnArea;
        TileMap.GameOver(false);

        // Clear all grid cubes
        for (var x = 1; x < TileMap.gridWidth - 1; x++)
        for (var y = 1; y < TileMap.gridHeight - 1; y++)
        {
            if (TileMap.MovementGrid.GridCube[x, y] != null)
                DestroyImmediate(TileMap.MovementGrid.GridCube[x, y]);
            if (TileMap.GameOverCube[x, y] != null)
                StartCoroutine(GameOverCleanup(x, y));
        }

        IsPaused = false;
        GetRenderer(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
        Blocks.Tetrominos.Find(block => block.IsActive).IsActive = false;

        Blocks.ActiveSpawn = true;

        // Clear held block
        if (Blocks.Tetrominos.Exists(block => block.IsHold))
            Blocks.Tetrominos.Find(block => block.IsHold).IsHold = false;
        Blocks.HoldType = null;
        Destroy(Blocks.HoldBlock);

        // Clear preview block
        Destroy(Blocks.PreviewBlock);

        Debug.Log("Restarting");

        _canvasCanvas.enabled = false;
        _backgroundMaterial.material = materialGame;
        _musicMusic.Stop();
        _musicMusic.Play();

        ClearAnimationCubes(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
    }

    private void RestartGameOver()
    {
        GetRenderer(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
        TileMap.GameOver(false);
        // Clear all grid cubes
        for (var x = 1; x < TileMap.gridWidth - 1; x++)
        for (var y = 1; y < TileMap.gridHeight - 1; y++)
        {
            if (TileMap.MovementGrid.GridCube[x, y] != null)
                DestroyImmediate(TileMap.MovementGrid.GridCube[x, y]);
            if (TileMap.GameOverCube[x, y] != null)
                StartCoroutine(GameOverCleanup(x, y));
        }

        IsPaused = false;
        isPausedGameOver = false;
        TileMap.IsGameOver = false;
        GetRenderer(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
        Blocks.ActiveSpawn = true;

        // Clear held block
        if (Blocks.Tetrominos.Exists(block => block.IsHold))
            Blocks.Tetrominos.Find(block => block.IsHold).IsHold = false;
        Blocks.HoldType = null;
        Destroy(Blocks.HoldBlock);

        // Clear preview block
        Destroy(Blocks.PreviewBlock);

        Debug.Log("Restarting");

        _gameOverCanvasCanvas.enabled = false;
        _backgroundMaterial.material = materialGame;
        _musicMusic.Stop();
        _musicMusic.Play();
    }


    private void GetRenderer(int w, int h)
    {
        var animationRenderer = new Renderer[w][];
        for (int index = 0; index < w; index++)
        {
            animationRenderer[index] = new Renderer[h];
        }

        var animationRenderer2 = new Renderer[_sizeActiveBlocks + 1][];
        for (int index = 0; index < _sizeActiveBlocks + 1; index++)
        {
            animationRenderer2[index] = new Renderer[_sizeActiveBlocks + 1];
        }

        var animationCollider = new Collider[w][];
        for (int index = 0; index < w; index++)
        {
            animationCollider[index] = new Collider[h];
        }

        var animationCollider2 = new Collider[_sizeActiveBlocks + 1][];
        for (int index = 0; index < _sizeActiveBlocks + 1; index++)
        {
            animationCollider2[index] = new Collider[_sizeActiveBlocks + 1];
        }

        for (var x = 1; x < w; x++)
        for (var y = 1; y < h; y++)
        {
            if (TileMap.MovementGrid.GridCube[x, y] != null)
            {
                animationRenderer[x][y] = TileMap.MovementGrid.GridCube[x, y].GetComponent<Renderer>();
                animationRenderer[x][y].enabled = !IsPaused;
                animationCollider[x][y] = TileMap.MovementGrid.GridCube[x, y].GetComponent<Collider>();
                animationCollider[x][y].enabled = !IsPaused;
            }
        }

        for (var x = 0; x <= _sizeActiveBlocks; x++)
        for (var y = 0; y <= _sizeActiveBlocks; y++)
        {
            if (Blocks.Tetrominos.Exists(block => block.IsActive))
            {
                if (Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y] != null)
                {
                    animationRenderer2[x][y] = Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y]
                        .GetComponent<Renderer>();
                    animationRenderer2[x][y].enabled = !IsPaused;
                    animationCollider2[x][y] = Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y]
                        .GetComponent<Collider>();
                    animationCollider2[x][y].enabled = !IsPaused;
                }
            }
        }
    }

    private static IEnumerator GameOverCleanup(int x, int y)
    {
        Debug.Log("Starting line clear coroutine");

        {
            while (TileMap.GameOverCube[x, y].transform.position[1] > -10)
            {
                Debug.Log("waiting");
                yield return null;
            }

            Debug.Log("Coroutine has concluded");
            Destroy(TileMap.GameOverCube[x, y]);
        }
    }

    private IEnumerator MenuOpenAnimation(int w, int h)
    {
        _animationCube = new GameObject[w, h];
        _animationCube2 = new GameObject[_sizeActiveBlocks + 1, _sizeActiveBlocks + 1];
        for (var x = 1; x < w; x++)
        for (var y = 1; y < h; y++)
        {
            if (TileMap.MovementGrid.GridCube[x, y] != null)
            {
                _animationCube[x, y] = Instantiate(TileMap.MovementGrid.GridCube[x, y]);
                _animationCube[x, y].name = "Animation cube (Grid) " + x + "_" + y;
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
                _animationCube2[x, y].name = "Animation cube (Blocks) " + x + "_" + y;
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