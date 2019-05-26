using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Player
{
    public static Player Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public override void Start()
    {
        this.playerType = PlayerType.Human;
        base.Start();
        GameEvents.OnHumanObtainCard += AddCard;
        GameEvents.OnStartTurn += OnStartTurn;
    }

    public override void Destroy()
    {
        base.Destroy();
        GameEvents.OnHumanObtainCard -= AddCard;
        GameEvents.OnStartTurn -= OnStartTurn;
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

    private void OnStartTurn(PlayerType playerType)
    {
        if(playerType == PlayerType.Human && this.cards.Count == 0)
        {
            if(GameEvents.OnEndGame != null)
                GameEvents.OnEndGame.Invoke(PlayerType.Computer);
        }
    }
}
