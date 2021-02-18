using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bow : MonoBehaviour
{
    Crosshair crosshair;
    public GameObject prefabPunch;
    public Vector2 punchPosition;
    public Vector3 playerPosition;

    private void Awake()
    {
        crosshair = FindObjectOfType<Crosshair>();
    }

    void Update()
    {
        UpdateRotation();
        SpawPunch();
        playerPosition = gameObject.transform.position;
    }

    public void UpdateRotation()
    {
        var delta = crosshair.transform.position - transform.position;
        var targetRotation = (Vector2)delta;
        transform.right = Vector3.Lerp(transform.right, targetRotation, Time.deltaTime * 10f);
        punchPosition = transform.right + playerPosition;
    }
    void SpawPunch()
    {
        //var delta = crosshair.transform.position - transform.position;
        //var targetRotation = (Vector2)delta;
        //punchPosition = transform.right = Vector3.Lerp(transform.right, targetRotation, Time.deltaTime * 10f);
        if (Input.GetKeyDown(KeyCode.V))
            Instantiate(prefabPunch, punchPosition, Quaternion.identity);

    }
}