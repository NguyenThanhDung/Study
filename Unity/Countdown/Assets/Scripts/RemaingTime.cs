using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemaingTime : MonoBehaviour
{
    void Start()
    {
        var text = GetComponent<Text>();
        text.text = GameManager.Instance.ReleaseDate.ToShortDateString();
    }
}
