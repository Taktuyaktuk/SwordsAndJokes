using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBall1Spell : MonoBehaviour
{
    Mob TargetMob;
    public GameObject myprefab;
    public GameObject myprefab2;


    Vector3 Position2;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        var mob = collision.gameObject.GetComponent<Mob>();

        if (mob != null)
        {
            TargetMob = mob;


            Position2 = mob.transform.position;
            Instantiate(myprefab, Position2, Quaternion.identity);
            Instantiate(myprefab2, Position2, Quaternion.identity);

            Destroy(this.gameObject);
        }





    }

}
