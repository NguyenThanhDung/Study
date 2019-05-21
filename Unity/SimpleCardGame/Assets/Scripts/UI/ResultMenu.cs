using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] GameObject display;
    [SerializeField] TMP_Text winnerText;

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
        this.winnerText.text = winner.ToString();
        this.display.SetActive(true);
    }
}
