using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAfterTime : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
  
    Vector2 Position;


  
    void Start()
    {
        Position = gameObject.transform.position;

        Invoke("Spawn", 2);


    }

    void Spawn()
    {
        Instantiate(prefab, Position, Quaternion.identity);
        Instantiate(prefab2, Position, Quaternion.identity);
        Destroy(this.gameObject);
    }
   
   
}
