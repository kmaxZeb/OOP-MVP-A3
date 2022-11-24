using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   // Allows class data to be saved to file
public class HighScoreData
{
    // vars
    public float score;

    // constructor (same name as class and no return type)
    public HighScoreData()
    {
        // allows constructor to be overridden
        score = float.MaxValue; // Highest score is lowest in this game, so in this case MaxValue means no score
    }

    public HighScoreData(float prevScore)
    {
        score = prevScore;
    }

    public void SubmitScore(float newScore)
    {
        if (newScore < score)
        {
            score = newScore;
        }
    }
}
