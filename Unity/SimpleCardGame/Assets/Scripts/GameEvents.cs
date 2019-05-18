using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action OnGameStart;
    public static Action<Card> OnSelectCard;
    public static Action OnPlayerFinishSelectingCard;
    public static Action<List<Card>> OnDeliverCardToOpponent;
}
