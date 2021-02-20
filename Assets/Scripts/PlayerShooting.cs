using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mana))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPref;

    [SerializeField]
    float BulletSpeed = 2f;

    [SerializeField]
    Vector2 ShootPoint;

    [SerializeField]
    Bow bow;

    private int bullets;
    public int Bullets
    {
        get { return bullets; }
        set
        {
            bullets = value;

            if (OnBulletsChanged != null)
                OnBulletsChanged.Invoke(bullets);
        }
    }
    public event Action<int> OnBulletsChanged;

    [SerializeField]
    GameObject[] SpellPref;
    List<float> spellConfig = new List<float> { 2, 4, 4, 5 };


    void Start()
    {
        bow = FindObjectOfType<Bow>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SpellPref.Length > 0)

            {
                Boolean isSpell = false;
                for (int i = 1; i < 10; i++)
                {
                    if (Input.GetKey(i.ToString()))
                    {
                        isSpell = true;
                        MagicShot(i);
                    }
                }
                if (!isSpell)
                    Shoot();
            } else
                Shoot();
        }
    }

    void Shoot()
    {
        if (Bullets < 1) return;
        Bullets--;

        var bullet = Instantiate(BulletPref);
        bullet.transform.position = transform.position + transform.rotation * (Vector3)ShootPoint;
        bullet.transform.rotation = bow.transform.rotation;

        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bow.transform.right * BulletSpeed;
    }

    void MagicShot(int index)
    {
        var mana = GetComponent<Mana>();
        float _valueMana = mana.ManaValue;
        float spellMana = spellConfig[index - 1];
        if (spellMana > _valueMana)
            return;

        mana.ManaValue -= spellMana;

        var bullet = Instantiate(SpellPref[index - 1]);
        bullet.transform.position = transform.position + transform.rotation * (Vector3)ShootPoint;
        bullet.transform.rotation = bow.transform.rotation;

        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bow.transform.right * BulletSpeed;
    }

    public void CollectBullets(int amount)
    {
        if (amount < 0)
            amount = 0;

        Bullets += amount;
    }
}