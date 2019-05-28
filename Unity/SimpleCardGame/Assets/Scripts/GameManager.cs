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
        GameEvents.OnStartGame += OnGameStart;
        GameEvents.OnHumanFinishSelectingCards += DeliverCardsToOpponent;
        GameEvents.OnFinishDeliveringCardsToComputer += StartPlaying;
        GameEvents.OnPlayerPlayCard += OnPlayerPlayCard;
        GameEvents.OnFinishedPlacingCard += StartCardBattle;
        GameEvents.OnEndGame += OnEndGame;
    }

    void Destroy()
    {
        GameEvents.OnStartGame -= OnGameStart;
        GameEvents.OnHumanFinishSelectingCards -= DeliverCardsToOpponent;
        GameEvents.OnFinishDeliveringCardsToComputer -= StartPlaying;
        GameEvents.OnPlayerPlayCard -= OnPlayerPlayCard;
        GameEvents.OnFinishedPlacingCard -= StartCardBattle;
        GameEvents.OnEndGame -= OnEndGame;
    }

    private void OnGameStart()
    {
        this.defendCard = null;
        this.attackCard = null;
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
    }

    private void StartCardBattle()
    {
        StartCoroutine(VerivyCardBattle());
    }

    private IEnumerator VerivyCardBattle()
    {
        if (this.defendCard == null)
        {
            this.defendCard = this.attackCard;
            yield return new WaitForSeconds(1f);
            this.gameState = GameState.HumanTurn;
            GameEvents.OnStartTurn.Invoke(PlayerType.Human);
        }
        else
        {
            GameEvents.OnCardBattleStart.Invoke(this.attackCard, this.defendCard);
            while (!this.defendCard.IsDie)
            {
                yield return new WaitForSeconds(1f);
                SwapBattle();
                GameEvents.OnCardBattleStart.Invoke(this.attackCard, this.defendCard);
            }

            yield return new WaitForSeconds(1f);

            if (GameEvents.OnCardDie != null)
                GameEvents.OnCardDie.Invoke(this.defendCard);

            if (this.defendCard.OwnedPlayer == PlayerType.Human)
            {
                this.defendCard = this.attackCard;
                this.gameState = GameState.HumanTurn;

                yield return new WaitForSeconds(1f);
                if (GameEvents.OnStartTurn != null)
                    GameEvents.OnStartTurn.Invoke(PlayerType.Human);
            }
            else
            {
                this.defendCard = this.attackCard;
                this.gameState = GameState.ComputerTurn;

                yield return new WaitForSeconds(1f);
                if (GameEvents.OnStartTurn != null)
                    GameEvents.OnStartTurn.Invoke(PlayerType.Computer);
            }
        }
    }

    private void SwapBattle()
    {
        Card temp = this.attackCard;
        this.attackCard = this.defendCard;
        this.defendCard = temp;
    }

    private void OnEndGame(PlayerType playerType)
    {
        Debug.Log("Winner: " + playerType.ToString());
    }
}
