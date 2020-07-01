using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public KeyCode attack;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(attack))

            anim.SetTrigger("PlayerAttack");
    }
}
