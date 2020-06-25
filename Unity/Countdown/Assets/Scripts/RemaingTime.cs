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
        this.text.text = timeSpan.ToString(@"dd\.hh\:mm\:ss");
    }
}
