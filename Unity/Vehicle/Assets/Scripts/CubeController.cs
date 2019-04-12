using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float step = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            this.transform.Translate(Vector3.left * this.step);
        if(Input.GetKeyDown(KeyCode.RightArrow))
            this.transform.Translate(Vector3.right * this.step);
        if(Input.GetKeyDown(KeyCode.UpArrow))
            this.transform.Translate(Vector3.forward * this.step);
        if(Input.GetKeyDown(KeyCode.DownArrow))
            this.transform.Translate(Vector3.back * this.step);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
