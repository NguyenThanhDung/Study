using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCamera : MonoBehaviour
{
    [SerializeField] GameObject projectorScreen;

    private WebCamTexture deviceCamera;
    private Quaternion projectorOriginalRotation;

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        this.deviceCamera = new WebCamTexture();
        this.projectorScreen.GetComponent<Renderer>().material.mainTexture = this.deviceCamera;
        this.deviceCamera.Play();
        this.projectorOriginalRotation = this.projectorScreen.transform.rotation;
    }

    void Update()
    {
        this.projectorScreen.transform.rotation = this.projectorOriginalRotation * Quaternion.AngleAxis(this.deviceCamera.videoRotationAngle, Vector3.back);
    }
}
