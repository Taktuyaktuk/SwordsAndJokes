﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotBp : MonoBehaviour
{
    public GameObject item1;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }
}