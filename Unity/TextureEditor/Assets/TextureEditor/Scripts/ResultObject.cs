using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResultObject : MonoBehaviour
{
    public void Show()
    {
        byte[] bytes = File.ReadAllBytes(TextureEditManager.Instance.CustomizedTexturePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        
        Transform child = this.transform.GetChild(0);
        MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material.mainTexture = texture;
        child.gameObject.SetActive(true);
    }
}
