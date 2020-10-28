using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    Player TargetPlayer;
    [SerializeField]
    float AttackDemage = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            TargetPlayer = player;
            
            TargetPlayer.GetComponent<Entity>().Health -= AttackDemage;
            Destroy(this.gameObject);
        }
    }
}
