using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public Vector2 KnocBackDirection;
    public float KnockBackPower;

    public SpriteRenderer spriteRenderer;
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CommitKnockBack(collision.otherRigidbody);
    }

    private void CommitKnockBack(Rigidbody2D otherRigidbody)
    {
        if (Input.GetKey("f"))
        {
            otherRigidbody.AddForce(KnocBackDirection * KnockBackPower);
        }
    }
}
    