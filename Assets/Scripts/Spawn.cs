﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y - 2.1F);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
