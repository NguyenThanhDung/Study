using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    [SerializeField] Card cardPrefab;

    private const int MAX_CARD_COUNT = 10;

    private int cardID;
    private List<Card> cards;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        this.cards = new List<Card>();
        GameEvents.OnGameStart += OnGameStart;
        GameEvents.OnFinishSelectingACard += RemoveSelectedCard;
        GameEvents.OnPlayerFinishSelectingCards += OnDeliverCardsToOpponent;
    }

    void Destroy()
    {
        GameEvents.OnGameStart -= OnGameStart;
        GameEvents.OnFinishSelectingACard -= RemoveSelectedCard;
        GameEvents.OnPlayerFinishSelectingCards -= OnDeliverCardsToOpponent;
    }

    public int GenerateCardID()
    {
        int currentCardID = this.cardID;
        cardID++;
        return currentCardID;
    }

    private void OnGameStart()
    {
        this.cardID = 0;
        for (int i = 0; i < MAX_CARD_COUNT; i++)
        {
            Card card = Instantiate(this.cardPrefab);
            card.transform.position = new Vector3(i * 0.5f - 2.5f, i * 0.1f + 1.5f, 0f);
            card.transform.rotation = Quaternion.Euler(-90f, 180f, 0f);
            card.transform.parent = this.transform;
            card.Initialize();
            this.cards.Add(card);
        }
    }

    private void RemoveSelectedCard(Card card)
    {
        this.cards.Remove(card);
    }

    private void OnDeliverCardsToOpponent()
    {
        StartCoroutine(DeliverCardsToOpponent());
    }

    private IEnumerator DeliverCardsToOpponent()
    {
        yield return new WaitForSeconds(1f);
        if(GameEvents.OnDeliverCardsToOpponent != null)
            GameEvents.OnDeliverCardsToOpponent.Invoke(this.cards);
        this.cards.Clear();
    }
}
