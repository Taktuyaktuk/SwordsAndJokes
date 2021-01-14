using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float strength;
    public float Strength
    {
        get
        {
            return strength;
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
            return agility;
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
            return vitality;
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
            return intelligence;
        }
        set
        {
            intelligence = value;
            if (OnIntelligenceChanged != null)
                OnIntelligenceChanged.Invoke(intelligence);
        }
    }
    public Action<float> OnIntelligenceChanged;
}
