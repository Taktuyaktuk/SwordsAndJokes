using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    public int X_Start;
    public int Y_Start;

    public int X_Space_Between_Items;
    public int number_Of_Column;
    public int Y_Speace_Between_Items;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

     //Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for(int i =0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];

            if(itemsDisplayed.ContainsKey(slot))
            {
                itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container.Items[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.transform.GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text =slot.amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container.Items[i], obj);
            }
        }

    }

    public void CreateDisplay()
    {
       for(int i=0; i< inventory.Container.Items.Count;i++)
       {
            InventorySlot slot = inventory.Container.Items[i];
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
           obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
           itemsDisplayed.Add(slot, obj);

       }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_Start+(X_Space_Between_Items * (i % number_Of_Column)), (Y_Start-(Y_Speace_Between_Items * (i/number_Of_Column))), 0f);
    }
}
