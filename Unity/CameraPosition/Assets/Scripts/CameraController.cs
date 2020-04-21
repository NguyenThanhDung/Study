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
        Debug.Log("topMarginDirection: " + topMarginDirection);
    }

    private Vector3 GetDirectionFromCameraToTopMargin(float margin)
    {
        Camera camera = this.gameObject.GetComponent<Camera>();
        Vector3 screenPosition = new Vector3(Screen.width / 2f, Screen.height * (1f - margin), 10f);
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
        return worldPosition - this.transform.position;
    }
}
