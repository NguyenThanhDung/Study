using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Card> cards;

    void Start()
    {
        this.cards = new List<Card>();
        GameEvents.OnSelectACard += AddCard;
    }

    void Destroy()
    {
        GameEvents.OnSelectACard -= AddCard;
    }

    private void AddCard(Card card)
    {
        card.MarkOwnByPlayer();
        this.cards.Add(card);
        AlignCards();
        if(GameEvents.OnFinishSelectingACard != null)
            GameEvents.OnFinishSelectingACard.Invoke(card);
        if(this.cards.Count >= 5)
            StartCoroutine(FinishSelectingCards());
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

    private IEnumerator FinishSelectingCards()
    {
        yield return new WaitForSeconds(1f);
        if(GameEvents.OnPlayerFinishSelectingCards != null)
            GameEvents.OnPlayerFinishSelectingCards.Invoke();
    }
}
