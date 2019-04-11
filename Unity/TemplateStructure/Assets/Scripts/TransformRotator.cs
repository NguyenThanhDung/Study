using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotator : MonoBehaviour
{
    [SerializeField]
    Transform m_anchor;
    [SerializeField]
    Vector3 m_axis;
    [SerializeField]
    float m_speed;

    void Start()
    {
    
    }

    void Update()
    {
        if (m_anchor != null)
        {
            transform.RotateAround(m_anchor.position, m_axis, m_speed);
        }
        else
        {
            transform.RotateAround(Vector3.zero, m_axis, m_speed);
        }
    }
}
