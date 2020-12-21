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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckMana", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckMana()
    {
        if (mana < 10)
            mana += 1;
    }
}
