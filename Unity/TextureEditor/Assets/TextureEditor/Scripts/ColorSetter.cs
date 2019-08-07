using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] Image targetImage;

    public void OnSetColor()
    {
        Image thisImage = this.GetComponent<Image>();
        Color thisColor = thisImage.color;
        targetImage.color = thisColor;
    }
}
