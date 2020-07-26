using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Transform display;

    private Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        GameEvents.OnCardBattleStart += TriggerLaser;
    }

    void Destroy()
    {
        GameEvents.OnCardBattleStart -= TriggerLaser;
    }

    private void TriggerLaser(Card attacker, Card defender)
    {
        this.display.position = attacker.transform.position;
        if (attacker.OwnedPlayer == PlayerType.Human)
            this.display.position -= new Vector3(this.display.localScale.x * 0.5f, 0f, 0f);
        else
            this.display.position += new Vector3(this.display.localScale.x * 0.5f, 0f, 0f);
        
        this.animator.enabled = true;
        this.animator.Play("LaserScaling", -1, 0f);
    }
}
