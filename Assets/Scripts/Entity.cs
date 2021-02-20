using System;
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
    Vector2 position;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    GameObject prefab2;
    [SerializeField]
    GameObject prefab3;
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

                if (gameObject.tag == "Mob" || gameObject.tag == "Box")
                {
                    if(gameObject.tag == "Mob")
                    {
                        var player = FindObjectOfType<Player>();
                        var exp = player.GetComponent<LevelSystem>();
                        exp.Experience += gameObject.GetComponent<Mob>().Experience;
                    }
                    var randomInt = UnityEngine.Random.Range(0, 2);
                    if (randomInt == 0)
                    {
                        position = gameObject.transform.position;
                        Instantiate(prefab, position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else if(randomInt == 1)
                    {
                        position = gameObject.transform.position;
                        Instantiate(prefab2, position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else if(randomInt ==2)
                    {
                        position = gameObject.transform.position;
                        Instantiate(prefab3, position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
                else
                {
                    setToMax();
                    gameObject.GetComponent<SaveSystem>().Save();
                    SceneManager.LoadScene("Dead");
                }  
            }
               
        }
    }

    public Action<float> OnHealthChanged;
    public Action<float> OnMaxHealthChanged;
    public Action OnKilled;

    void Start()
    {
        if (gameObject.tag == "Mob" || gameObject.tag == "Box")
        {
            maxHealth = InitialHealth;
            Health = InitialHealth;
        }
        if (gameObject.tag == "Player")
        {
            CountMaxValue();
            gameObject.GetComponent<LevelSystem>().OnLevelUp += Level =>
            {
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
        Debug.Log("COUNT " + maxHealth);
        OnMaxHealthChanged.Invoke(maxHealth);
    }

    public void setToMax()
    {
        CountMaxValue();
        Health = maxHealth;
    }
}
