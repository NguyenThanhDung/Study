using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TextureEditor
{
    public class CustomizedObject : MonoBehaviour
    {
        [Serializable]
        public class Part
        {
            public Vector3 position;
            public string texturePath;
        }

        public List<Part> parts;

        private GameObject craftedElementPrefab;
        private string filePath;

        void Start()
        {
            this.craftedElementPrefab = this.transform.GetChild(0).gameObject;
            this.filePath = Application.persistentDataPath + "/customizedObject.json";
            this.parts = new List<Part>();
        }

        public void LoadFromFile()
        {
            StartCoroutine(InternalLoadFile(this.filePath));
        }

        public void SaveToFile(List<DrawableObject> craftedObjects)
        {
            foreach (DrawableObject craftedObject in craftedObjects)
            {
                Part part = new Part();
                part.position = craftedObject.transform.position;
                part.texturePath = craftedObject.TexturePath;
                this.parts.Add(part);
            }

            string jsonText = JsonUtility.ToJson(this);
            StartCoroutine(InternalSaveFile(this.filePath, jsonText));
        }

        private IEnumerator InternalLoadFile(string filePath)
        {
            while (this.filePath == null)
                yield return null;
            string jsonText = System.IO.File.ReadAllText(this.filePath);
            JsonUtility.FromJsonOverwrite(jsonText, this);
            SpawnChildElements();
            Debug.Log("Loaded customized object");
        }

        private IEnumerator InternalSaveFile(string filePath, string jsonText)
        {
            while (this.filePath == null)
                yield return null;
            System.IO.File.WriteAllText(this.filePath, jsonText);
            Debug.Log("Customized object is saved to " + this.filePath);
            Destroy(this.gameObject);
        }

        private void SpawnChildElements()
        {
            foreach (Part part in this.parts)
            {
                GameObject element = Instantiate(this.craftedElementPrefab, this.transform);
                element.transform.position = part.position;

                byte[] bytes = File.ReadAllBytes(part.texturePath);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(bytes);

                MeshRenderer meshRenderer = element.GetComponent<MeshRenderer>();
                meshRenderer.material.mainTexture = texture;

                float scaleX = texture.width / 512f;
                float scaleY = texture.height / 512f;
                element.transform.localScale = new Vector3(scaleX, scaleY, 1f);

                element.SetActive(true);
            }
        }
    }
}
