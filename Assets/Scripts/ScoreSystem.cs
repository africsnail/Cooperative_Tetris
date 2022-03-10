using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static float Score;

    //SCORING
    public static int CurrentLevel;
    public static int CurrentAction;
    public static int LinesPerLevel;
    public static int IsTSpinLastMove;
    public static int IsTSpin;

    // Start is called before the first frame update
    void Start()
    {
        IsTSpin = 0;
        IsTSpinLastMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}