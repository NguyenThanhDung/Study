using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

public class TextureEditor : MonoBehaviour
{
    [SerializeField] PaintType paintType;
    [SerializeField] int brushSize;
    [SerializeField] BrushShape brushShape;
    [SerializeField] float brushSoftness;
    [SerializeField] Image currentImage;

    void Update()
    {
        if (!Input.GetMouseButton(0))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ColorEditable"))
            {
                if (paintType == PaintType.Fill)
                    Fill(hit.collider.gameObject, this.currentImage.color);
                else
                    BrushPoint(hit.collider.gameObject, hit.textureCoord, this.brushShape, this.brushSize, this.brushSoftness, this.currentImage.color);
            }
        }
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
}
