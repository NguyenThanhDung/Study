using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float timeToMaxSpeed;

    public float Speed
    {
        get;
        private set;
    }

    void Start()
    {
        this.Speed = 0f;
    }

    void Update()
    {
        if (!Input.GetMouseButton(0) && this.Speed < this.maxSpeed)
        {
            this.Speed += this.maxSpeed / this.timeToMaxSpeed * Time.deltaTime;
        }
    }

    public void DeductSpeed(float steeringVolume)
    {
        // 45               -> 30
        // steeringVolume   -> deductSpeed
        float deductSpeed = steeringVolume * 30f / 45f;

        // 2s           -> deductSpeed
        // deltaTime    -> deltaDeductSpeed
        float deltaDeductSpeed = deductSpeed / 2f * Time.deltaTime;

        this.Speed = Mathf.Max(5f, this.Speed - deltaDeductSpeed);
    }
}
