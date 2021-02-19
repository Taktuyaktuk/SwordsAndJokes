using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInstantUse : MonoBehaviour
{
    Player targetPlayer;
    [SerializeField]
    float HP;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            targetPlayer = player;
            targetPlayer.GetComponent<Entity>().Health += HP;
            Destroy(this.gameObject);
        }
    }
}
