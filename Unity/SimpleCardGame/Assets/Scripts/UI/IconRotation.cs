using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconRotation : MonoBehaviour
{
    private const float ROUND_PER_SECOND = 2f;
    private RectTransform loadingIcon;

    void Start()
    {
        this.loadingIcon = GetComponent<RectTransform>();
    }

    void Update()
    {
        this.loadingIcon.Rotate(new Vector3(0f, 0f, -360 * ROUND_PER_SECOND * Time.deltaTime));
    }
}
