using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] TextMeshPro attackText;
    [SerializeField] TextMeshPro healthText;
    [SerializeField] AnimationCurve moveAnimCurve;

    private CardData initialData;
    private int attackPoint;
    private int healthPoint;
    private Vector3 startAnimationPosition;
    private Vector3 targetAnimationPosition;
    private Quaternion startAnimationRotation;
    private Quaternion targetAnimationRotation;
    private float startAnimationTime;

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
        GameEvents.OnStartGame += ResetPoint;
        GameEvents.OnPlayerPlayCard += Play;
        GameEvents.OnCardDie += OnDie;
    }

    void Destroy()
    {
        GameEvents.OnStartGame -= ResetPoint;
        GameEvents.OnPlayerPlayCard -= Play;
        GameEvents.OnCardDie -= OnDie;
    }

    public void Initialize(CardData cardData)
    {
        this.ID = CardManager.Instance.GenerateCardID();
        this.initialData = cardData;
        ResetPoint();
    }

    public void MarkOwnedByHuman()
    {
        this.OwnedPlayer = PlayerType.Human;
    }

    public void MoveToDesk(int slotId, int slotCount)
    {
        this.startAnimationPosition = this.transform.position;
        this.startAnimationRotation = this.transform.rotation;
        this.startAnimationTime = Time.time;
        float x = slotId * 1.1f - (slotCount - 1) * 0.5f;
        if (this.OwnedPlayer == PlayerType.Human)
        {
            this.targetAnimationPosition = new Vector3(x, 1f, -3f);
            this.targetAnimationRotation = Quaternion.Euler(90f, 0f, 0f);
        }
        else
        {
            this.targetAnimationPosition = new Vector3(x, 1f, 3f);
            this.targetAnimationRotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        StartCoroutine(Moving());
    }

    public void OnAttackedBy(Card attackCard)
    {
        this.HealthPoint -= attackCard.AttackPoint;
    }

    private void ResetPoint()
    {
        this.AttackPoint = this.initialData.AttackPoint;
        this.HealthPoint = this.initialData.HealthPoint;
        this.OwnedPlayer = PlayerType.Computer;
    }

    private IEnumerator Moving()
    {
        float time = Time.time - this.startAnimationTime;
        float curve = this.moveAnimCurve.Evaluate(time);
        while (curve < 1f)
        {
            this.transform.position = Vector3.Lerp(this.startAnimationPosition, this.targetAnimationPosition, curve);
            this.transform.rotation = Quaternion.Lerp(this.startAnimationRotation, this.targetAnimationRotation, curve);
            yield return null;
            time = Time.time - this.startAnimationTime;
            curve = this.moveAnimCurve.Evaluate(time);
        }
    }

    private void Play(PlayerType playerType, Card card)
    {
        if (card.ID == this.ID)
            MoveToBattleZone();
    }

    private void MoveToBattleZone()
    {
        this.startAnimationPosition = this.transform.position;
        this.startAnimationRotation = this.transform.rotation;
        this.startAnimationTime = Time.time;
        
        if (this.OwnedPlayer == PlayerType.Human)
            this.targetAnimationPosition = new Vector3(1f, 1f, 0f);
        else
            this.targetAnimationPosition = new Vector3(-1f, 1f, 0f);
        this.targetAnimationRotation = Quaternion.Euler(90f, 0f, 0f);

        StartCoroutine(Moving());
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
