using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BrushType
{
    Fill,
    Pen
}

public class TextureEditor : MonoBehaviour
{
    [SerializeField] BrushType brushType;
    [SerializeField] int brushSize;
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
                if (brushType == BrushType.Fill)
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
                            Vector2 drawingPoint = new Vector2(i, j);
                            float distance = Vector2.Distance(drawingPoint, pixelPosition);
                            if (distance < (int)this.brushSize)
                                texture.SetPixel(i, j, currentImage.color);
                        }
                    }
                    texture.Apply();
                }
            }
        }
    }
}
