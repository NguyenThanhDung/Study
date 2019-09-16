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
        Transform child = this.transform.GetChild(0);
        MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material.mainTexture = newTexture;
    }

    public void SaveTextureToFile()
    {
        Transform child = this.transform.GetChild(0);
        MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
        Texture2D texture = (Texture2D)meshRenderer.material.mainTexture;
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "/DrawableTarget.png", bytes);
        Debug.Log("Texture saved.");
    }
}
