using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState
    {
        get;
        private set;
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        this.gameState = GameState.Idle;
        GameEvents.OnGameStart += OnGameStart;
        GameEvents.OnHumanFinishSelectingCards += DeliverCardsToOpponent;
        GameEvents.OnFinishDeliveringCardsToComputer += StartPlaying;
        GameEvents.OnComputerPlayCard += WaitForUserToPlay;
    }

    void Destroy()
    {
        GameEvents.OnGameStart -= OnGameStart;
        GameEvents.OnHumanFinishSelectingCards -= DeliverCardsToOpponent;
        GameEvents.OnFinishDeliveringCardsToComputer -= StartPlaying;
        GameEvents.OnComputerPlayCard -= WaitForUserToPlay;
    }

    private void OnGameStart()
    {
        this.gameState = GameState.DeliverCardsToHuman;
    }

    private void DeliverCardsToOpponent()
    {
        this.gameState = GameState.DeliverCardsToComputer;
    }

    private void StartPlaying()
    {
        this.gameState = GameState.ComputerTurn;
        StartCoroutine(StartOpponentTurn());
    }

    private IEnumerator StartOpponentTurn()
    {
        yield return new WaitForSeconds(1f);
        if(GameEvents.OnStartCopmuterTurn != null)
            GameEvents.OnStartCopmuterTurn.Invoke();
    }

    private void WaitForUserToPlay(Card card)
    {
        this.gameState = GameState.HumanTurn;
    }
}
