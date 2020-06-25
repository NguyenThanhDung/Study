using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemaingTime : MonoBehaviour
{
    private Text text;

    void Start()
    {
        this.text = GetComponent<Text>();
    }

    void Update()
    {
        var timeSpan = GameManager.Instance.ReleaseDate - DateTime.Now;
        var toString = timeSpan.ToString("dd");
        toString += " days ";
        toString += timeSpan.ToString(@"hh\:mm\:ss");
        this.text.text = toString;
    }
}
