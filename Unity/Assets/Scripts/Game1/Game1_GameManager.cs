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

    public UnitedEvent unitedEvents;

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
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (unitedEvents != null)
        {
            Debug.Log("Game1 Score: " + unitedEvents.Score);
            Score = unitedEvents.Score;
            unitedEvents = null;
        }
    }

    public void IncreaseScore()
    {
        Score++;
    }
}