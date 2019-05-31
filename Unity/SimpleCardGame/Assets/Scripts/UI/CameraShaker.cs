using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] float intensity;
    [SerializeField] float duration;

    private bool isEnable;
    private Vector3 originalPosition;

    void Start()
    {
        this.isEnable = false;
        this.originalPosition = this.transform.position;
        GameEvents.OnCardBattleStart += ShakeCamera;
    }

    void Update()
    {
        if (this.isEnable)
        {
            float x = Random.Range(-intensity, intensity);
            float y = Random.Range(-intensity, intensity);
            this.transform.position = this.originalPosition + new Vector3(x, y, 0f);
        }
        else
        {
            this.transform.position = this.originalPosition;
        }
    }

    void Destroy()
    {
        GameEvents.OnCardBattleStart -= ShakeCamera;
    }

    private void ShakeCamera(Card attacker, Card defender)
    {
        this.isEnable = true;
        StartCoroutine(StopShaking());
    }

    private IEnumerator StopShaking()
    {
        yield return new WaitForSeconds(this.duration);
        this.isEnable = false;
    }
}
