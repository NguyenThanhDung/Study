using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextureEditor
{
    public class DrawZone : MonoBehaviour
    {
        public static DrawZone Instance;
        
        public bool IsAvailable;

        [SerializeField] DrawableObject drawableObjectPrefab;
        [SerializeField] DrawableData drawableData;
        [SerializeField] float offset;
        [SerializeField] float interval;

        private List<DrawableObject> drawableObjects;

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            this.IsAvailable = true;
        }

        public void LoadDrawableObject()
        {
            float selectZoneHeight = (this.drawableData.textures.Count - 1) * this.interval;

            this.drawableObjects = new List<DrawableObject>();
            for (int i = 0; i < this.drawableData.textures.Count; i++)
            {
                DrawableObject drawableObject = Instantiate<DrawableObject>(drawableObjectPrefab, this.transform);
                drawableObject.SetTexture(this.drawableData.textures[i]);

                Vector3 newPos = new Vector3(-this.offset, selectZoneHeight / 2f - i * this.interval, 0f);
                newPos = this.transform.position + newPos;
                drawableObject.transform.position = newPos;

                drawableObject.transform.localScale *= 0.5f;

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
