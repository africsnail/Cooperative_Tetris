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
    public static float LinesCleared;
    public static int IsTSpinLastMove;
    public static int IsTSpin;
    public static bool IsB2B;
    private GameObject _scoreGo;
    private Text _scoreText;
    private GameObject _levelGo;
    private Text _levelText;

    // Start is called before the first frame update
    void Start()
    {
        IsTSpin = 0;
        IsTSpinLastMove = 0;
        LinesCleared = 0;
        CurrentLevel = 1;
        Score = 0;
        
        _scoreGo = GameObject.Find("Score");
        _scoreText = _scoreGo.GetComponent<Text>();
        _levelGo = GameObject.Find("Level");
        _levelText = _levelGo.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: " + Score;
        _levelText.text = "Level: " + CurrentLevel;
    }

    public static void ScoreCounter()
    {

        LinesCleared += CurrentAction;
        if (LinesCleared >= 5 * CurrentLevel)
            CurrentLevel += 1;

        if (CurrentLevel == 16)
            CurrentLevel = 15;
        

        Blocks.TimeToFall = (float)Math.Pow((0.8f - (CurrentLevel - 1f) * 0.007f), CurrentLevel - 1f);

        CurrentAction = 0;
        IsTSpin = 0;
        IsTSpinLastMove = 0;
        
        Debug.Log("Current score: " + Score + " Current level: " + CurrentLevel + " Current fall speed: " + Blocks.TimeToFall);
    }
    }