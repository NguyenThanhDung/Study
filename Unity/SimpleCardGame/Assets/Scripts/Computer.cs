using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Player
{
    public override void Start()
    {
        base.Start();
        GameEvents.OnDeliverCardsToOpponent += GetCards;
        GameEvents.OnStartOpponentTurn += Play;
    }

    void Destroy()
    {
        GameEvents.OnDeliverCardsToOpponent -= GetCards;
        GameEvents.OnStartOpponentTurn -= Play;
    }

    private void GetCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
            this.cards.Add(cards[i]);
        AlignCards();
        if (GameEvents.OnFinishDeliveringCardsToOpponent != null)
            GameEvents.OnFinishDeliveringCardsToOpponent.Invoke();
    }

    private void Play()
    {
        int index = Random.Range(0, this.cards.Count);
        if (GameEvents.OnOpponentPlayCard != null)
            GameEvents.OnOpponentPlayCard.Invoke(this.cards[index]);
    }
}
