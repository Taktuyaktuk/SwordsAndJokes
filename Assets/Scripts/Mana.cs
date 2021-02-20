using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mana : MonoBehaviour
{
    private float maxMana = 10f;
    private float mana = 10f;
    private float Level = 0;
    private float Stats = 0;
    public float ManaValue
    {
        get
        {
            return mana;
        }

        set
        {
            mana = value;
           
            if (mana > maxMana)
                mana = maxMana;

            if (OnManaChanged != null)
                OnManaChanged.Invoke(mana);
        }
    }

    public Action<float> OnManaChanged;
    public Action<float> OnMaxManaChanged;

    void Start()
    {
        OnManaChanged.Invoke(mana);
        CheckMana();
        CountMaxValue();
        gameObject.GetComponent<LevelSystem>().OnLevelUp += Lv => {
            Level = Lv;
            CountMaxValue();
        };
        gameObject.GetComponent<PlayerStats>().OnIntelligenceChanged += Intellignece =>
        {
            Stats = Intellignece;
            CountMaxValue();
        };
        InvokeRepeating("CheckMana", 10f, 10f);
    }

    void CheckMana()
    {
        if (mana < maxMana)
            mana += 10;
        OnManaChanged.Invoke(mana);
    }

    void CountMaxValue()
    {
        maxMana = 10f + (Level * 0.8f) + Stats;
        OnMaxManaChanged.Invoke(maxMana);
    }
}
