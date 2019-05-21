using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Player
{
    public override void Start()
    {
        base.Start();
        GameEvents.OnHumanObtainCard += AddCard;
    }

    void Destroy()
    {
        GameEvents.OnHumanObtainCard -= AddCard;
    }

    private void AddCard(Card card)
    {
        card.MarkOwnedByHuman();
        this.cards.Add(card);
        AlignCards();
        if(GameEvents.OnFinishSelectingCard != null)
            GameEvents.OnFinishSelectingCard.Invoke(card);
        if(this.cards.Count >= 5 && GameEvents.OnHumanFinishSelectingCards != null)
            GameEvents.OnHumanFinishSelectingCards.Invoke();
    }
}
