﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFrost : MonoBehaviour
{
    Mob TargetMob;
    [SerializeField]
    float AttackDemage = 2f;

    void Start()
    {

}

// Update is called once per frame
void Update()
{

}



private void OnCollisionEnter2D(Collision2D collision)
{
    var mob = collision.gameObject.GetComponent<Mob>();

    if (mob != null)
    {
        TargetMob = mob;

        TargetMob.GetComponent<Entity>().Health -= AttackDemage;
        

        Destroy(this.gameObject);
    }



    

}

}
