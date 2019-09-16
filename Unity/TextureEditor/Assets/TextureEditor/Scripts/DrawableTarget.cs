using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DrawableTarget : MonoBehaviour
{
    [SerializeField] DrawableTexture drawbleTexture;

    void Start()
    {
        Texture2D texture = drawbleTexture.texture;
        byte[] bytes = texture.EncodeToPNG();

        Texture2D newTexture = new Texture2D(2, 2);
        newTexture.LoadImage(bytes);
        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.material.mainTexture = newTexture;

        // File.WriteAllBytes(Application.persistentDataPath + "/DrawableTarget.png", bytes);
        // Debug.Log("Texture saved.");
    }
}
