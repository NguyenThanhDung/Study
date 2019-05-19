using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Idle,
    DeliverCardsToPlayer,
    DeliverCardsToOpponent,
    OpponentTurn,
    UserTurn
}

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
        GameEvents.OnPlayerFinishSelectingCards += DeliverCardsToOpponent;
        GameEvents.OnFinishDeliveringCardsToOpponent += StartPlaying;
        GameEvents.OnOpponentPlayCard += WaitForUserToPlay;
    }

    void Destroy()
    {
        GameEvents.OnGameStart -= OnGameStart;
        GameEvents.OnPlayerFinishSelectingCards -= DeliverCardsToOpponent;
        GameEvents.OnFinishDeliveringCardsToOpponent -= StartPlaying;
        GameEvents.OnOpponentPlayCard -= WaitForUserToPlay;
    }

    private void OnGameStart()
    {
        this.gameState = GameState.DeliverCardsToPlayer;
    }

    private void DeliverCardsToOpponent()
    {
        this.gameState = GameState.DeliverCardsToOpponent;
    }

    private void StartPlaying()
    {
        this.gameState = GameState.OpponentTurn;
        StartCoroutine(StartOpponentTurn());
    }

    private IEnumerator StartOpponentTurn()
    {
        yield return new WaitForSeconds(1f);
        if(GameEvents.OnStartOpponentTurn != null)
            GameEvents.OnStartOpponentTurn.Invoke();
    }

    private void WaitForUserToPlay(Card card)
    {
        this.gameState = GameState.UserTurn;
    }
}
