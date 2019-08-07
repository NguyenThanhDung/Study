using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureEditor : MonoBehaviour
{
    [SerializeField] Image currentImage;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("ColorEditable"))
                {
                    MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
                    renderer.materials[0].SetColor("_Color", currentImage.color);
                }
            }
        }
    }
}
