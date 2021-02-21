using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BulletDemage : MonoBehaviour
{
    Rigidbody2D m_rigidbody2d;

    void Start()
    {
        m_rigidbody2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(15, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player == null)
        {
            var entity = collision.gameObject.GetComponent<Entity>();

            if (entity != null)
            {
                entity.Health -= 2f;
                Destroy(gameObject);
            }
        }
    }
}
