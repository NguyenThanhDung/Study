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

        Vector3 intersection = Vector3.positiveInfinity;
        LinePlaneIntersection(out intersection, topPoint, projectedTopPoint, this.target.position, backPoint, sidePoint);
        Debug.Log("intersection: " + intersection);
    }

    private Vector3 GetDirectionFromCameraToTopMargin(float margin)
    {
        Camera camera = this.gameObject.GetComponent<Camera>();
        Vector3 screenPosition = new Vector3(Screen.width / 2f, Screen.height * (1f - margin), 10f);
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
        return worldPosition - this.transform.position;
    }

    // https://en.wikipedia.org/wiki/Line%E2%80%93plane_intersection
    // Get the intersection between a line and a plane. 
    // If the line and plane are not parallel, the function outputs true, otherwise false.
    private bool LinePlaneIntersection(out Vector3 intersection, Vector3 la, Vector3 lb, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        Vector3 lab = lb - la;

        Vector3 p01 = p1 - p0;
        Vector3 p02 = p2 - p0;
        Vector3 crossP01P02 = Vector3.Cross(p01, p02);

        float denominator = Vector3.Dot(-lab, crossP01P02);
        if (denominator == 0f)
        {
            intersection = Vector3.positiveInfinity;
            return false;
        }

        float numerator = Vector3.Dot(crossP01P02, la - p0);

        float t = numerator / denominator;
        intersection = la + lab * t;
        return true;
    }
}
