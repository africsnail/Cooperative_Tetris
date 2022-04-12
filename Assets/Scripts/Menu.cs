using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Tetris.Blocks;
using static Tetris.TileMap;

namespace Tetris
{
    /// <summary>
    /// Manages all menus and their behavior
    /// </summary>
    public class Menu : MonoBehaviour
    {
        // Key bindings
        private static readonly int ColorId = Shader.PropertyToID("_Color");
        public Material materialMenu;
        public Material materialGame;
        public GameObject blockPrefab2;

        // Pause animation
        private GameObject[,] _animationCube;

        // Background
        private Renderer _backgroundMaterial;

        // Audio
        private AudioSource _musicMusic;
        private int _volume;
        private Text _volumePercentage;

        // In-game settings
        private Slider _volumeSlider;

        // Animation toggle
        public static int Animations = 1;
        private Text _animationToggle;

        // Menus
        public static SubMenu[] Menus { get; private set; }
        private GameObject[][,] AnimationCube2 { get; set; }

        // Multiplayer
        public int PlayerCount { get; set; }
        public static bool NeedToAddPlayer { get; set; }
        public static bool NeedToRemovePlayer { get; set; }

        private static GameObject Border { get; set; }

        private void Awake()
        {
            Menus = new SubMenu[3];
            for (var x = 0; x < 3; x++)
                Menus[x] = new SubMenu();
            _backgroundMaterial = GetComponent<Renderer>();
            InitializeMenu(0, "Pause menu");
            InitializeMenu(1, "Game Over menu");
            InitializeMenu(2, "In-game settings");

            PlayerCount = 1;
            materialGame.mainTextureScale = new Vector2(10 * PlayerCount + 2, 21);
        }

        private void Update()
        {
            MenuControls();
        }

        /// <summary>
        /// Controls for all menus
        /// </summary>
        private void MenuControls()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !Menus[2].IsPaused)
            {
                if (Menus[0].IsPaused == false && IsGameOver == false)
                {
                    //Time.timeScale = 0f;
                    Menus[0].IsPaused = true;
                    Menus[0].CanvasCanvas.enabled = true;
                    _backgroundMaterial.material = materialMenu;
                    _musicMusic.Pause();
                    if (Animations == 1)
                        StartCoroutine(MenuOpenAnimation(GridWidth - 1, GridHeight));
                    GetRenderer(GridWidth - 1, GridHeight);
                }
                else
                {
                    Menus[0].IsPaused = false;
                    Menus[0].CanvasCanvas.enabled = false;
                    _backgroundMaterial.material = materialGame;
                    _musicMusic.Play();
                    GetRenderer(GridWidth - 1, GridHeight);
                    if (Animations == 1)
                        ClearAnimationCubes(GridWidth - 1, GridHeight);
                }
            }

            if (IsGameOver)
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
                        if (Menus[0].SelectedIndex == 5 && PlayerCount > 1)
                        {
                            PlayerCount -= 1;
                            SwitchPlayerCount("remove");
                        }

                        if (Menus[0].SelectedIndex == 4 && PlayerCount < 3)
                        {
                            PlayerCount += 1;
                            SwitchPlayerCount("add");
                        }

                        if (Menus[0].SelectedIndex == 3)
                        {
                            Application.Quit();
                            Debug.Log("Quitting");
                        }

                        if (Menus[0].SelectedIndex == 2) RestartGame();

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

                        if (Menus[1].SelectedIndex == 1) RestartGame();
                    }
                }
                // In-game settings
                if (id == 2)
                {
                    if (Menus[2].SelectedIndex == 1)
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
                    }
                    else if (Menus[2].SelectedIndex == 2)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                        {
                            if (Animations == 1)
                            {
                                Animations = 0;
                                _animationToggle.text = "OFF";
                                _animationToggle.color = Color.red;
                            }
                            else
                            {
                                Animations = 1;
                                _animationToggle.text = "ON";
                                _animationToggle.color = Color.green;
                                
                            }

                            PlayerPrefs.SetInt("animations", Animations);
                        }
                    }
                    else if (Menus[2].SelectedIndex == 3)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                        {
                            Menus[0].IsPaused = true;
                            Menus[2].IsPaused = false;
                            Menus[0].CanvasCanvas.enabled = true;
                            Menus[2].CanvasCanvas.enabled = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Escape))
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

        /// <summary>
        /// Switches selected item in a menu
        /// </summary>
        /// <param name="id">Menu id</param>
        /// <param name="direction">Direction of scrolling</param>
        private void MenuScroll(int id, string direction)
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
        
        /// <summary>
        /// Initializes a menu and needed variables
        /// </summary>
        /// <param name="id">menu id</param>
        /// <param name="menuName">menu's name</param>
        private void InitializeMenu(int id, string menuName)
        {
            Menus[id].Canvas = GameObject.Find(menuName);
            Menus[id].MenuItemCount = Menus[id].Canvas.transform.childCount;
            // Creating GameObject array menu
            Menus[id].Menu = new GameObject[Menus[id].MenuItemCount];
            Menus[id].MenuItem = new Text[Menus[id].MenuItemCount];
            // Creating each menu item
            for (var x = 0; x < Menus[id].Canvas.transform.childCount; x++)
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
                // Read audio preferences and set the needed variables
                _volumePercentage = Menus[2].MenuItem[1].transform.GetChild(0).GetComponent<Text>();
                _volumeSlider = Menus[2].MenuItem[1].transform.GetChild(1).GetComponent<Slider>();
                _animationToggle = Menus[2].MenuItem[2].transform.GetChild(0).GetComponent<Text>();
                _volume = PlayerPrefs.GetInt("volume");
                _volumeSlider.value = PlayerPrefs.GetInt("volume") / 100f;
                _volumePercentage.text = PlayerPrefs.GetInt("volume") + "%";
                _musicMusic.volume = PlayerPrefs.GetInt("volume") / 100f;
                // Read animation preferences and set the needed variables
                Animations = PlayerPrefs.GetInt("animations");
                if (Animations == 1)
                {
                    _animationToggle.text = "ON";
                    _animationToggle.color = Color.green;
                }
                else
                {
                    _animationToggle.text = "OFF";
                    _animationToggle.color = Color.red;
                }
            }
        }
        /// <summary>
        /// Clears menu open animation cubes 
        /// </summary>
        /// <param name="w">width of the grid</param>
        /// <param name="h">height of the grid</param>
        private void ClearAnimationCubes(int w, int h)
        {
            foreach (var block in Tetrominos.Where(block => block.IsActive))
                for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                {
                    if (x > 0 && y > 0)
                        if (_animationCube[x, y] != null) Destroy(_animationCube[x, y]);
                    
                    if (x < block.Size && y < block.Size)
                    {
                        if (AnimationCube2[block.Id][x, y] != null)
                            Destroy(AnimationCube2[block.Id][x, y]);
                    }
                }
        }
        /// <summary>
        /// Restarts the game
        /// </summary>
        private void RestartGame()
        {
            // Return falling blocks to spawn and rotate them to default state
            foreach (var block in Tetrominos.Where(block => block.IsActive))
            {
                while (block.RotationState != 0)
                {
                    block.AtSpawn = true;
                    Rotation.Rotate(block.Id, "Ac", 0, 0);
                    block.RotationState -= 1;
                    block.AtSpawn = false;
                    Debug.Log("rotating ac");
                }
                block.TetrominoGo.transform.position = SpawnArea;
            }

            // Clear grid cubes
            ClearGridCubes();
            
            // Clear animation cubes
            if (!IsGameOver)
                if (Animations == 1)
                    ClearAnimationCubes(GridWidth - 1, GridHeight);

            // Clear all GameOver animation cubes
            if (IsGameOver && Animations == 1)
                for (var x = 1; x < GridWidth - 1; x++)
                for (var y = 1; y < GridHeight; y++)
                    if (GameOverCube[x, y] != null)
                        StartCoroutine(GameOverCleanup(x, y));

            // Unpause menus and reset BGM
            Menus[0].IsPaused = false;
            Menus[1].IsPaused = false;
            Menus[0].CanvasCanvas.enabled = false;
            Menus[1].CanvasCanvas.enabled = false;
            IsGameOver = false;
            _backgroundMaterial.material = materialGame;
            _musicMusic.Stop();
            _musicMusic.Play();

            GetRenderer(GridWidth - 1, GridHeight);

            foreach (var block in Tetrominos.Where(block => block.IsActive))
                block.IsActive = false;

            for (var c = 0; c < PlayerIds.Count; c++)
            {
                ActiveSpawn[c] = true;
                // Clear preview block
                Destroy(PreviewBlock[c]);
                Destroy(HoldBlock[c]);
                // Reset hold variables
                HoldType[c] = null;
                HoldUsed[c] = false;
            }

            // Clear held block
            foreach (var block in Tetrominos.Where(block => block.IsHold))
                block.IsHold = false;

            // Reset scoring
            ScoreSystem.IsTSpinLastMove = 0;
            ScoreSystem.LinesCleared = 0;
            ScoreSystem.CurrentLevel = 1;
            ScoreSystem.Score = 0;
            ScoreSystem.IsGameOverScoreSet = false;
            ScoreSystem.NewRecordText.enabled = false;
            
            Debug.Log("Restarting");
        }
        /// <summary>
        /// Switches player count
        /// </summary>
        /// <param name="type">add or remove</param>
        private void SwitchPlayerCount(string type)
        {
            Debug.Log("Switching player count");

            // Reset game state
            RestartGame();

            // Prepare background texture and camera position
            var transform1 = transform;
            transform1.localScale = new Vector3(PlayerCount * 10 + 2, 21, 1);
            transform1.position = new Vector3(5 * PlayerCount - 0.5f, 9, 1);
            transform.GetComponent<Renderer>().material.mainTextureScale = new Vector2(10 * PlayerCount + 2, 21);
            materialGame.mainTextureScale = new Vector2(10 * PlayerCount + 2, 21);
            if (PlayerCount == 3)
            {
                GameObject.Find("Main Camera").transform.position =
                    new Vector3((5 + (PlayerCount - 1) * 5) - 0.5f, 15, -22 - (PlayerCount - 2) * 5);
            }
            else
                GameObject.Find("Main Camera").transform.position =
                    new Vector3((5 + (PlayerCount - 1) * 5) - 0.5f, 15, -22);

            GameObject.Find("Area Light").transform.position =
                new Vector3(4.11f + (PlayerCount - 1) * 5, 9.23f, -23.74f);

            // Destroy all grid cubes and border cubes
            Border = new GameObject {name = "Border"};
            for (var x = 0; x < GridWidth; x++)
            for (var y = 0; y < GridHeight; y++)
                if (MovementTileMap.GridCube[x, y] != null)
                    DestroyImmediate(MovementTileMap.GridCube[x, y]);

            // Define new grid width and holding area location
            GridWidth = 10 * PlayerCount + 2;
            for (var playerCount = 0; playerCount < PlayerIds.Count; playerCount++)
                HoldArea[playerCount] = new Vector3(TileMap.GridWidth + 1, 17 - 5 * playerCount, 0);

            // Prepare new grid
            MovementTileMap.Color = null;
            MovementTileMap.IsActive = null;
            MovementTileMap.IsClear = null;
            MovementTileMap.GridCube = null;
            MovementTileMap.CollisionMap = null;
            MovementTileMap = new SubTileMap
            {
                Color = new Color[GridWidth, GridHeight],
                IsActive = new bool[GridWidth, GridHeight],
                IsClear = new bool[GridWidth, GridHeight],
                GridCube = new GameObject[GridWidth, GridHeight],
                CollisionMap = new bool[GridWidth, GridHeight]
            };
            PlayGrid = new int[GridWidth, GridHeight];
            LineToAnimate = new GameObject[GridWidth, GridHeight];
            for (var x = 0; x < GridWidth; x++)
            for (var y = 0; y < GridHeight - 5; y++)
                if (x < 1 || x > GridWidth - 2 || y < 1)
                {
                    PlayGrid[x, y] = 1;
                    if (PlayGrid[x, y] == 1)
                    {
                        MovementTileMap.GridCube[x, y] = Instantiate(blockPrefab2);
                        MovementTileMap.GridCube[x, y].name = "Border cube";
                        MovementTileMap.GridCube[x, y].transform.parent = Border.transform;
                        MovementTileMap.GridCube[x, y].transform.position = new Vector3(x - 1, y - 1, 0);
                        var cubeRenderer = MovementTileMap.GridCube[x, y].GetComponent<Renderer>();
                        cubeRenderer.material.SetColor(ColorId, Color.gray);
                        var cubeCollider = MovementTileMap.GridCube[x, y].GetComponent<Collider>();
                        DestroyImmediate(cubeCollider);
                        MovementTileMap.Color[x, y] = Color.black;
                        MovementTileMap.IsActive[x, y] = true;
                        MovementTileMap.IsClear[x, y] = false;
                        MovementTileMap.CollisionMap[x, y] = false;
                    }
                }

            if (type == "add")
            {
                NeedToAddPlayer = true;
                GameObject.Find("Holding area").transform.Translate(Vector3.right * 10f);
                foreach (var block in Tetrominos.Where(block => block.Id == 0))
                {
                    for (var x = 0; x < block.Size; x++)
                    for (var y = 0; y < block.Size; y++)
                    {
                        if (block.RGrid[x, y] == 1)
                        {
                            block.CubeGo[x, y].GetComponent<Renderer>().material.SetColor(ColorId, Color.blue);
                            block.Color = Color.blue;
                        }
                    }
                }
            }
            else if (type == "remove")
            {
                NeedToRemovePlayer = true;
                GameObject.Find("Holding area").transform.Translate(Vector3.left * 10f);
                if (PlayerCount == 1)
                {
                    OriginalColors(0);
                }
            }

            // Change keybindings
            if (PlayerCount == 1)
            {
                KeybindRight[0] = "right";
                KeybindLeft[0] = "left";
                KeybindSoftDrop[0] = "down";
            }
            else if (PlayerCount == 2)
            {
                KeybindRight[0] = "l";
                KeybindLeft[0] = "j";
                KeybindSoftDrop[0] = "k";
                Rotation.KeybindRotateC[0] = "d";
                KeybindRight[1] = "[6]";
                KeybindLeft[1] = "[4]";
                KeybindSoftDrop[1] = "[5]";
                KeybindHardDrop[1] = "[0]";
                KeybindHold[1] = "[+]";
                Rotation.KeybindRotateC[1] = "right";
                Rotation.KeybindRotateAc[1] = "left";
            }
            else if (PlayerCount == 3)
            {
                KeybindRight[0] = "g";
                KeybindLeft[0] = "d";
                KeybindSoftDrop[0] = "f";
                Rotation.KeybindRotateC[0] = "s";
                KeybindRight[1] = "l";
                KeybindLeft[1] = "j";
                KeybindSoftDrop[1] = "k";
                KeybindHardDrop[1] = "right alt";
                KeybindHold[1] = "right shift";
                Rotation.KeybindRotateC[1] = "n";
                Rotation.KeybindRotateAc[1] = "b";
            }
        }

        /// <summary>
        /// Gets renderer of all locked and active cubes and disables it if a menu is open
        /// </summary>
        /// <param name="w">grid width</param>
        /// <param name="h">grid height</param>
        private void GetRenderer(int w, int h)
        {
            var playerId = 0;
            foreach (var block in Tetrominos.Where(block => block.IsActive))
            {
                var animationRenderer2 = new Renderer[PlayerIds.Count][][];
                animationRenderer2[playerId] = new Renderer[block.Size][];
                for (var index = 0; index < block.Size; index++)
                    animationRenderer2[playerId][index] = new Renderer[block.Size];

                var animationCollider2 = new Collider[PlayerIds.Count][][];
                animationCollider2[playerId] = new Collider[block.Size][];
                for (var index = 0; index < block.Size; index++)
                    animationCollider2[playerId][index] = new Collider[block.Size];

                for (var x = 0; x < block.Size; x++)
                for (var y = 0; y < block.Size; y++)
                    if (block.CubeGo[x, y] != null)
                    {
                        animationRenderer2[playerId][x][y] = block.CubeGo[x, y].GetComponent<Renderer>();
                        animationRenderer2[playerId][x][y].enabled = !Menus[0].IsPaused;
                        animationCollider2[playerId][x][y] = block.CubeGo[x, y].GetComponent<Collider>();
                        animationCollider2[playerId][x][y].enabled = !Menus[0].IsPaused;
                    }

                playerId++;
            }

            var animationRenderer = new Renderer[w][];
            for (var index = 1; index < w; index++) animationRenderer[index] = new Renderer[h];

            var animationCollider = new Collider[w][];
            for (var index = 1; index < w; index++) animationCollider[index] = new Collider[h];

            for (var x = 1; x < w; x++)
            for (var y = 1; y < h; y++)
                if (MovementTileMap.GridCube[x, y] != null)
                {
                    animationRenderer[x][y] = MovementTileMap.GridCube[x, y].GetComponent<Renderer>();
                    animationRenderer[x][y].enabled = !Menus[0].IsPaused;
                    animationCollider[x][y] = MovementTileMap.GridCube[x, y].GetComponent<Collider>();
                    animationCollider[x][y].enabled = !Menus[0].IsPaused;
                }
        }

        private static IEnumerator GameOverCleanup(int x, int y)
        {
            {
                while (GameOverCube[x, y].transform.position[1] > -3) yield return null;
                
                Destroy(GameOverCube[x, y]);
                Debug.Log("Cleanup x y:" + x + ", " + y);
            }
        }
        /// <summary>
        /// Makes block fall
        /// </summary>
        /// <param name="w">grid width</param>
        /// <param name="h">grid height</param>
        /// <returns></returns>
        private IEnumerator MenuOpenAnimation(int w, int h)
        {
            Debug.Log("Initializing animation cubes with x: " + w + ", y: " + h);
            _animationCube = new GameObject[w, h];

            for (var x = 1; x < w; x++)
            for (var y = 1; y < h; y++)
                if (MovementTileMap.GridCube[x, y] != null)
                {
                    _animationCube[x, y] = Instantiate(MovementTileMap.GridCube[x, y]);
                    _animationCube[x, y].name = "Animation cube (Grid) " + x + "_" + y;
                    var animationRigidbody = _animationCube[x, y].AddComponent<Rigidbody>();
                    animationRigidbody.AddForce(0, 0, -1, ForceMode.Impulse);
                    animationRigidbody.AddTorque(0, 0, 0.5f, ForceMode.Impulse);
                }

            AnimationCube2 = new GameObject[PlayerIds.Count][,];
            foreach (var block in Tetrominos.Where(block => block.IsActive))
            {
                AnimationCube2[block.Id] = new GameObject[block.Size, block.Size];
                for (var x = 0; x < block.Size; x++)
                for (var y = 0; y < block.Size; y++)
                    if (block.RGrid[x, y] == 1)
                    {
                        AnimationCube2[block.Id][x, y] = Instantiate(Tetrominos.Find(mino => mino.Type == "O").CubeGo[2,2]);
                        var animationRigidbody2 = AnimationCube2[block.Id][x, y].AddComponent<Rigidbody>();
                        AnimationCube2[block.Id][x, y].GetComponent<Renderer>().material.SetColor(ColorId, block.Color);
                        AnimationCube2[block.Id][x, y].transform.position = new Vector3(
                            (int) block.Location[0] + x,
                            (int) block.Location[1] + y - block.Size, 0);
                        AnimationCube2[block.Id][x, y].name = "Animation cube (Blocks) " + x + "_" + y;
                        animationRigidbody2.AddForce(0, 0, -1, ForceMode.Impulse);
                        animationRigidbody2.AddTorque(0, 0, 0.5f, ForceMode.Impulse);
                    }
            }

            var time = new float();
            var duration = 5f;
            while (time < duration)
            {
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}