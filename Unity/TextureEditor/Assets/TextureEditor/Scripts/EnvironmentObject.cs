using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    public void IntegrateTexture()
    {
        byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/DrawableTarget.png");
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        Transform child = this.transform.GetChild(0);
        MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material.mainTexture = texture;
    }
}
