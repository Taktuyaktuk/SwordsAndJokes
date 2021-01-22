using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeDmgHpChange : MonoBehaviour
{
    bool playerInRange;
    public GameObject Prefab;
    Vector2 Position;


    private void Update()
    {

        var hp = gameObject.GetComponent<Entity>().Health;
        var hpMax = gameObject.GetComponent<Entity>().InitialHealth;
        Debug.Log("hp" + hp);
        Debug.Log("hpMax" + hpMax);
        Debug.Log(0.9f * hpMax); 

        if (hp <= (0.9f * hpMax) && playerInRange == true)
        {

            Instantiate(Prefab, Position, Quaternion.identity);
            Destroy(this.gameObject);

        }



        //Position = gameObject.transform.position;

        //var randomInt = Random.Range(0, 400);

        //if (randomInt == 199 && playerInRange == true)

        //{
        //    Instantiate(Prefab, Position, Quaternion.identity);
        //    Destroy(this.gameObject);
        //}
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
