using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] TextMeshPro attackText;
    [SerializeField] TextMeshPro healthText;

    private int attackPoint;
    private int healthPoint;

    public int ID { get; private set; }
    public PlayerType OwnedPlayer { get; private set; }

    public int AttackPoint
    {
        get
        {
            return this.attackPoint;
        }
        private set
        {
            this.attackPoint = value;
            this.attackText.text = value.ToString();
        }
    }

    public int HealthPoint
    {
        get
        {
            return this.healthPoint;
        }
        private set
        {
            this.healthPoint = value;
            this.healthText.text = value.ToString();
        }
    }

    public bool IsDie
    {
        get
        {
            return this.HealthPoint <= 0;
        }
    }

    void Start()
    {
        this.OwnedPlayer = PlayerType.Computer;
    }

    void OnEnable()
    {
        GameEvents.OnPlayerPlayCard += Play;
        GameEvents.OnCardDie += OnDie;
    }

    void OnDisable()
    {
        GameEvents.OnPlayerPlayCard -= Play;
        GameEvents.OnCardDie -= OnDie;
    }

    public void Initialize(CardData cardData)
    {
        this.ID = CardManager.Instance.GenerateCardID();
        this.AttackPoint = cardData.AttackPoint;
        this.HealthPoint = cardData.HealthPoint;
    }

    public void MarkOwnedByHuman()
    {
        this.OwnedPlayer = PlayerType.Human;
    }

    public void MoveToDesk(int slotId, int slotCount)
    {
        float x = slotId * 1.1f - (slotCount - 1) * 0.5f;
        if (this.OwnedPlayer == PlayerType.Human)
        {
            this.transform.position = new Vector3(x, 1f, -3f);
            this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
        else
        {
            this.transform.position = new Vector3(x, 1f, 3f);
            this.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
    }

    public void OnAttackedBy(Card attackCard)
    {
        this.HealthPoint -= attackCard.AttackPoint;
    }

    private void Play(PlayerType playerType, Card card)
    {
        if (card.ID == this.ID)
            MoveToBattleZone();
    }

    private void MoveToBattleZone()
    {
        if (this.OwnedPlayer == PlayerType.Human)
            this.transform.position = new Vector3(1f, 1f, 0f);
        else
            this.transform.position = new Vector3(-1f, 1f, 0f);
        this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

    private void OnDie(Card card)
    {
        if (card.ID == this.ID)
            StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
