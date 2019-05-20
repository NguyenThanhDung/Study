using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected List<Card> cards;

    public virtual void Start()
    {
        this.cards = new List<Card>();
    }

    protected void AlignCards()
    {
        int count = this.cards.Count;
        for(int i = 0; i < count; i++)
            this.cards[i].MoveToDesk(i, count);
    }
}
