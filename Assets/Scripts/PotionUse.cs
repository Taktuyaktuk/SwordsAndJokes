using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PotionUse : MonoBehaviour
{
    public GameObject effect;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    public void Use()
    {
        //Instantiate(effect, player.position, Quaternion.identity);
        var entity = FindObjectOfType<Player>().GetComponent<Entity>();
        entity.Health += 1f;
        Destroy(gameObject);
          
    }
}

