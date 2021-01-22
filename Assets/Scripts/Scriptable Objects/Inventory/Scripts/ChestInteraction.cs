using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject LootPrefab;
    public bool PlayerInLootRange;
    Vector3 ObjPosition;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && PlayerInLootRange)
        {
            ObjPosition = gameObject.transform.position;
            Instantiate(LootPrefab, ObjPosition, Quaternion.identity);
            Destroy(this.gameObject);
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerInLootRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerInLootRange = false;
        }
    }
}
