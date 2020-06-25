using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemaingTime : MonoBehaviour
{
    [SerializeField] Text days;
    [SerializeField] Text hours;
    [SerializeField] Text minutes;
    [SerializeField] Text seconds;

    void Update()
    {
        var timeSpan = GameManager.Instance.ReleaseDate - DateTime.Now;
        this.days.text = timeSpan.ToString("dd");
        this.hours.text = timeSpan.ToString("hh");
        this.minutes.text = timeSpan.ToString("mm");
        this.seconds.text = timeSpan.ToString("ss");
    }
}
