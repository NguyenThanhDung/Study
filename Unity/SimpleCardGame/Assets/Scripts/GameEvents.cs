using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action OnGameStart;
    public static Action<Card> OnSelectCard;
}
