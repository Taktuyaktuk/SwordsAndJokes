using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeDmg1 : MonoBehaviour
{
    Player targetPlayer;
    [SerializeField]
    float _AoeDmg1;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            targetPlayer = player;
            targetPlayer.GetComponent<Entity>().Health -= _AoeDmg1;
            Destroy(this.gameObject);
        }
    }
}
