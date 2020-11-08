using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPref;

    [SerializeField]
    GameObject SpellPref;

    [SerializeField]
    Boolean NoLimitShots = false;

    [SerializeField]
    float BulletSpeed = 2f;

    [SerializeField]
    Vector2 ShootPoint;

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

    private void Awake()
    {
        bow = FindObjectOfType<Bow>();
    }

    void Start()
    {
        Bullets = 5;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(0) && Input.GetKey("space"))
            Shoot();
    }

    void Shoot()
    {
        if (Bullets < 1 && !NoLimitShots) return;
        else Bullets--;

        var pref = NoLimitShots ? SpellPref : BulletPref;
        var bullet = Instantiate(pref);
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