using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    UnityEngine.Camera Camera;

    void Start()
    {
        Camera = FindObjectOfType<UnityEngine.Camera>();
    }

    void Update()
    {
        var mousePostion = Input.mousePosition;
        var worldPostion = Camera.ScreenToWorldPoint(mousePostion);

        transform.position = (Vector2)worldPostion;
    }
}
