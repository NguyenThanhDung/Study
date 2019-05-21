using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        if (GameEvents.OnGameStart != null)
            GameEvents.OnGameStart.Invoke();
    }
}
