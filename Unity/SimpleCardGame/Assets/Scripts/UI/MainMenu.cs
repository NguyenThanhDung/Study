using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        if (GameEvents.OnStartGame != null)
            GameEvents.OnStartGame.Invoke();
    }
}
