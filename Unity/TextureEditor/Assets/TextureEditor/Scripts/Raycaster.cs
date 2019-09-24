using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextureEditor
{

    public class Raycaster : MonoBehaviour
    {
        private Vector2 lastTextureCoord;

        void Update()
        {
            if (!Input.GetMouseButton(0))
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, TextureEditManager.Instance.drawableLayer))
            {
                DrawableObject drawableObject = hit.collider.transform.parent.GetComponent<DrawableObject>();
                if (TextureEditManager.Instance.paintType == PaintType.Fill)
                    drawableObject.Fill(TextureEditManager.Instance.CurrentColor);
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        drawableObject.BrushPoint(hit.textureCoord, TextureEditManager.Instance.brushShape, TextureEditManager.Instance.CurrentBrushSize, TextureEditManager.Instance.brushSoftness, TextureEditManager.Instance.CurrentColor);
                    }
                    else if (Input.GetMouseButton(0))
                    {
                        drawableObject.BrushLine(this.lastTextureCoord, hit.textureCoord, TextureEditManager.Instance.brushShape, TextureEditManager.Instance.CurrentBrushSize, TextureEditManager.Instance.brushSoftness, TextureEditManager.Instance.CurrentColor);
                    }
                    this.lastTextureCoord = hit.textureCoord;
                }
            }
        }
    }

}