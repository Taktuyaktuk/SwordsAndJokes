using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallSpell : MonoBehaviour
{

    public GameObject PrefabWall;
    Vector3 position;


    private void Start()
    {
        Instantiate(PrefabWall, position, Quaternion.identity);
    }
}
