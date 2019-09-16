using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DrawableTarget : MonoBehaviour
{
    [SerializeField] DrawableTexture drawbleTexture;

    void Start()
    {
        // MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        // Texture2D texture = (Texture2D)meshRenderer.material.mainTexture;
        Texture2D texture = drawbleTexture.texture;
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "/DrawableTarget.png", bytes);
        Debug.Log("Texture saved.");
    }
}
