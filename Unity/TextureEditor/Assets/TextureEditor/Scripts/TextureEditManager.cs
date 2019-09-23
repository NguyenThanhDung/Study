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

        public Texture2D targetTexture; // TODO: Remove

        [SerializeField] PaintType paintType;
        [SerializeField] BrushShape brushShape;
        [SerializeField] float brushSoftness;
        [SerializeField] LayerMask drawableLayer;

        private int brushSize;
        private Color color;

        private Vector2 lastTextureCoord;

        public string CustomizedTexturePath
        {
            get
            {
                return Application.persistentDataPath + "/DrawableTarget.png";
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

        void Update()
        {
            if (!Input.GetMouseButton(0))
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, this.drawableLayer))
            {
                if (paintType == PaintType.Fill)
                    Fill(hit.collider.gameObject, this.color);
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        BrushPoint(hit.collider.gameObject, hit.textureCoord, this.brushShape, this.brushSize, this.brushSoftness, this.color);
                    }
                    else if (Input.GetMouseButton(0))
                    {
                        BrushLine(hit.collider.gameObject, this.lastTextureCoord, hit.textureCoord, this.brushShape, this.brushSize, this.brushSoftness, this.color);
                    }
                    this.lastTextureCoord = hit.textureCoord;
                }
            }
        }

        public void SetBrushSize(int size)
        {
            this.brushSize = size;
        }

        public void SetColor(Image image)
        {
            this.color = image.color;
        }

        private void Fill(GameObject gameObject, Color color)
        {
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
            renderer.material.SetColor("_Color", color);
        }

        private void BrushPoint(GameObject gameObject, Vector2 textureCoord, BrushShape brushShape, int brushSize, float softness, Color brushColor)
        {
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
            Texture2D texture = (Texture2D)renderer.material.mainTexture;
            Vector2 point = new Vector2(textureCoord.x * texture.width, textureCoord.y * texture.height);

            int left = (int)point.x - brushSize;
            int right = (int)point.x + brushSize;
            int top = (int)point.y - brushSize;
            int bottom = (int)point.y + brushSize;

            for (int i = left; i < right; i++)
            {
                for (int j = top; j < bottom; j++)
                {
                    if (this.brushShape == BrushShape.Square)
                    {
                        texture.SetPixel(i, j, brushColor);
                    }
                    else
                    {
                        float distance = Vector2.Distance(new Vector2(i, j), point);
                        if (distance < brushSize)
                        {
                            float softDistance = distance - brushSize * (1f - softness);
                            float softScale = softDistance / (brushSize * softness);

                            if (softScale > 0f)
                            {
                                Color currentColor = texture.GetPixel(i, j);
                                Color drawingColor = brushColor;
                                Color blendedColor = currentColor * softScale + drawingColor * (1f - softScale);

                                texture.SetPixel(i, j, blendedColor);
                            }
                            else
                            {
                                texture.SetPixel(i, j, brushColor);
                            }
                        }
                    }
                }
            }

            texture.Apply();
        }

        private void BrushLine(GameObject gameObject, Vector2 beginTextureCoord, Vector2 endTextureCoord, BrushShape brushShape, int brushSize, float softness, Color brushColor)
        {
            float interval = 0.2f;
            for (float lerp = 0f; lerp < 1f; lerp += interval)
            {
                Vector2 currentTextureCoord = Vector2.Lerp(beginTextureCoord, endTextureCoord, lerp);
                BrushPoint(gameObject, currentTextureCoord, brushShape, brushSize, softness, brushColor);
            }
        }
    }
}