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
        if (this.Speed < this.maxSpeed)
        {
            this.Speed += this.maxSpeed / this.timeToMaxSpeed * Time.deltaTime;
        }
    }
}
