using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DrawableObject : MonoBehaviour
{
    [SerializeField] GameObject display;
    [SerializeField] Texture2D texture;

    private string savePath;

    void Start()
    {
        this.savePath = Application.persistentDataPath + "/DrawableTarget.png";

        byte[] bytes = texture.EncodeToPNG();
        Texture2D newTexture = new Texture2D(2, 2);
        newTexture.LoadImage(bytes);

        MeshRenderer meshRenderer = this.display.GetComponent<MeshRenderer>();
        meshRenderer.material.mainTexture = newTexture;
    }

    public void SaveTextureToFile()
    {
        MeshRenderer meshRenderer = this.display.GetComponent<MeshRenderer>();
        Texture2D texture = (Texture2D)meshRenderer.material.mainTexture;
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(this.savePath, bytes);
        Debug.Log("Texture saved to " + this.savePath);
    }
}
