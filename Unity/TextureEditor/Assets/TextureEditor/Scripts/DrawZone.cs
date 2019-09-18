using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawZone : MonoBehaviour
{
    [SerializeField] DrawableObject drawableObjectPrefab;

    private DrawableObject drawableObject;

    public void LoadDrawableObject()
    {
        this.drawableObject = Instantiate<DrawableObject>(drawableObjectPrefab, this.transform);
    }

    public void SaveDrawableObject()
    {
        this.drawableObject.SaveTextureToFile();
    }
}
