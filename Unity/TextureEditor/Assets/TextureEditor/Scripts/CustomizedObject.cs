using System;
using System.Collections;
using System.Collections.Generic;
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

        private string filePath;

        void Start()
        {
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
    }
}
