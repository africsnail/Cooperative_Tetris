using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    
    //SCORING
    public static int CurrentLevel;
    public static float CurrentAction;
    public static float Score;
    private static float _highScore;
    public static float LinesCleared;
    public static int IsTSpinLastMove;
    public static bool IsB2B;
    private Text _scoreText;
    private Text _levelText;
    private Text _scoreGameOverText;
    private Text _highScoreText;
    public static Text NewRecordText;
    public static bool IsGameOverScoreSet;

    // Start is called before the first frame update
    void Start()
    {
        // Initializing
        IsTSpinLastMove = 0;
        LinesCleared = 0;
        CurrentLevel = 1;
        Score = 0;

        _highScore = new float();
        _highScore = PlayerPrefs.GetFloat("high_score");
        NewRecordText = GameObject.Find("New record").GetComponent<Text>();
        _scoreText = GameObject.Find("Score").GetComponent<Text>();
        _levelText = GameObject.Find("Level").GetComponent<Text>();
        _scoreGameOverText = GameObject.Find("Game Over score").GetComponent<Text>();
        _highScoreText = GameObject.Find("High score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: " + Score;
        _levelText.text = "Level: " + CurrentLevel;

        if (TileMap.IsGameOver && IsGameOverScoreSet == false)
        {
            if (Score > _highScore)
            {
                NewRecordText.enabled = true;
                _highScore = Score;
                PlayerPrefs.SetFloat("high_score", _highScore);
            }
            else
            {
                _scoreGameOverText.text = "Score: \n" + Score;
            }
            _scoreGameOverText.text = "Score: \n" + Score;
            _highScoreText.text = "High score: \n" + _highScore;
            IsGameOverScoreSet = true;
        }
    }

    public static void ScoreCounter()
    {

        LinesCleared += CurrentAction;
        if (LinesCleared >= 5 * CurrentLevel)
        {
            LinesCleared -= 5 * CurrentLevel;
            CurrentLevel += 1;
        }

        if (CurrentLevel == 16)
            CurrentLevel = 15;
        

        Blocks.TimeToFall = (float)Math.Pow((0.8f - (CurrentLevel - 1f) * 0.007f), CurrentLevel - 1f);

        CurrentAction = 0;
        IsTSpinLastMove = 0;
        
        Debug.Log("Lines cleared: " + LinesCleared + " Current score: " + Score + " Current level: " + CurrentLevel + " Current fall speed: " + Blocks.TimeToFall);
    }
    }