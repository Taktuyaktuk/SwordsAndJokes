using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Fireballspell : MonoBehaviour
{
    Mob TargetMob;
    [SerializeField]
    float AttackDemage = 2f;
    public GameObject myprefab;
    public GameObject myprefab2;
    Vector3  Position1;

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
            Position1 = mob.transform.position;

            Instantiate(myprefab,Position1, Quaternion.identity);
            Instantiate(myprefab2, Position1, Quaternion.identity);
            //mob = collision.gameObject.GetComponent<Mob>();
            //TargetMob.GetComponent<Entity>().Health -= AttackDemage;

            //TargetMob.Speed *= 0.3f;
            //TargetMob.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);

            //Destroy(this.myprefab);
            Destroy(this.gameObject);
            
        }





    }
    //public void OnTriggerEnter2D(Collider2D collision) //jarek do inveotry 17.11.20
    //{

    //    var mob = collision.gameObject.GetComponent<Mob>();
    //    Debug.Log(mob);
    //    Debug.Log(collision);
     //   if (mob != null)
     //       {
     //       TargetMob = mob;
      //      Debug.Log(TargetMob);
      //      TargetMob.GetComponent<Entity>().Health -= AttackDemage;
            


       // }
    }

    //public void OnTriggerExit2D()
   // {
  //      TargetMob = null;
   //     
   // }





