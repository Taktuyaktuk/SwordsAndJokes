using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItmesPickUP : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = FindObjectOfType<Player>().GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    if(other.CompareTag("Player"))
    {
        for (int i = 0; i <inventory.slots.Length; i++)
        {
            if(inventory.isFull[i] == false)//Items could be added
            {
                inventory.isFull[i] = true;
                Instantiate(itemButton,inventory.slots[i].transform,false);
                Destroy(gameObject); // Destroy it from the sceene couse it will go to simple inventory
                break;
            }
        }
    }
}

}

