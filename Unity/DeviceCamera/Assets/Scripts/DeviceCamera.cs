using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCamera : MonoBehaviour
{
    [SerializeField]  Renderer projectorScreen;

    private WebCamTexture deviceCamera;

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        deviceCamera = new WebCamTexture();
        projectorScreen.material.mainTexture = deviceCamera;
        deviceCamera.Play();
    }
}
