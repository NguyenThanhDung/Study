using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Card> cards;

    void Start()
    {
        this.cards = new List<Card>();
        GameEvents.OnSelectCard += OnSelectCard;
    }

    void Destroy()
    {
        GameEvents.OnSelectCard -= OnSelectCard;
    }

    private void OnSelectCard(Card card)
    {
        card.MarkOwnByPlayer();
        this.cards.Add(card);
        AlignCards();
    }

    private void AlignCards()
    {
        float dist = 1.1f;
        int count = this.cards.Count;
        for(int i = 0; i < count; i++)
        {
            float x = i * dist - (count - 1) * 0.5f;
            Vector3 position = new Vector3(x, 1f, -3f);
            this.cards[i].MoveTo(position);
        }
    }
}
