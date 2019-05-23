using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    [SerializeField] Card cardPrefab;
    [SerializeField] CardData[] cardData;

    private const int MAX_CARD_COUNT = 10;

    private int cardID;
    private List<Card> cards;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Initialize();
        GameEvents.OnStartGame += OnGameStart;
        GameEvents.OnFinishSelectingCard += RemoveSelectedCard;
        GameEvents.OnHumanFinishSelectingCards += OnDeliverCardsToOpponent;
        GameEvents.OnCardDie += ReceiveDiedCard;
        GameEvents.OnReturnCards += OnReceiveRemainingCards;
    }

    void Destroy()
    {
        GameEvents.OnStartGame -= OnGameStart;
        GameEvents.OnFinishSelectingCard -= RemoveSelectedCard;
        GameEvents.OnHumanFinishSelectingCards -= OnDeliverCardsToOpponent;
        GameEvents.OnCardDie -= ReceiveDiedCard;
        GameEvents.OnReturnCards -= OnReceiveRemainingCards;
    }

    public int GenerateCardID()
    {
        int currentCardID = this.cardID;
        cardID++;
        return currentCardID;
    }

    private void Initialize()
    {
        this.cardID = 0;
        this.cards = new List<Card>();
        for (int i = 0; i < MAX_CARD_COUNT; i++)
        {
            Card card = Instantiate(this.cardPrefab);
            card.transform.parent = this.transform;
            card.gameObject.SetActive(false);
            card.Initialize(this.cardData[i]);
            this.cards.Add(card);
        }
    }

    private void OnGameStart()
    {
        for (int i = 0; i < this.cards.Count; i++)
        {
            this.cards[i].transform.position = new Vector3(i * 0.5f - 2.5f, i * 0.1f + 1.5f, 0f);
            this.cards[i].transform.rotation = Quaternion.Euler(-90f, 180f, 0f);
            this.cards[i].gameObject.SetActive(true);
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
        if (GameEvents.OnDeliverCardsToComputer != null)
            GameEvents.OnDeliverCardsToComputer.Invoke(this.cards);
        this.cards.Clear();
    }

    private void ReceiveDiedCard(Card card)
    {
        this.cards.Add(card);
    }

    private void OnReceiveRemainingCards(List<Card> cards)
    {
        foreach(Card card in cards)
            this.cards.Add(card);
    }
}
