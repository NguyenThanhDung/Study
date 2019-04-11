using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;

    private Vector3 offset;

    void Start()
    {
        this.offset = this.transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position + this.offset;
    }
}
