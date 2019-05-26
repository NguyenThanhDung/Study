using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    [SerializeField] List<Card> cards;
    [SerializeField] CardData[] cardData;

    private const int MAX_CARD_COUNT = 10;

    private int cardID;
    private Animator animator;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
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
    }

    private void OnGameStart()
    {
        List<int> indexPool = new List<int>();
        for (int i = 0; i < MAX_CARD_COUNT; i++)
            indexPool.Add(i);
        for (int i = 0; i < MAX_CARD_COUNT; i++)
        {
            int indexOfIndexPool = Random.Range(0, indexPool.Count);
            int selectedIndex = indexPool[indexOfIndexPool];
            this.cards[i].Initialize(this.cardData[selectedIndex]);
            indexPool.RemoveAt(indexOfIndexPool);
        }
        this.animator.SetTrigger("Mix");
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
        foreach (Card card in cards)
            this.cards.Add(card);
    }
}
