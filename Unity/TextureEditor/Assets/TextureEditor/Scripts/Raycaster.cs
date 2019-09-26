using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextureEditor
{

    public class Raycaster : MonoBehaviour
    {
        void Update()
        {
            if (!Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0))
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, TextureEditManager.Instance.drawableLayer))
            {
                DrawableObject drawableObject = hit.collider.transform.parent.GetComponent<DrawableObject>();
                drawableObject.OnMouseButton(hit.textureCoord);
            }
        }
    }

}