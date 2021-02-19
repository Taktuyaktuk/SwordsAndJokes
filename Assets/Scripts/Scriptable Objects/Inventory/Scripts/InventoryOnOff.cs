using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOnOff : MonoBehaviour
{
    public GameObject inventoryOnOff;
    public GameObject inventory2OnOff;


    private void Start()
    {
        inventoryOnOff.SetActive(false);
        inventory2OnOff.SetActive(false);
    }
    private void Awake()
    {
        inventoryOnOff.SetActive(true);
        inventory2OnOff.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventoryOnOff.activeInHierarchy && inventory2OnOff.activeInHierarchy)
        {
            inventoryOnOff.SetActive(false);
            inventory2OnOff.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.I) && !inventoryOnOff.activeInHierarchy && !inventory2OnOff.activeInHierarchy)
        {
            inventoryOnOff.SetActive(true);
            inventory2OnOff.SetActive(true);
        }
    }
}
