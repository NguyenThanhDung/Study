using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] GameObject display;
    [SerializeField] TMP_Text humanResult;
    [SerializeField] TMP_Text scoresText;

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
        if (GameEvents.OnStartGame != null)
            GameEvents.OnStartGame.Invoke();
    }

    private void OnEndGame(PlayerType winner)
    {
        StartCoroutine(SetContent(winner));
    }

    private IEnumerator SetContent(PlayerType winner)
    {
        yield return new WaitForSeconds(0.5f);
        this.humanResult.text = (winner == PlayerType.Human) ? "YOU WIN" : "YOU LOSE";
        this.scoresText.text = "YOU " + Human.Instance.Score + "\nCOMPUTER " + Computer.Instance.Score;
        this.display.SetActive(true);
    }
}
