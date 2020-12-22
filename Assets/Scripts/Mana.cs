using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    private float mana = 10f;
    public float ManaValue
    {
        get
        {
            return mana;
        }

        set
        {
            mana = value;

            if (OnManaChanged != null)
                OnManaChanged.Invoke(mana);

        }
    }

    public Action<float> OnManaChanged;

    void Start()
    {
        InvokeRepeating("CheckMana", 10f, 10f);
    }

    void CheckMana()
    {
        if (mana < 10)
            mana += 1;
    }
}
