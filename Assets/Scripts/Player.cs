using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]
[RequireComponent(typeof(Mana))]
[RequireComponent(typeof(LevelSystem))]
public class Player : MonoBehaviour
{
    [SerializeField]
    float WalkingSpeed = 2f;

    [SerializeField]
    Animator animator;

    Rigidbody2D Rigidbody;
    Collider2D Collider;

    public InventoryObject inventory;
    public InventoryObject equipment;// Jarek 17.11.20 do inventory
    public Attribute[] attributes;
    
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
        
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }
    }

    public void OnBeforeSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
        {
            return;
        }
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Removed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(",", _slot.AllowedItems)));
                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }


                break;
            case InterfaceType.chest:
                break;
            default:
                break;

        }


    }
    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
        {
            return;
        }

        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Placed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(",", _slot.AllowedItems)));
                
                for(int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for(int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.AddModifier(_slot.item.buffs[i]);
                    }
                }

                break;
            case InterfaceType.chest:
                break;
            default:
                break;

        }
    }
    public void OnTriggerEnter2D(Collider2D collision) //jarek do inveotry 17.11.20
    {
        var item = collision.GetComponent<GroundItem>();
        if(item)
        {
            Item _item = new Item(item.item);
            if (inventory.AddItem(_item, 1))
            {
                Destroy(collision.gameObject);
            }
    
        }
    }

    public void AttributeModified(Attribute attribute) // Do inventory
    {
        Debug.Log(string.Concat(attribute.type, "was updated! Value is now ", attribute.value.ModifiedValue));
    }
    

    private void OnApplicationQuit()// jsrek do invetory 17.11
    {
        inventory.Container.Clear();
        equipment.Container.Clear();
    }

    void Update()
    {
        this.UpdateMovement();
        this.Attack();
        this.Save_Load();// Jarek do inventory 07.01.20201
    }

    private void Save_Load()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            inventory.Save();
            equipment.Save();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load();
            equipment.Load();
        }
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
        if (direction == 0 )//29.10.20 jarek do dash cooldown
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Mouse1) && Time.time > nextDashTime)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 1;
                nextDashTime = Time.time + coolDownTime;//29.10.20 jarek do dash cooldown, w kazdym input,dla kazdego kierunku
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Mouse1) && Time.time > nextDashTime)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 2;
                nextDashTime = Time.time + coolDownTime;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse1) && Time.time > nextDashTime)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 3;
                nextDashTime = Time.time + coolDownTime;
            }

            else if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse1)) && Time.time > nextDashTime)
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
                    Rigidbody.velocity = Vector2.left * dashSpeed;
                else if (direction == 2)
                    Rigidbody.velocity = Vector2.right * dashSpeed;
                else if (direction == 3)
                    Rigidbody.velocity = Vector2.up * dashSpeed;
                else if (direction == 4)
                    Rigidbody.velocity = Vector2.down * dashSpeed;
            }
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var player = gameObject;
            Collider2D[] damage = Physics2D.OverlapCircleAll(player.transform.position, 0);
            for (int i = 0; i < damage.Length; i++)
            {
                var entity = damage[i].GetComponent<Entity>();
                var mob = damage[i].GetComponent<Mob>();
                if (entity != null && mob != null)
                {
                    float level = gameObject.GetComponent<LevelSystem>().Level;
                    float str = gameObject.GetComponent<PlayerStats>().Strength;
                    entity.Health -= ((level * 0.5f) + (str * 0.5f));
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

[System.Serializable]
public class Attribute // 18.01.21 jarek do invetory
{
    [System.NonSerialized]
    public Player parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(Player _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}
