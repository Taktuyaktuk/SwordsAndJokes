using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    //Rigidbody2D rigidbody;
   // public float Range1;
    //Player TargetPlayer;
    Mob TargetMob;
    [SerializeField]
    float AttackDemage = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   // private void OnDrawGizmosSelected()
    //{
       // Gizmos.DrawWireSphere(transform.position, Range1);
        
   // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var mob = collision.gameObject.GetComponent<Mob>();

        if (mob != null)
        {
            TargetMob = mob;

            TargetMob.GetComponent<Entity>().Health -= AttackDemage;
            //OnDrawGizmosSelected();
           // rigidbody = GetComponent<Rigidbody2D>();
            //rigidbody.GetComponent<Entity>()Health -= AttackDemage;

            Destroy(this.gameObject);
        }



        //  var player = collision.gameObject.GetComponent<Player>();

        //  if (player != null)
        // {
        //    TargetPlayer = player;

        //    TargetPlayer.GetComponent<Entity>().Health -= AttackDemage;
        //    Destroy(this.gameObject);

        //}

    }

}
