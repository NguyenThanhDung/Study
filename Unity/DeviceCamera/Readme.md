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

### Todos

 - Expand projector screen
 - Flip horizontally
 - Scale image base on screen size
 - Capture front camera

### Credit

Nguyen Thanh Dung

dung.nguyenthanh@hotmail.com