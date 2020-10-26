using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1 : MonoBehaviour
{

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
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
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
}