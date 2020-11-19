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

    public InventoryObject inventory; // Jarek 17.11.20 do inventory

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    //do Dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    public GameObject dashEffect;
    //dotad
   // start jarek 29.10
    public float coolDownTime = 2;
    private float nextDashTime = 0;
    //end

    //start jarek 17.10.20
    public VectorValue startingPosition;
    //end
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //GetComponent<Entity>().OnKilled += () => Application.Quit();
        dashTime = startDashTime; //<-- do Dash
        //start jarek 17.10.20
        transform.position = startingPosition.initialValue;
        //end
        
    }

    public void OnTriggerEnter2D(Collider2D collision) //jarek do inveotry 17.11.20
    {
        var item = collision.GetComponent<Items>();
        if(item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }

    private void OnApplicationQuit()// jsrek do invetory 17.11
    {
        inventory.Container.Clear();
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
        
        this.Dash();

        

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

    void Dash()
    {
        if (direction == 0 && Time.time > nextDashTime)//29.10.20 jarek do dash cooldown
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Mouse1))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 1;
                nextDashTime = Time.time + coolDownTime;//29.10.20 jarek do dash cooldown, w kazdym input,dla kazdego kierunku

            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Mouse1))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 2;
                nextDashTime = Time.time + coolDownTime;
            }

            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse1))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 3;
                nextDashTime = Time.time + coolDownTime;
            }

            else if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse1)))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 4;
                nextDashTime = Time.time + coolDownTime;
            }

        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                Rigidbody.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    Rigidbody.velocity = Vector2.left * dashSpeed;
                }

                else if (direction == 2)
                {
                    Rigidbody.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 3)
                {
                    Rigidbody.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4)
                {
                    Rigidbody.velocity = Vector2.down * dashSpeed;
                }
            }
        }
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
