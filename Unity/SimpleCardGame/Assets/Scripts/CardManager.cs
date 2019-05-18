using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    [SerializeField] GameObject cardPrefab;

    private const int MAX_CARD_COUNT = 10;

    private List<GameObject> cards;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        this.cards = new List<GameObject>();
        GameEvents.OnGameStart += OnGameStart;
    }

    void Destroy()
    {
        GameEvents.OnGameStart -= OnGameStart;
    }

    private void OnGameStart()
    {
        for (int i = 0; i < MAX_CARD_COUNT; i++)
        {
            GameObject card = Instantiate(this.cardPrefab);
            card.transform.position = new Vector3(i - 5f, 0f, i * 0.1f - 0.5f);
            card.transform.parent = this.transform;
            this.cards.Add(card);
        }
    }
}
