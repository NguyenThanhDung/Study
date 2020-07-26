using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] GameObject display;
    [SerializeField] TMP_Text humanResult;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Color winColor;    // 0BAE2A
    [SerializeField] Color loseColor;   // AD0B17

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

        this.humanResult.color = (winner == PlayerType.Human) ? winColor : loseColor;
        this.humanResult.text = (winner == PlayerType.Human) ? "YOU WIN" : "YOU LOSE";

        this.scoreText.text = Human.Instance.Score.ToString() + "\n" + Computer.Instance.Score.ToString();

        this.display.SetActive(true);
    }
}
