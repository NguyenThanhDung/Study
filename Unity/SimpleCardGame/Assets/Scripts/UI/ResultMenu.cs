using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] GameObject display;

    void OnEnable()
    {
        GameEvents.OnEndGame += OnEndGame;
    }

    void OnDisable()
    {
        GameEvents.OnEndGame -= OnEndGame;
    }

    public void Retry()
    {

    }

    private void OnEndGame(PlayerType winner)
    {
        this.display.SetActive(true);
    }
}
