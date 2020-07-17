using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPref;

    [SerializeField]
    float BulletSpeed = 2f;

    [SerializeField]
    Vector2 ShootPoint;

    Bow bow;

    private int bullets;
    public int Bullets
    {
        get { return bullets; }
        private set
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
        if (Input.GetMouseButtonDown(0))
            Shoot();
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

    public void CollectBullets(int amount)
    {
        if (amount < 0)
            amount = 0;

        Bullets += amount;
    }
}