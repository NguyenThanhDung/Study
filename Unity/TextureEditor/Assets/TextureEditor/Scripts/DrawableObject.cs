using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TextureEditor
{
    public enum State
    {
        Idle,
        Customizing
    }

    public class DrawableObject : MonoBehaviour
    {
        private GameObject display;
        private State currentState;
        private Vector2 lastTextureCoord;

        void Start()
        {
            this.display = this.transform.GetChild(0).gameObject;
            this.currentState = State.Customizing;
        }

        public void OnMouseButton(Vector2 textureCoord)
        {
            if (this.currentState == State.Idle)
            {
            }
            else
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
        }

        public void SetTexture(Texture2D texture)
        {
            byte[] bytes = texture.EncodeToPNG();
            Texture2D newTexture = new Texture2D(2, 2);
            newTexture.LoadImage(bytes);
            StartCoroutine(InternalSetTexture(newTexture));
        }

        public void SaveTextureToFile()
        {
            MeshRenderer meshRenderer = this.display.GetComponent<MeshRenderer>();
            Texture2D texture = (Texture2D)meshRenderer.material.mainTexture;
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(TextureEditManager.Instance.CustomizedTexturePath, bytes);
            Debug.Log("Texture saved to " + TextureEditManager.Instance.CustomizedTexturePath);
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

        public void Select()
        {
            this.transform.position = TextureEditManager.Instance.transform.position;
            this.transform.localScale = Vector3.one;
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
