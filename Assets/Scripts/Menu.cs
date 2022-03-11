using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // VARIABLES
    private int _sizeActiveBlocks;

    // Background
    private Renderer _backgroundMaterial;
    public Material materialMenu;
    public Material materialGame;

    // Audio
    private AudioSource _musicMusic;
    private int _volume;

    // Menus
    public static SubMenu[] Menus { get; set; }

    // In-game settings
    private Slider _volumeSlider;
    private Text _volumePercentage;

    // Pause animation
    private GameObject[,] _animationCube;
    private GameObject[,] _animationCube2;


    private void Start()
    {
        Menus = new SubMenu[3];
        for (int x = 0; x < 3; x++)
            Menus[x] = new SubMenu();
        _backgroundMaterial = GetComponent<Renderer>();
        InitializeMenu(id: 0, menuName: "Pause menu");
        InitializeMenu(id: 1, menuName: "Game Over menu");
        InitializeMenu(id: 2, menuName: "In-game settings");
    }

    // Update is called once per frame
    private void Update()
    {
        MenuControls();
    }

    void MenuControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Menus[2].IsPaused)
        {
            if (Menus[0].IsPaused == false && TileMap.IsGameOver == false)
            {
                //Time.timeScale = 0f;
                Menus[0].IsPaused = true;
                _sizeActiveBlocks = Blocks.Tetrominos.Find(block => block.IsActive).RGrid.GetUpperBound(0);
                Menus[0].CanvasCanvas.enabled = true;
                _backgroundMaterial.material = materialMenu;
                _musicMusic.Pause();
                StartCoroutine(MenuOpenAnimation(TileMap.gridWidth - 1, TileMap.gridHeight - 1));
                GetRenderer(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
            }
            else
            {
                Menus[0].IsPaused = false;
                Menus[0].CanvasCanvas.enabled = false;
                _backgroundMaterial.material = materialGame;
                _musicMusic.Play();
                GetRenderer(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
                ClearAnimationCubes(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
            }
        }

        if (TileMap.IsGameOver)
        {
            Menus[1].IsPaused = true;
            Menus[1].CanvasCanvas.enabled = true;
            _backgroundMaterial.material = materialMenu;
        }

        // Menu scrolling
        sbyte id = 0;
        for (sbyte x = 0; x < 3; x++)
            if (Menus[x].IsPaused)
                id = x;


        if (Menus[id].IsPaused)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Menus[id].MenuItemSelected.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                MenuScroll(id, "up");
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Menus[id].MenuItemSelected.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                MenuScroll(id, "down");
            }


            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                if (id == 0)
                {
                    if (Menus[0].SelectedIndex == 3)
                    {
                        Application.Quit();
                        Debug.Log("Quitting");
                    }

                    if (Menus[0].SelectedIndex == 2)
                    {
                        RestartGame();
                    }

                    if (Menus[0].SelectedIndex == 1)
                    {
                        Menus[0].IsPaused = false;
                        Menus[2].IsPaused = true;
                        Menus[0].CanvasCanvas.enabled = false;
                        Menus[2].CanvasCanvas.enabled = true;
                    }
                }
                else if (id == 1)
                {
                    if (Menus[1].SelectedIndex == 2)
                    {
                        Application.Quit();
                        Debug.Log("Quitting");
                    }

                    if (Menus[1].SelectedIndex == 1)
                    {
                        RestartGameOver();
                    }
                }
            }

            if (id == 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    _volume -= 10;
                    if (_volume < 0)
                        _volume = 0;
                    _volumePercentage.text = _volume + "%";
                    _volumeSlider.value = _volume / 100f;
                    _musicMusic.volume = _volume / 100f;
                    PlayerPrefs.SetInt("volume", _volume);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    _volume += 10;
                    if (_volume > 100)
                        _volume = 100;
                    _volumePercentage.text = _volume + "%";
                    _volumeSlider.value = _volume / 100f;
                    _musicMusic.volume = _volume / 100f;
                    PlayerPrefs.SetInt("volume", _volume);
                }

                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) ||
                    Input.GetKeyDown(KeyCode.Space))
                {
                    Menus[0].IsPaused = true;
                    Menus[2].IsPaused = false;
                    Menus[0].CanvasCanvas.enabled = true;
                    Menus[2].CanvasCanvas.enabled = false;
                }
            }

            if (Menus[id].IsPaused)
                Menus[id].MenuItemSelected.color = new Color(94f / 255f, 92f / 255f, 214f / 255f);
        }
    }


    void MenuScroll(int id, string direction)
    {
        if (direction == "up")
            Menus[id].SelectedIndex -= 1;
        if (direction == "down")
            Menus[id].SelectedIndex += 1;

        if (Menus[id].SelectedIndex > Menus[id].MenuItemCount - 1)
            Menus[id].SelectedIndex = 1;
        if (Menus[id].SelectedIndex < 1)
            Menus[id].SelectedIndex = Menus[id].MenuItemCount - 1;
        Menus[id].MenuItemSelected = Menus[id].MenuItem[Menus[id].SelectedIndex];
    }

    void InitializeMenu(int id, string menuName)
    {
        Menus[id].Canvas = GameObject.Find(menuName);
        Menus[id].MenuItemCount = Menus[id].Canvas.transform.childCount;
        // Creating GameObject array menu
        Menus[id].Menu = new GameObject[Menus[id].MenuItemCount];
        Menus[id].MenuItem = new Text[Menus[id].MenuItemCount];
        // Creating each menu item
        for (int x = 0; x < Menus[id].Canvas.transform.childCount; x++)
        {
            Menus[id].Menu[x] = Menus[id].Canvas.transform.GetChild(x).gameObject;
            Menus[id].MenuItem[x] = Menus[id].Menu[x].GetComponent<Text>();
        }

        Menus[id].MenuItemSelected = Menus[id].MenuItem[Menus[id].SelectedIndex];
        Menus[id].CanvasCanvas = Menus[id].Canvas.GetComponent<Canvas>();
        _musicMusic = GetComponent<AudioSource>();
        Menus[id].CanvasCanvas.enabled = false;
        _backgroundMaterial.material = materialGame;

        // Un-pause menu
        Menus[id].IsPaused = false;
        if (id == 2)
        {
            // Read volume from preferences and set the needed variables
            _volumePercentage = Menus[2].MenuItem[1].transform.GetChild(0).GetComponent<Text>();
            _volumeSlider = Menus[2].MenuItem[1].transform.GetChild(1).GetComponent<Slider>();
            _volume = PlayerPrefs.GetInt("volume");
            _volumeSlider.value = PlayerPrefs.GetInt("volume") / 100f;
            _volumePercentage.text = PlayerPrefs.GetInt("volume") + "%";
            _musicMusic.volume = PlayerPrefs.GetInt("volume") / 100f;
        }
    }

    void ClearAnimationCubes(int w, int h)
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
            if (TileMap.MovementTileMap.GridCube[x, y] != null)
                DestroyImmediate(TileMap.MovementTileMap.GridCube[x, y]);
            if (TileMap.GameOverCube[x, y] != null)
                StartCoroutine(GameOverCleanup(x, y));
        }

        Menus[0].IsPaused = false;
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

        Menus[0].CanvasCanvas.enabled = false;
        _backgroundMaterial.material = materialGame;
        _musicMusic.Stop();
        _musicMusic.Play();

        // Reset scoring
        ScoreSystem.IsTSpinLastMove = 0;
        ScoreSystem.LinesCleared = 0;
        ScoreSystem.CurrentLevel = 1;
        ScoreSystem.Score = 0;
        ScoreSystem.IsGameOverScoreSet = false;
        ScoreSystem.NewRecordText.enabled = false;

        ClearAnimationCubes(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
    }

    void RestartGameOver()
    {
        GetRenderer(TileMap.gridWidth - 1, TileMap.gridHeight - 1);
        TileMap.GameOver(false);
        // Clear all grid cubes
        for (var x = 1; x < TileMap.gridWidth - 1; x++)
        for (var y = 1; y < TileMap.gridHeight - 1; y++)
        {
            if (TileMap.MovementTileMap.GridCube[x, y] != null)
                DestroyImmediate(TileMap.MovementTileMap.GridCube[x, y]);
            if (TileMap.GameOverCube[x, y] != null)
                StartCoroutine(GameOverCleanup(x, y));
        }

        Menus[0].IsPaused = false;
        Menus[1].IsPaused = false;
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

        // Reset scoring
        ScoreSystem.IsTSpinLastMove = 0;
        ScoreSystem.LinesCleared = 0;
        ScoreSystem.CurrentLevel = 1;
        ScoreSystem.Score = 0;
        ScoreSystem.IsGameOverScoreSet = false;
        ScoreSystem.NewRecordText.enabled = false;

        Menus[1].CanvasCanvas.enabled = false;
        _backgroundMaterial.material = materialGame;
        _musicMusic.Stop();
        _musicMusic.Play();
    }


    void GetRenderer(int w, int h)
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
            if (TileMap.MovementTileMap.GridCube[x, y] != null)
            {
                animationRenderer[x][y] = TileMap.MovementTileMap.GridCube[x, y].GetComponent<Renderer>();
                animationRenderer[x][y].enabled = !Menus[0].IsPaused;
                animationCollider[x][y] = TileMap.MovementTileMap.GridCube[x, y].GetComponent<Collider>();
                animationCollider[x][y].enabled = !Menus[0].IsPaused;
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
                    animationRenderer2[x][y].enabled = !Menus[0].IsPaused;
                    animationCollider2[x][y] = Blocks.Tetrominos.Find(block => block.IsActive).CubeGo[x, y]
                        .GetComponent<Collider>();
                    animationCollider2[x][y].enabled = !Menus[0].IsPaused;
                }
            }
        }
    }

    private static IEnumerator GameOverCleanup(int x, int y)
    {
        {
            while (TileMap.GameOverCube[x, y].transform.position[1] > -10)
            {
                yield return null;
            }

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
            if (TileMap.MovementTileMap.GridCube[x, y] != null)
            {
                _animationCube[x, y] = Instantiate(TileMap.MovementTileMap.GridCube[x, y]);
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