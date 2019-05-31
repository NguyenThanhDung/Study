using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject scorePanel;
    [SerializeField] TMP_Text humanScoreText;
    [SerializeField] TMP_Text computerScoreText;

    void Start()
    {
        StartCoroutine(ShowScore());
    }

    public void StartGame()
    {
        if (GameEvents.OnStartGame != null)
            GameEvents.OnStartGame.Invoke();
    }

    private IEnumerator ShowScore()
    {
        yield return new WaitForSeconds(0.3f);
        this.humanScoreText.text = Human.Instance.Score.ToString();
        this.computerScoreText.text = Computer.Instance.Score.ToString();
        this.scorePanel.SetActive(true);
    }
}
