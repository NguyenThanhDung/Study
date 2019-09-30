using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextureEditor
{
    public enum PaintType
    {
        Fill,
        Brush
    }

    public enum BrushShape
    {
        Square,
        Circle
    }

    public class TextureEditManager : MonoBehaviour
    {
        public static TextureEditManager Instance;

        public LayerMask drawableLayer;
        public PaintType paintType;
        public BrushShape brushShape;
        public float brushSoftness;

        [SerializeField] CustomizedObject customizedObjectPrefab;

        private int brushSize;
        private Color color;

        public int CurrentBrushSize
        {
            get
            {
                return this.brushSize;
            }
        }

        public Color CurrentColor
        {
            get
            {
                return this.color;
            }
        }

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            this.brushSize = 50;
            this.color = Color.green;
        }

        public void SetBrushSize(int size)
        {
            this.brushSize = size;
        }

        public void SetColor(Image image)
        {
            this.color = image.color;
        }

        public void ShowCustomizedObject()
        {
            CustomizedObject customizedObject = Instantiate<CustomizedObject>(this.customizedObjectPrefab, this.transform);
            customizedObject.LoadFromFile();
        }
    }
}