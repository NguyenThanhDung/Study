using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Idle,
    DeliverCardsToPlayer,
    DeliverCardsToOpponent,
    Playing
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
    }

    void Destroy()
    {
        GameEvents.OnGameStart -= OnGameStart;
        GameEvents.OnPlayerFinishSelectingCards -= DeliverCardsToOpponent;
        GameEvents.OnFinishDeliveringCardsToOpponent -= StartPlaying;
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
        this.gameState = GameState.Playing;
    }
}
