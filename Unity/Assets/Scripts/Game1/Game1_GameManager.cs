using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1_GameManager : MonoBehaviour
{
    [SerializeField]
    int score;
    [SerializeField]
    Text scoreText;

    public Action<string, int> scoreUpdateHandler;

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
                scoreUpdateHandler.Invoke("Game1", score);
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

    public void IncreaseScore()
    {
        Score++;
    }
}