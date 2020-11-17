using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryBP : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory1;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;

    private void Start()
    {
        allSlots = 40;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<SlotBp>().item1 == null)
                slot[i].GetComponent<SlotBp>().empty = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            
            inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true)
        {
            inventory1.SetActive(true);
        }
        else
        {
            inventory1.SetActive(false);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    void AddItem(GameObject itemObject, int itemId, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<SlotBp>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<SlotBp>().item1 = itemObject;
               slot[i].GetComponent<SlotBp>().icon = itemIcon;
                slot[i].GetComponent<SlotBp>().type = itemType;
                slot[i].GetComponent<SlotBp>().ID = itemId;
                slot[i].GetComponent<SlotBp>().description = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<SlotBp>().UpdateSlot();
                slot[i].GetComponent<SlotBp>().empty = false;

            }
            return;
        }
    }
}
