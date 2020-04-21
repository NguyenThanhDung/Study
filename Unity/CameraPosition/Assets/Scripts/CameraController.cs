using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float margin;

    void Start()
    {
        Vector3 topMarginDirection = GetDirectionFromCameraToTopMargin(this.margin);
        
        MeshRenderer renderer = this.target.GetComponent<MeshRenderer>();
        Vector3 topPoint = this.target.position + new Vector3(0f, renderer.bounds.size.y, -renderer.bounds.size.z) * 0.5f;
        Vector3 projectedTopPoint = topPoint + topMarginDirection;
        
        Vector3 backPoint = this.target.position + Vector3.forward;
        Vector3 sidePoint = this.target.position + Vector3.right;
        Debug.Log("backPoint: " + backPoint);
        Debug.Log("sidePoint: " + sidePoint);
    }

    private Vector3 GetDirectionFromCameraToTopMargin(float margin)
    {
        Camera camera = this.gameObject.GetComponent<Camera>();
        Vector3 screenPosition = new Vector3(Screen.width / 2f, Screen.height * (1f - margin), 10f);
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
        return worldPosition - this.transform.position;
    }
}
