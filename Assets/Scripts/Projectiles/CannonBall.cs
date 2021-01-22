//using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{


    Player TargetPlayer;

    Rigidbody2D m_rigidbody2d;


    [SerializeField]
    float AttackDemage = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(14, 15);
        Physics2D.IgnoreLayerCollision(14, 14); 
        Physics2D.IgnoreLayerCollision(4, 4);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
  
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       

          var player = collision.gameObject.GetComponent<Player>();

          if (player != null)
         {
            TargetPlayer = player;

           TargetPlayer.GetComponent<Entity>().Health -= AttackDemage;
           Destroy(this.gameObject);

        }

    }
    
}

