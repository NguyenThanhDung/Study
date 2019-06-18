# Device Camera

This project capture device camera and show on a plane.

### Instruction

Request device camera permission

```csharp
IEnumerator Start()
{
    yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
    // Capture camera...
}
```

Decleration

```csharp
Renderer projectorScreen;
WebCamTexture deviceCamera;
```

Assign renderer material by device camera capturing

```csharp
projectorScreen.material.mainTexture = deviceCamera;
deviceCamera.Play();
```

We will see that the projector screen is rotated to the left.
We can rotate it base on the camera rotation angle

```csharp
private Quaternion projectorOriginalRotation;

IEnumerator Start()
{
    // ...
    this.projectorOriginalRotation = this.projectorScreen.transform.rotation;
}

void Update()
{
    this.projectorScreen.transform.rotation = this.projectorOriginalRotation * Quaternion.AngleAxis(this.deviceCamera.videoRotationAngle, Vector3.back);
}
```

### Todos

 - Expand projector screen
 - Flip horizontally
 - Scale image base on screen size
 - Capture front camera

### Credit

Nguyen Thanh Dung

dung.nguyenthanh@hotmail.com