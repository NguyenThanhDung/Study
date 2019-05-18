using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        if (GameEvents.OnGameStart != null)
            GameEvents.OnGameStart.Invoke();
    }
}
