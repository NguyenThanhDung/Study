using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextureEditor
{
    public class DrawZone : MonoBehaviour
    {
        [SerializeField] DrawableObject drawableObjectPrefab;
        [SerializeField] DrawableData drawableData;

        private List<DrawableObject> drawableObjects;

        public void LoadDrawableObject()
        {
            this.drawableObjects = new List<DrawableObject>();
            for (int i = 0; i < this.drawableData.textures.Count; i++)
            {
                DrawableObject drawableObject = Instantiate<DrawableObject>(drawableObjectPrefab, this.transform);
                drawableObject.SetTexture(this.drawableData.textures[i]);
                this.drawableObjects.Add(drawableObject);
            }
        }

        public void SaveDrawableObject()
        {
            // this.drawableObject.SaveTextureToFile();
            // Destroy(this.drawableObject.gameObject);
            // this.drawableObject = null;

            // Transform child = this.transform.GetChild(0);
            // child.gameObject.SetActive(false);
        }
    }
}
