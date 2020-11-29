using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector2 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
   
}
