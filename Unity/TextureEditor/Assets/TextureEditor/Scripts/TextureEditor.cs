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
        if (!Input.GetMouseButtonDown(0))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ColorEditable"))
            {
                MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
                Material material = renderer.material;
                if (paintType == PaintType.Fill)
                {
                    material.SetColor("_Color", currentImage.color);
                }
                else
                {
                    Texture2D texture = (Texture2D)material.mainTexture;
                    Vector2 textureCoord = hit.textureCoord;
                    Vector2 pixelPosition = new Vector2(textureCoord.x * texture.width, textureCoord.y * texture.height);
                    for (int i = ((int)pixelPosition.x - this.brushSize); i < ((int)pixelPosition.x + this.brushSize); i++)
                    {
                        for (int j = ((int)pixelPosition.y - this.brushSize); j < ((int)pixelPosition.y + this.brushSize); j++)
                        {
                            if (this.brushShape == BrushShape.Square)
                            {
                                texture.SetPixel(i, j, currentImage.color);
                            }
                            else
                            {
                                Vector2 drawingPoint = new Vector2(i, j);
                                float distance = Vector2.Distance(drawingPoint, pixelPosition);
                                if (distance < (int)this.brushSize)
                                {
                                    float softDistance = distance - this.brushSize * (1f - this.brushSoftness);
                                    float softScale = softDistance / (this.brushSize * this.brushSoftness);

                                    if (softScale > 0f)
                                    {
                                        Color currentColor = texture.GetPixel((int)drawingPoint.x, (int)drawingPoint.y);
                                        Color drawingColor = currentImage.color;
                                        Color blendedColor = currentColor * softScale + drawingColor * (1f - softScale);

                                        texture.SetPixel((int)drawingPoint.x, (int)drawingPoint.y, blendedColor);
                                    }
                                    else
                                    {
                                        texture.SetPixel((int)drawingPoint.x, (int)drawingPoint.y, currentImage.color);
                                    }
                                }
                            }
                        }
                    }
                    texture.Apply();
                }
            }
        }
    }
}
