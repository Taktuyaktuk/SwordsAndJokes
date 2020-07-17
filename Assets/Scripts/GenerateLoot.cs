﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int min = 2;

    [SerializeField]
    int max = 15;

    [SerializeField]
    float probability = 0.25f;

    public void Generate()
    {
        if (Random.value > probability)
            return;

        //var loot = Instantiate(prefab);
        //loot.transform.position = transform.position;
        var player = FindObjectOfType<Player>();
        var ps = player.GetComponent<PlayerShooting>();
        ps.Bullets += Random.Range(min, max);
        //loot.GetComponent<Bullets>().Amount = Random.Range(min, max);
    }
}
