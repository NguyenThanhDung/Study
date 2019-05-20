using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action OnGameStart;
    public static Action<Card> OnHumanObtainCard;
    public static Action<Card> OnFinishSelectingCard;
    public static Action OnHumanFinishSelectingCards;
    public static Action<List<Card>> OnDeliverCardsToComputer;
    public static Action OnFinishDeliveringCardsToComputer;
    public static Action OnStartCopmuterTurn;
    public static Action<Card> OnComputerPlayCard;
    public static Action<Card> OnUserPlayCard;
}
