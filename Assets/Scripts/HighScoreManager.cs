using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private HighScoreData highScore;
    public Text score;
    private Timer timer;

    public SaveHighScoreToFile saveSystem;

    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer();

        highScore = saveSystem.Load();
        score.text = "High Score = " + highScore.score;

        GameStarted();
        
        //// Test save
        //saveSystem.Save(data);

        //// Test load
        //HighScoreData loadedData = saveSystem.Load();
        ////Debug.Log("loaded score = " + loadedData.score);
    }

    // Update is called once per frame
    void Update()
    {
        // User can click X to save score
        if (Input.GetKeyDown(KeyCode.X))
        {
            saveSystem.Save(highScore);
        }
    }

    void GameStarted()
    {
        // Start Timer
        timer.StartTimer();
    }

    public void GameWon()
    {
        // Stop Timer
        float timerScore = timer.StopTimer();

        // Submit Score
        highScore.SubmitScore(timerScore);

        // Update UI
        score.text = "High Score = " + highScore.score;
    }

}

