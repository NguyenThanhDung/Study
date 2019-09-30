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

        void Start()
        {
            this.parts = new List<Part>();
        }

        public void SaveToFile(List<DrawableObject> craftedObjects)
        {
            foreach(DrawableObject craftedObject in craftedObjects)
            {
                Part part = new Part();
                part.position = craftedObject.transform.position;
                part.texturePath = craftedObject.TexturePath;
                this.parts.Add(part);
            }

            string jsonText = JsonUtility.ToJson(this);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/customizedObject.json", jsonText);
            Debug.Log("Customized object is saved.");
        }
    }
}
