using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Player
{
    public override void Start()
    {
        base.Start();
        GameEvents.OnUserObtainCard += AddCard;
    }

    void Destroy()
    {
        GameEvents.OnUserObtainCard -= AddCard;
    }

    private void AddCard(Card card)
    {
        card.MarkOwnByPlayer();
        this.cards.Add(card);
        AlignCards();
        if(GameEvents.OnFinishSelectingACard != null)
            GameEvents.OnFinishSelectingACard.Invoke(card);
        if(this.cards.Count >= 5 && GameEvents.OnPlayerFinishSelectingCards != null)
            GameEvents.OnPlayerFinishSelectingCards.Invoke();
    }
}
