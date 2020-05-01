using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    float InitialHealth = 3f;

    private float health;
    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;

            if (OnHealthChanged != null)
                OnHealthChanged.Invoke(health);

            if (health <= 0)
            {
                if (OnKilled != null)
                    OnKilled.Invoke();

                Destroy(gameObject);
            }
               
        }
    }

    public Action<float> OnHealthChanged;
    public Action OnKilled;

    void Start()
    {
        Health = InitialHealth;
    }

    void Update()
    {
        
    }
}
