using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    [SerializeField]
    public float AttackCooldown = 2f;

    [SerializeField]
    public float AttackDamage = 1f;

    public float AttackTime = 0;

    private Entity entity;

    void Update()
    {
        if(entity != null)
        {
            AttackTime += Time.deltaTime;
            if (AttackTime >= AttackCooldown)
            {
                entity.Health -= AttackDamage * Time.deltaTime;
                AttackTime = 0;
            }
        }
        else
        {
            AttackTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ent = collision.gameObject.GetComponent<Entity>();
        if (ent != null)
            entity = ent;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var ent = collision.gameObject.GetComponent<Entity>();
        if (ent != null)
            entity = null;
    }
}
