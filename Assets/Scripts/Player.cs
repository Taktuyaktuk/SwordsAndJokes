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

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

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
        this.Attack();
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
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int abc = 0;
            var player = gameObject;
            Collider2D[] damage = Physics2D.OverlapCircleAll(player.transform.position, 0);
            for (int i = 0; i < damage.Length; i++)
            {
                var entity = damage[i].GetComponent<Entity>();
                var mob = damage[i].GetComponent<Mob>();
                if (entity != null && mob != null)
                {
                    abc += 1;
                    entity.Health -= 1f;
                    entity.OnKilled = () =>
                    {
                        if (mob != null)
                        {
                            var exp = GetComponent<LevelSystem>();
                            exp.Experience += mob.Experience;
                        }
                    };
                    return;
                }
            }
        }
    }
}
