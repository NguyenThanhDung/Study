using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game2_GameManager : MonoBehaviour
{
    [SerializeField]
    int score;
    [SerializeField]
    Text scoreText;

    public Action<string, int> scoreUpdateHandler;
    public Action<string> endGameHander;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            if (scoreText != null)
                scoreText.text = score.ToString();
            if (scoreUpdateHandler != null)
            {
                Scene scene = SceneManager.GetActiveScene();
                scoreUpdateHandler.Invoke(scene.name, score);
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnDisable()
    {
        scoreUpdateHandler = null;
    }

    public void DecreaseScore()
    {
        Score--;
    }

    public void OnEndGame()
    {
        if (endGameHander != null)
        {
            Scene scene = SceneManager.GetActiveScene();
            endGameHander.Invoke(scene.name);
        }
    }
}
