using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Crosshair crosshair;

    private void Awake()
    {
        crosshair = FindObjectOfType<Crosshair>();
    }

    void Update()
    {
        UpdateRotation();
    }

    void UpdateRotation()
    {
        var delta = crosshair.transform.position - transform.position;
        var targetRotation = (Vector2)delta;
        transform.right = Vector3.Lerp(transform.right, targetRotation, Time.deltaTime * 10f);
    }
}
