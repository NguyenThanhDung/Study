using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action OnGameStart;
    public static Action<Card> OnUserObtainCard;
    public static Action<Card> OnFinishSelectingACard;
    public static Action OnPlayerFinishSelectingCards;
    public static Action<List<Card>> OnDeliverCardsToOpponent;
    public static Action OnFinishDeliveringCardsToOpponent;
    public static Action OnStartOpponentTurn;
    public static Action<Card> OnOpponentPlayCard;
}
