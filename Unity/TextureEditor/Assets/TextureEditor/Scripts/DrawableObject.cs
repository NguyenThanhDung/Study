using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TextureEditor
{
    public class DrawableObject : MonoBehaviour
    {
        void Start()
        {
            byte[] bytes = TextureEditManager.Instance.targetTexture.EncodeToPNG();
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
            File.WriteAllBytes(TextureEditManager.Instance.CustomizedTexturePath, bytes);
            Debug.Log("Texture saved to " + TextureEditManager.Instance.CustomizedTexturePath);
        }
    }
}
