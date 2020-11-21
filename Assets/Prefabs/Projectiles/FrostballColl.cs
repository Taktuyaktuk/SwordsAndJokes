using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostballColl : MonoBehaviour
{

    Mob TargetMob;
    
    
    

    public void OnTriggerEnter2D(Collider2D collision) //jarek do inveotry 17.11.20
    {

        var mob = collision.gameObject.GetComponent<Mob>();
       
        if (mob != null)
        {
            TargetMob = mob;

            TargetMob.Speed *= 0.1f;
            TargetMob.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            Destroy(this.gameObject);



        }
    }
}
