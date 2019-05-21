using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Player
{
    public override void Start()
    {
        base.Start();
        GameEvents.OnDeliverCardsToComputer += GetCards;
        GameEvents.OnStartTurn += Play;
    }

    void Destroy()
    {
        GameEvents.OnDeliverCardsToComputer -= GetCards;
        GameEvents.OnStartTurn -= Play;
    }

    private void GetCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
            this.cards.Add(cards[i]);
        AlignCards();
        if (GameEvents.OnFinishDeliveringCardsToComputer != null)
            GameEvents.OnFinishDeliveringCardsToComputer.Invoke();
    }

    private void Play(PlayerType playerType)
    {
        if (playerType == PlayerType.Computer)
        {
            int index = Random.Range(0, this.cards.Count);
            if (GameEvents.OnPlayerPlayCard != null)
                GameEvents.OnPlayerPlayCard.Invoke(PlayerType.Computer, this.cards[index]);
        }
    }
}
