using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected List<Card> cards;

    public virtual void Start()
    {
        this.cards = new List<Card>();
        GameEvents.OnCardDie += RemoveCard;
        GameEvents.OnEndGame += ReturnCard;
    }

    public virtual void Destroy()
    {
        GameEvents.OnCardDie -= RemoveCard;
        GameEvents.OnEndGame -= ReturnCard;
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

    private void ReturnCard(PlayerType winner)
    {
        if (this.cards.Count > 0)
        {
            GameEvents.OnReturnCards.Invoke(this.cards);
            this.cards.Clear();
        }
    }
}
