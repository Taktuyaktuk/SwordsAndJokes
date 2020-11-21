using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballColldmg : MonoBehaviour
{

    Mob TargetMob;
    [SerializeField]
    float AttackDemage = 2f;
    
    

    public void OnTriggerEnter2D(Collider2D collision) //jarek do inveotry 17.11.20
    {

        var mob = collision.gameObject.GetComponent<Mob>();
       
        if (mob != null)
        {
            TargetMob = mob;
            Debug.Log(TargetMob);
            TargetMob.GetComponent<Entity>().Health -= AttackDemage;
            
            Destroy(this.gameObject);



        }
    }
}
