using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCapturer : MonoBehaviour
{
    private Camera camera;
    private bool shouldTakeScreenShot;

    void Start()
    {
        this.camera = this.gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
            this.shouldTakeScreenShot = true;
        }
    }

    void OnPostRender()
    {
        if (this.shouldTakeScreenShot)
        {
            this.shouldTakeScreenShot = false;
            TakeScreenshot();
        }
    }

    private void TakeScreenshot()
    {
        RenderTexture renderTexture = this.camera.targetTexture;

        Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        renderResult.ReadPixels(rect, 0, 0);

        string filePath = Application.persistentDataPath + "/Screenshot.png";
        byte[] byteArray = renderResult.EncodeToPNG();
        System.IO.File.WriteAllBytes(filePath, byteArray);
        RenderTexture.ReleaseTemporary(renderTexture);

        this.camera.targetTexture = null;

        Debug.Log("Screen was saved at " + filePath);
    }
}
