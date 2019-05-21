using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Card attackCard;
    private Card defendCard;

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
        GameEvents.OnPlayerPlayCard += OnPlayerPlayCard;
    }

    void Destroy()
    {
        GameEvents.OnGameStart -= OnGameStart;
        GameEvents.OnHumanFinishSelectingCards -= DeliverCardsToOpponent;
        GameEvents.OnFinishDeliveringCardsToComputer -= StartPlaying;
        GameEvents.OnPlayerPlayCard -= OnPlayerPlayCard;
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
        if (GameEvents.OnStartTurn != null)
            GameEvents.OnStartTurn.Invoke(PlayerType.Computer);
    }

    private void OnPlayerPlayCard(PlayerType playerType, Card card)
    {
        this.attackCard = card;
        StartCoroutine(VerivyCardBattle(playerType));
    }

    private IEnumerator VerivyCardBattle(PlayerType playerType)
    {
        if (this.defendCard == null)
        {
            yield return new WaitForSeconds(1f);
            if (playerType == PlayerType.Computer)
            {
                this.gameState = GameState.HumanTurn;
                GameEvents.OnStartTurn.Invoke(PlayerType.Human);
            }
            else
            {
                this.gameState = GameState.ComputerTurn;
                GameEvents.OnStartTurn.Invoke(PlayerType.Computer);
            }
        }
        else
        {
            this.defendCard.OnAttackedBy(this.attackCard);
            while (!this.defendCard.IsDie)
            {
                yield return new WaitForSeconds(0.5f);
                SwapBattle();
                this.defendCard.OnAttackedBy(this.attackCard);
            }

            yield return new WaitForSeconds(1f);

            if (GameEvents.OnCardDie != null)
                GameEvents.OnCardDie.Invoke(this.defendCard);

            yield return new WaitForSeconds(1f);

            if (this.defendCard.OwnedPlayer == PlayerType.Human)
            {
                this.gameState = GameState.HumanTurn;
                if (GameEvents.OnStartTurn != null)
                    GameEvents.OnStartTurn.Invoke(PlayerType.Human);
            }
            else
            {
                this.gameState = GameState.ComputerTurn;
                if (GameEvents.OnStartTurn != null)
                    GameEvents.OnStartTurn.Invoke(PlayerType.Computer);
            }
        }
        this.defendCard = this.attackCard;
    }

    private void SwapBattle()
    {
        Card temp = this.attackCard;
        this.attackCard = this.defendCard;
        this.defendCard = temp;
    }
}
