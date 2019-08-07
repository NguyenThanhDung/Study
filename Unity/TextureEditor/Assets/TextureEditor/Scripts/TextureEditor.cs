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
                    texture.SetPixel((int)pixelPosition.x, (int)pixelPosition.y, currentImage.color);
                    texture.Apply();
                }
            }
        }
    }
}
