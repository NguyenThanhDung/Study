using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObject : MonoBehaviour
{
    [SerializeField] LayerMask cuttableLayer;

    void Update()
    {
        if(!Input.GetMouseButton(0))
            return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, this.cuttableLayer))
        {
            Debug.Log(hit.textureCoord);
        }
    }
}
