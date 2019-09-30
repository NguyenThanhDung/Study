using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextureEditor
{
    public class DrawZone : MonoBehaviour
    {
        public enum State
        {
            Draw,
            Craft
        }

        public static DrawZone Instance;

        [SerializeField] DrawableObject drawableObjectPrefab;
        [SerializeField] DrawableData drawableData;
        [SerializeField] float offset;
        [SerializeField] float interval;
        [SerializeField] CustomizedObject customizedObjectPrefab;

        private State currentState;
        private List<DrawableObject> drawableObjects;
        private List<DrawableObject> droppedObjects;
        private DrawableObject customizingObject;
        private List<DrawableObject> craftingObjects;


        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            this.currentState = State.Draw;
            this.droppedObjects = new List<DrawableObject>();
            this.craftingObjects = new List<DrawableObject>();
            LoadDrawableObject();
        }

        public void LoadDrawableObject()
        {
            this.drawableObjects = new List<DrawableObject>();
            for (int i = 0; i < this.drawableData.textures.Count; i++)
            {
                DrawableObject drawableObject = Instantiate<DrawableObject>(drawableObjectPrefab, this.transform);
                drawableObject.SetId(i);
                drawableObject.SetTexture(this.drawableData.textures[i]);
                this.drawableObjects.Add(drawableObject);
            }
            AlignObjectPosition();
        }

        public bool StartDrawing(DrawableObject drawableObject)
        {
            if (this.customizingObject == null)
            {
                this.customizingObject = drawableObject;
                this.drawableObjects.Remove(drawableObject);
                AlignObjectPosition();
                return true;
            }
            return false;
        }

        public void StartCrafting(DrawableObject drawableObject)
        {
            this.craftingObjects.Add(drawableObject);
            this.droppedObjects.Remove(drawableObject);
            AlignObjectPosition();
        }

        public void Validate()
        {
            if (this.currentState == State.Draw && this.customizingObject != null)
            {
                this.customizingObject.Validate();
                this.droppedObjects.Add(this.customizingObject);
                this.customizingObject = null;
                this.currentState = (this.drawableObjects.Count == 0) ? State.Craft : State.Draw;
            }
            if (this.currentState == State.Craft && this.craftingObjects.Count > 0)
            {
                CustomizedObject customizedObject = Instantiate(this.customizedObjectPrefab);
                customizedObject.SaveToFile(this.craftingObjects);

                foreach(DrawableObject craftedObject in this.craftingObjects)
                    craftedObject.gameObject.SetActive(false);

                Transform background = this.transform.GetChild(0);
                background.gameObject.SetActive(false);
            }
            AlignObjectPosition();
        }

        private void AlignObjectPosition()
        {
            if (this.customizingObject != null)
            {
                this.customizingObject.transform.position = this.transform.position + Vector3.back * 0.1f;
                this.customizingObject.transform.localScale = Vector3.one;
            }

            for (int i = 0; i < this.craftingObjects.Count; i++)
            {
                this.craftingObjects[i].transform.localScale = Vector3.one;
            }

            float zoneHeight = (this.drawableObjects.Count - 1) * this.interval;
            for (int i = 0; i < this.drawableObjects.Count; i++)
            {
                Vector3 direction = new Vector3(-this.offset, zoneHeight / 2f - i * this.interval, 0f);
                Vector3 position = this.transform.position + direction;
                this.drawableObjects[i].transform.position = position;
                this.drawableObjects[i].transform.localScale = Vector3.one * 0.5f;
            }

            zoneHeight = (this.droppedObjects.Count - 1) * this.interval;
            for (int i = 0; i < this.droppedObjects.Count; i++)
            {
                Vector3 direction = new Vector3(this.offset, zoneHeight / 2f - i * this.interval, 0f);
                Vector3 position = this.transform.position + direction;
                this.droppedObjects[i].transform.position = position;
                this.droppedObjects[i].transform.localScale = Vector3.one * 0.5f;
            }
        }
    }
}
