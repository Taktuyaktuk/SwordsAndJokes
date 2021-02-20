using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Mob : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    Vector2 TargetPosition;
    Player TargetPlayer;

    Animator animator;

    public float Speed = 1f;

    //[SerializeField]
    //float AttackDistance = 1f;


    protected bool isAttacking = false;

    [SerializeField]
    float AttackCooldown = 1f;
    [SerializeField]
    float AttackRange = 1f;
    [SerializeField]
    float AttackDamage = 1f;
    [SerializeField]
    int Experience = 1;

    float AttackTime;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeTargetPositionCoroutine());
        animator = GetComponent<Animator>();
    }

    IEnumerator ChangeTargetPositionCoroutine()
    {
        while (true)
        {
            TargetPosition = (Vector2)transform.position + Random.insideUnitCircle * 10f;
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }

    void Update()
    {
        UpdateMovement();
        UpdateAttack();        
    }

    void UpdateMovement()
    {
        var targetSpeed = Speed;
        if (TargetPlayer != null)
        {
            TargetPosition = TargetPlayer.transform.position;
            targetSpeed *= 2f;
        }
        var direction = (Vector3)TargetPosition - transform.position;
        var targetVelocity = direction.normalized * targetSpeed / 2f;
        Rigidbody.velocity = Vector3.Lerp(
            Rigidbody.velocity,
            targetVelocity,
            Time.deltaTime / 2f);
        //transform.right = (Vector2)direction;
    }

    void UpdateAttack()
    {
        if(TargetPlayer != null)
        {
            if (!isAttacking)
            {
                AttackTime += Time.deltaTime;
            }
            else
            {
                TargetPlayer.GetComponent<Entity>().Health -= AttackDamage * Time.deltaTime;
            }

            float distance = Vector2.Distance(TargetPlayer.transform.position, gameObject.transform.position);
            if (AttackRange >= distance)
            {
                if (AttackTime >= AttackCooldown && !isAttacking)
                {
                    AttackTime = 0;
                    StartCoroutine(Attack());
                }     
            }
        }
        else
        {
            AttackTime = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
            TargetPlayer = player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
            TargetPlayer = null;
    }

    public IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
