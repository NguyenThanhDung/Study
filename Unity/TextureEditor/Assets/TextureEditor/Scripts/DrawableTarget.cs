using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DrawableTarget : MonoBehaviour
{
    [SerializeField] Texture2D templateTexture;

    void Start()
    {
        // MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        // Texture2D texture = (Texture2D)meshRenderer.material.mainTexture;
        // byte[] bytes = texture.EncodeToPNG();
        byte[] bytes = templateTexture.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "/DrawableTarget.png", bytes);
    }
}
