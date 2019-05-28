using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{

    [SerializeField] GameObject display;
    [SerializeField] TextMeshPro attackText;
    [SerializeField] TextMeshPro healthText;
    [SerializeField] AnimationCurve moveAnimCurve;
    [SerializeField] ParticleSystem leftFireParticle;
    [SerializeField] ParticleSystem rightFireParticle;
    [SerializeField] ParticleSystem disappearParticle;

    private CardData initialData;
    private Vector3 startAnimationPosition;
    private Vector3 targetAnimationPosition;
    private Quaternion startAnimationRotation;
    private Quaternion targetAnimationRotation;
    private float startAnimationTime;

    public int ID { get; private set; }
    public PlayerType OwnedPlayer { get; private set; }

    public int AttackPoint
    {
        get;
        private set;
    }

    public int HealthPoint
    {
        get;
        private set;
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
        GameEvents.OnPlayerPlayCard += Play;
        GameEvents.OnCardBattleStart += StartBattle;
        GameEvents.OnCardDie += OnDie;
    }

    void Destroy()
    {
        GameEvents.OnPlayerPlayCard -= Play;
        GameEvents.OnCardBattleStart -= StartBattle;
        GameEvents.OnCardDie -= OnDie;
    }

    public void Initialize(CardData cardData)
    {
        this.ID = CardManager.Instance.GenerateCardID();
        this.initialData = cardData;
        OnStartGame();
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
            this.targetAnimationRotation = Quaternion.Euler(-90f, 180f, 0f);
        }
        StartCoroutine(Moving());
    }

    private void OnStartGame()
    {
        this.AttackPoint = this.initialData.AttackPoint;
        this.HealthPoint = this.initialData.HealthPoint;
        this.attackText.text = this.AttackPoint.ToString();
        this.healthText.text = this.HealthPoint.ToString();
        this.OwnedPlayer = PlayerType.Computer;
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
        StartCoroutine(FinishPlacingCard());
    }

    private void StartBattle(Card attacker, Card defender)
    {
        if (attacker.ID == this.ID)
            EmitFireParticle();
        if (defender.ID == this.ID)
        {
            this.HealthPoint -= attacker.AttackPoint;
            StartCoroutine(UpdateHealthPointText());
        }
    }

    private void OnDie(Card card)
    {
        if (card.ID == this.ID)
        {
            this.display.SetActive(false);
            this.disappearParticle.Play();
        }
    }

    private void EmitFireParticle()
    {
        if (this.OwnedPlayer == PlayerType.Human)
            this.leftFireParticle.Play();
        else
            this.rightFireParticle.Play();
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

    private IEnumerator UpdateHealthPointText()
    {
        yield return new WaitForSeconds(1f);
        this.healthText.text = this.HealthPoint.ToString();
    }

    private IEnumerator FinishPlacingCard()
    {
        yield return new WaitForSeconds(1.5f);
        GameEvents.OnFinishedPlacingCard.Invoke();
    }
}
