using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activator))]
[RequireComponent(typeof(GenerateLoot))]
public class Box : MonoBehaviour
{
    void Start()
    {
        GetComponent<Activator>().OnActivated += () =>
        {
            GetComponent<GenerateLoot>().Generate();
            Debug.Log(gameObject);
            Destroy(gameObject);
        };
    }
}
