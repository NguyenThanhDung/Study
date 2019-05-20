using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] TextMeshPro attackText;
    [SerializeField] TextMeshPro healthText;

    private bool isOwnedByPlayer;
    private int attackPoint;
    private int healthPoint;

    public int ID { get; private set; }

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

    void Start()
    {
        this.isOwnedByPlayer = false;
    }

    void OnEnable()
    {
        GameEvents.OnOpponentPlayCard += Play;
        GameEvents.OnUserPlayCard += Play;
    }

    void OnDisable()
    {
        GameEvents.OnOpponentPlayCard -= Play;
        GameEvents.OnUserPlayCard -= Play;
    }

    public void Initialize()
    {
        this.ID = CardManager.Instance.GenerateCardID();
        this.AttackPoint = Random.Range(1, 10);
        this.HealthPoint = Random.Range(1, 10);
    }

    public void MarkOwnByPlayer()
    {
        this.isOwnedByPlayer = true;
    }

    public void MoveToDesk(int slotId, int slotCount)
    {
        float x = slotId * 1.1f - (slotCount - 1) * 0.5f;
        if (this.isOwnedByPlayer)
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

    private void Play(Card card)
    {
        if (card.ID == this.ID)
            MoveToBattleZone();
    }

    private void MoveToBattleZone()
    {
        if (this.isOwnedByPlayer)
            this.transform.position = new Vector3(1f, 1f, 0f);
        else
            this.transform.position = new Vector3(-1f, 1f, 0f);
        this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
