using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]
[RequireComponent(typeof(LevelSystem))]
public class Player : MonoBehaviour
{
    [SerializeField]
    float WalkingSpeed = 2f;

    [SerializeField]
    Animator animator;

    Rigidbody2D Rigidbody;
    Collider2D Collider;

    List<GameObject> currentCollisions = new List<GameObject>();

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //GetComponent<Entity>().OnKilled += () => Application.Quit();
    }

    void Update()
    {
        this.UpdateMovement();
    }

    void UpdateMovement()
    {
        var WalkingDirection = Vector3.zero;

        WalkingDirection += Vector3.up * Input.GetAxis("Vertical");
        WalkingDirection += Vector3.right * Input.GetAxis("Horizontal");
       

        if (Input.GetKey("space"))
        {
            StartCoroutine(AttackCo());
        }
            //WalkingDirection = WalkingDirection.normalized;

            WalkingDirection *= WalkingSpeed;

        Rigidbody.velocity = WalkingDirection;

        this.Animator();
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("Atacking", true);
        yield return null;
        animator.SetBool("Atacking",false);
        
    }
    void Animator()
    {
        Vector2 move;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentCollisions.Add(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currentCollisions.Remove(collision.gameObject);
    }


    void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKey("space"))
        {
            bool find = false;
            int i = 0;
            while (!find || i >= currentCollisions.Count)
            {
                var col = currentCollisions[i];
                var entity = col.gameObject.GetComponent<Entity>();
                var player = col.gameObject.GetComponent<Player>();
                if (entity == null || player == null)
                    i++;
                else
                {
                    find = true;
                    entity.OnKilled += () =>
                    {
                        currentCollisions.Remove(col.gameObject);
                        var mob = col.gameObject.GetComponent<Mob>();
                        if(mob != null)
                        {
                            var exp = GetComponent<LevelSystem>();
                            exp.Experience += mob.Experience;
                        }
                    };
                    if (entity != null)
                        entity.Health -= 1f;
                }
            }
        }
    }
}
