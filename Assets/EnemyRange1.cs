using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyRange1 : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform player1;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player1.position) >stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player1.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player1.position) < stoppingDistance && Vector2.Distance(transform.position, player1.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player1.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player1.position, -speed * Time.deltaTime);
        }
    }
}
