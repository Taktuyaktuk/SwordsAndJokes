using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Rigidbody2D player;
    UnityEngine.Camera MainCamera;

    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
        MainCamera = GetComponent<UnityEngine.Camera>();
    }

    void FixedUpdate()
    {
        UpdatePosition();
        UpdateFOV();
    }

    void UpdatePosition()
    {
        var targetPostion =
           (Vector3)player.position
            + (Vector3) player.velocity * 0.5f
            +  Vector3.back * 10f;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPostion,
            Time.deltaTime * 4f);
    }

    void UpdateFOV()
    {
        var speed = player.velocity.magnitude;
        var targetViewSize = 3f + speed / 2f;
        MainCamera.orthographicSize = Mathf.Lerp(
            MainCamera.orthographicSize,
            targetViewSize,
            Time.deltaTime);
    }
}
