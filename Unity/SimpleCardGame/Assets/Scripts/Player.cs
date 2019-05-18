using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<GameObject> cards;

    void Start()
    {
        this.cards = new List<GameObject>();
        GameEvents.OnSelectCard += OnSelectCard;
    }

    void Destroy()
    {
        GameEvents.OnSelectCard -= OnSelectCard;
    }

    private void OnSelectCard(GameObject card)
    {
        Debug.Log("Select card " + card.GetComponent<Card>().ID.ToString());
        this.cards.Add(card);
    }
}
