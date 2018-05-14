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

    }

    public void IncreaseScore()
    {
        Score++;
    }
}