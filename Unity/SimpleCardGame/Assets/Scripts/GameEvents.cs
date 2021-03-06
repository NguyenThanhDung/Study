﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action OnStartGame;
    public static Action<Card> OnHumanObtainCard;
    public static Action<Card> OnFinishSelectingCard;
    public static Action OnHumanFinishSelectingCards;
    public static Action<List<Card>> OnDeliverCardsToComputer;
    public static Action OnFinishDeliveringCardsToComputer;
    public static Action<PlayerType> OnStartTurn;
    public static Action<PlayerType, Card> OnPlayerPlayCard;
    public static Action OnFinishedPlacingCard;
    public static Action<Card /*attacker*/, Card /*defender*/> OnCardBattleStart;
    public static Action<Card> OnCardDie;
    public static Action<PlayerType> OnEndGame;
    public static Action<List<Card>> OnReturnCards;
}
