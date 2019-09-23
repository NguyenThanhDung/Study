using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextureEditor
{
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
            Destroy(this.drawableObject.gameObject);
            this.drawableObject = null;

            Transform child = this.transform.GetChild(0);
            child.gameObject.SetActive(false);
        }
    }
}
