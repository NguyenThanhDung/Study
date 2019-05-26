using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected PlayerType playerType;
    protected string scoreSaveKey;
    protected List<Card> cards;

    public int Score
    {
        get;
        protected set;
    }

    public virtual void Start()
    {
        this.cards = new List<Card>();
        this.scoreSaveKey = (this.playerType == PlayerType.Human) ? "ScoreHuman" : "ScoreComputer";
        LoadData();
        GameEvents.OnCardDie += RemoveCard;
        GameEvents.OnEndGame += OnEndGame;
    }

    public virtual void Destroy()
    {
        GameEvents.OnCardDie -= RemoveCard;
        GameEvents.OnEndGame -= OnEndGame;
    }

    protected void LoadData()
    {
        this.Score = PlayerPrefs.GetInt(this.scoreSaveKey, 0);
    }

    protected void SaveData()
    {
        PlayerPrefs.SetInt(this.scoreSaveKey, this.Score);
    }

    protected void AlignCards()
    {
        int count = this.cards.Count;
        for (int i = 0; i < count; i++)
            this.cards[i].MoveToDesk(i, count);
    }

    private void RemoveCard(Card card)
    {
        for (int i = 0; i < this.cards.Count; i++)
        {
            if (card.ID == this.cards[i].ID)
            {
                this.cards.RemoveAt(i);
                break;
            }
        }
    }

    protected void OnEndGame(PlayerType winner)
    {
        if (this.cards.Count > 0)
        {
            GameEvents.OnReturnCards.Invoke(this.cards);
            this.cards.Clear();
        }
        if(winner == this.playerType)
            this.Score++;
        SaveData();
    }
}
