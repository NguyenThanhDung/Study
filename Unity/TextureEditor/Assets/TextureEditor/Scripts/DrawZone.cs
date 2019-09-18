using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawZone : MonoBehaviour
{
    [SerializeField] GameObject drawableObjectPrefab;

    public void LoadDrawableObject()
    {
        GameObject drawableObject = Instantiate(drawableObjectPrefab, this.transform);
    }
}
