using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleAtack : MonoBehaviour
{

    Mob TargetMob;
    [SerializeField]
    float AttackDemage = 2f;
    Rigidbody2D m_rigidbody2d;
    public float time = 0.25f;


    void Start()
    {
        m_rigidbody2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(0, 8);

    }

    public void OnTriggerEnter2D(Collider2D collision) //jarek do inveotry 17.11.20
    {

        var mob = collision.gameObject.GetComponent<Mob>();

        


        if (mob != null)
        {


            TargetMob = mob;
            Debug.Log(TargetMob);
            TargetMob.GetComponent<Entity>().Health -= AttackDemage;

            Destroy(this.gameObject,time);



        }
        
    }
}
