using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BulletDemage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player == null)
        {
            var entity = collision.gameObject.GetComponent<Entity>();

            if (entity != null)
            {
                entity.Health -= 1f;
                Destroy(gameObject);
            }
        }
    }
}
