using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeDmgRandom : MonoBehaviour
{
    bool playerInRange;
    public GameObject Prefab;
    Vector2 Position;


    private void Update()
    {

       Position = gameObject.transform.position;

       var randomInt = Random.Range(0, 300);
        
        if (randomInt == 199 && playerInRange == true)

        {
            Instantiate(Prefab,Position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
