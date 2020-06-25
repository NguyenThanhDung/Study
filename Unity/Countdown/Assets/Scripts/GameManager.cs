using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int year;
    [SerializeField] private int month;
    [SerializeField] private int day;
    [SerializeField] private int hour;
    [SerializeField] private int minute;

    public DateTime ReleaseDate { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        this.ReleaseDate = new DateTime(this.year, this.month, this.day, this.hour, this.minute, 0);
    }
}
