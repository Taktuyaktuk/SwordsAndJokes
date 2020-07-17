using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            if (health <= 0.75)
            {
                if (OnKilled != null)
                    OnKilled.Invoke();

                if(gameObject.tag == "Mob" || gameObject.tag == "Box")
                    Destroy(gameObject);
                else
                    SceneManager.LoadScene("Dead");
            }
               
        }
    }

    public Action<float> OnHealthChanged;
    public Action OnKilled;

    void Start()
    {
        //Health = InitialHealth;
    }

    void Update()
    {
        
    }
}
