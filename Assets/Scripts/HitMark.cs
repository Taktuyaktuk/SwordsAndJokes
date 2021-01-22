using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class HitMark : MonoBehaviour
{

    public GameObject myprefab2;
    Vector3 Position1;
    float hp;
    float lasthp;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Awake()
    {
        //gameObject.GetComponent<Entity>().OnHealthChanged += health =>
        //{
        //    hp = health;

        // };
    }

    private void Update()
    {
        gameObject.GetComponent<Entity>().OnHealthChanged += health =>
        {
            hp = health;

        };

        if (lasthp != hp)
        {
            Position1 = transform.position;
            Instantiate(myprefab2, Position1, Quaternion.identity);
            // Destroy(prefabclone);



            lasthp = hp;
        }

    }
}
