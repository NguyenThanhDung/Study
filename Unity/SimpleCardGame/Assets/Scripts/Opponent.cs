using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    private List<Card> cards;

    void Start()
    {
        this.cards = new List<Card>();
        GameEvents.OnDeliverCardsToOpponent += GetCards;
    }

    void Destroy()
    {
        GameEvents.OnDeliverCardsToOpponent -= GetCards;
    }

    private void GetCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
            this.cards.Add(cards[i]);
        AlignCards();
        if(GameEvents.OnFinishDeliveringCardsToOpponent != null)
            GameEvents.OnFinishDeliveringCardsToOpponent.Invoke();
    }

    private void AlignCards()
    {
        float dist = 1.1f;
        int count = this.cards.Count;
        for(int i = 0; i < count; i++)
        {
            float x = i * dist - (count - 1) * 0.5f;
            Vector3 position = new Vector3(x, 1f, 3f);
            this.cards[i].MoveTo(position);
        }
    }
}
