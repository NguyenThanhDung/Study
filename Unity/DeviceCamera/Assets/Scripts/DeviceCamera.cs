using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCamera : MonoBehaviour
{
    [SerializeField] GameObject projectorScreen;

    private bool isInitialized = false;
    private bool shouldRotateProjector = false;
    private WebCamTexture deviceCamera;
    private Quaternion projectorOriginalRotation;

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (WebCamTexture.devices.Length > 0)
        {
            this.projectorOriginalRotation = this.projectorScreen.transform.rotation;
            this.deviceCamera = new WebCamTexture();
            this.projectorScreen.GetComponent<Renderer>().material.mainTexture = this.deviceCamera;
            this.deviceCamera.Play();
            this.isInitialized = true;
            this.shouldRotateProjector = true;
            Debug.LogWarning("Camera is initialized");
        }
        else
        {
            Debug.LogWarning("No camera is available");
        }
    }

    void Update()
    {
        if (this.isInitialized)
        {
            if (this.shouldRotateProjector)
            {
                this.projectorScreen.transform.rotation = this.projectorOriginalRotation * Quaternion.AngleAxis(this.deviceCamera.videoRotationAngle, Vector3.back);
                this.shouldRotateProjector = false;
            }
        }
    }
}
