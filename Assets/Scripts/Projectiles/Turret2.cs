using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    //private float timeBtwShots;
    //public float startTimeBtwShots;

   // public GameObject projectile1;
    //private Transform player1;

    public float Range;
    public Transform Target;
    bool Detected = false;

    Vector2 Direction;

    public GameObject AlarmLight;

    public GameObject Arrow;

    public GameObject CannonBall;

    public float FireRate;

    private float nextTimeToFire = 0;

    public Transform ShootPoint;

    public float Force;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targeting();
        Move();
    }

    void shoot()
    {
        GameObject CannonBallIns = Instantiate(CannonBall, ShootPoint.position, Quaternion.identity);
        CannonBallIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void targeting()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
        if (Detected)
        {
            Arrow.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    private void Move()
    {
       
        if (Vector2.Distance(transform.position, Target.position) > stoppingDistance && (Vector2.Distance(transform.position, Target.position) <Range))
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Target.position) < stoppingDistance && Vector2.Distance(transform.position, Target.position) > retreatDistance && (Vector2.Distance(transform.position, Target.position) < Range))
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, Target.position) < retreatDistance && (Vector2.Distance(transform.position, Target.position) < Range))
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, -speed * Time.deltaTime);
        }
    }
    
        
    
}