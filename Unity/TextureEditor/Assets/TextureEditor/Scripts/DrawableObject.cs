using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TextureEditor
{

    public class DrawableObject : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Customizing,
            WaitForCrafting,
            Crafting
        }

        private int id;
        private GameObject display;
        private State currentState;
        private Vector2 lastTextureCoord;
        private Vector3 offsetBetweenMouseAndObject;
        private bool isDragging;

        public string TexturePath { get; private set; }

        void Start()
        {
            this.display = this.transform.GetChild(0).gameObject;
            this.currentState = State.Idle;
            this.offsetBetweenMouseAndObject = Vector3.zero;
            this.isDragging = false;
        }

        public void OnMouseButton(Vector2 textureCoord)
        {
            if (this.currentState == State.Idle)
            {
                bool drawable = DrawZone.Instance.StartDrawing(this);
                this.currentState = drawable ? State.Customizing : State.Idle;
            }
            else if (this.currentState == State.Customizing)
            {
                if (TextureEditManager.Instance.paintType == PaintType.Fill)
                    Fill(TextureEditManager.Instance.CurrentColor);
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        BrushPoint(textureCoord, TextureEditManager.Instance.brushShape, TextureEditManager.Instance.CurrentBrushSize, TextureEditManager.Instance.brushSoftness, TextureEditManager.Instance.CurrentColor);
                    }
                    else if (Input.GetMouseButton(0))
                    {
                        BrushLine(this.lastTextureCoord, textureCoord, TextureEditManager.Instance.brushShape, TextureEditManager.Instance.CurrentBrushSize, TextureEditManager.Instance.brushSoftness, TextureEditManager.Instance.CurrentColor);
                    }
                    this.lastTextureCoord = textureCoord;
                }
            }
            else if (this.currentState == State.WaitForCrafting)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 objectScreenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
                    this.offsetBetweenMouseAndObject = objectScreenPoint - Input.mousePosition;
                    this.isDragging = true;
                    DrawZone.Instance.StartCrafting(this);
                }
                else if (Input.GetMouseButton(0))
                {
                    if (this.isDragging)
                    {
                        Vector3 newObjectScreenPoint = Input.mousePosition + this.offsetBetweenMouseAndObject;
                        this.transform.position = Camera.main.ScreenToWorldPoint(newObjectScreenPoint);
                    }
                }
                if (Input.GetMouseButtonUp(0) && this.isDragging)
                {
                    this.isDragging = false;
                    this.currentState = State.Crafting;
                }
            }
            else if (this.currentState == State.Crafting)
            {

            }
        }

        public void SetId(int id)
        {
            this.id = id;
            this.TexturePath = Application.persistentDataPath + "/DrawableObject" + this.id.ToString() + ".png";
        }

        public void SetTexture(Texture2D texture)
        {
            byte[] bytes = texture.EncodeToPNG();
            Texture2D newTexture = new Texture2D(2, 2);
            newTexture.LoadImage(bytes);
            StartCoroutine(InternalSetTexture(newTexture));
        }

        public void Validate()
        {
            MeshRenderer meshRenderer = this.display.GetComponent<MeshRenderer>();
            Texture2D texture = (Texture2D)meshRenderer.material.mainTexture;
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(this.TexturePath, bytes);
            Debug.Log("Texture saved to " + this.TexturePath);

            this.currentState = State.WaitForCrafting;
        }

        public void Fill(Color color)
        {
            MeshRenderer renderer = this.display.GetComponent<MeshRenderer>();
            renderer.material.SetColor("_Color", color);
        }

        public void BrushPoint(Vector2 textureCoord, BrushShape brushShape, int brushSize, float softness, Color brushColor)
        {
            MeshRenderer renderer = this.display.GetComponent<MeshRenderer>();
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
                    if (TextureEditManager.Instance.brushShape == BrushShape.Square)
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

        public void BrushLine(Vector2 beginTextureCoord, Vector2 endTextureCoord, BrushShape brushShape, int brushSize, float softness, Color brushColor)
        {
            float interval = 0.2f;
            for (float lerp = 0f; lerp < 1f; lerp += interval)
            {
                Vector2 currentTextureCoord = Vector2.Lerp(beginTextureCoord, endTextureCoord, lerp);
                BrushPoint(currentTextureCoord, brushShape, brushSize, softness, brushColor);
            }
        }

        private IEnumerator InternalSetTexture(Texture2D texture)
        {
            while (this.display == null)
                yield return null;
            MeshRenderer meshRenderer = this.display.GetComponent<MeshRenderer>();
            meshRenderer.material.mainTexture = texture;
        }
    }
}
