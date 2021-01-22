﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entity : MonoBehaviour
{
    [SerializeField]
    public float InitialHealth = 10f;

    private bool flagA = false;
    private bool flagB = false;
    private float maxHealth = 10f;
    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }
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

            //if (gameObject.tag == "Player")
            //{
            //    if (health > maxHealth && Lvl > 0 && flagA && flagB)
            //        health = maxHealth;
            //    //Debug.Log(health);
            //}

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
    public Action<float> OnMaxHealthChanged;
    public Action OnKilled;

    void Awake()
    {
        if (gameObject.tag == "Mob" || gameObject.tag == "Box")
            Health = InitialHealth;
        if (gameObject.tag == "Player")
        {
            gameObject.GetComponent<LevelSystem>().OnLevelUp += Level => {
                CountMaxValue();
            };
            gameObject.GetComponent<PlayerStats>().OnVitalityChanged += Vit =>
            {
                CountMaxValue();
            };
        }
    }

    void CountMaxValue()
    {
        float Lvl = gameObject.GetComponent<LevelSystem>().Level;
        float Stats = gameObject.GetComponent<PlayerStats>().Vitality;
        maxHealth = 10f + (Lvl * 1f) + Stats;
        if (health > maxHealth)
            Health = maxHealth;
        OnMaxHealthChanged.Invoke(maxHealth);
    }

    public void setToMax()
    {
        Health = maxHealth;
    }
}
