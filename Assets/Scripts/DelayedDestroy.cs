using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    public float Time = 3f;

    void Update()
    {
        Destroy(gameObject, Time);
    }
}
