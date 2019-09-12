using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObject : MonoBehaviour
{
    [SerializeField] LayerMask cuttableLayer;

    private List<Vector2> shape;

    void Start()
    {
        this.shape = new List<Vector2>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.shape.Clear();
        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, this.cuttableLayer))
            {
                this.shape.Add(hit.textureCoord);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Validate();
        }
    }

    private void Validate()
    {
        if (this.shape.Count < 3)
        {
            Debug.Log("Not enough vertexes");
            return;
        }
        foreach (Vector2 vertex in this.shape)
        {
            Debug.Log(vertex);
        }
    }
}
