using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Interactable : MonoBehaviour
{

    [SerializeField] public bool playerInRange;
    [SerializeField] public string otherTag;
    [SerializeField] public Notification myNotification;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            //myNotification.Raise();
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = false;
           // myNotification.Raise();
        }
    }
}
