using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    float WalkingSpeed = 2f;

    [SerializeField]
    float RunninSpeed = 3f;

    Rigidbody2D Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateMovement();
    }

    void UpdateMovement()
    {
        var WalkingDirection = Vector3.zero;

        WalkingDirection += Vector3.up * Input.GetAxis("Vertical");
        WalkingDirection += Vector3.right * Input.GetAxis("Horizontal");

        WalkingDirection = WalkingDirection.normalized;

        WalkingDirection *= Input.GetKey(KeyCode.LeftShift) ? RunninSpeed : WalkingSpeed;

        Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, WalkingDirection, Time.deltaTime * 4f);
    }
}
