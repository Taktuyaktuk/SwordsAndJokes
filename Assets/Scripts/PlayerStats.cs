using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //public Attribute[] attributes;
    private float InventoryStr = 0;
    private float InventoryAgi = 0;
    private float InventoryVit = 0;
    private float InventoryInt = 0;
    private float strength;
    public float Strength
    {
        get
        {
            return strength + InventoryStr;
        }
        set
        {
            strength = value;
            if (OnStrengthChanged != null)
                OnStrengthChanged.Invoke(strength);
        }
    }
    public Action<float> OnStrengthChanged;

    private float agility;
    public float Agility
    {
        get
        {
            return agility + InventoryAgi;
        }
        set
        {
            agility = value;
            if (OnAgilityChanged != null)
                OnAgilityChanged.Invoke(agility);
        }
    }
    public Action<float> OnAgilityChanged;

    private float vitality = 1;
    public float Vitality
    {
        get
        {
            return vitality + InventoryVit;
        }
        set
        {
            vitality = value;
            if (OnVitalityChanged != null)
                OnVitalityChanged.Invoke(vitality);
        }
    }
    public Action<float> OnVitalityChanged;

    private float intelligence;
    public float Intelligence
    {
        get
        {
            return intelligence + InventoryInt;
        }
        set
        {
            intelligence = value;
            if (OnIntelligenceChanged != null)
                OnIntelligenceChanged.Invoke(intelligence);
        }
    }
    public Action<float> OnIntelligenceChanged;

    public void UpdateInventoryStats()
    {
        var attributes = gameObject.GetComponent<Player>().attributes;
        for (int i = 0; i < attributes.Length; i++)
        {
            switch (attributes[i].type.ToString())
            {
                case "Agility":
                    InventoryAgi = attributes[i].value.ModifiedValue;
                    if (OnAgilityChanged != null)
                        OnAgilityChanged.Invoke(InventoryAgi + agility);
                    break;
                case "Intelect":
                    InventoryInt = attributes[i].value.ModifiedValue;
                    if (OnIntelligenceChanged != null)
                        OnIntelligenceChanged.Invoke(InventoryInt + intelligence);
                    break;
                case "Stamina":
                    InventoryVit = attributes[i].value.ModifiedValue;
                    if (OnVitalityChanged != null)
                        OnVitalityChanged.Invoke(InventoryVit + vitality);
                    break;
                case "Strenghth":
                    InventoryStr = attributes[i].value.ModifiedValue;
                    if (OnStrengthChanged != null)
                        OnStrengthChanged.Invoke(InventoryStr + strength);
                    break;
                default:
                    break;
            }
        }
    }
}
