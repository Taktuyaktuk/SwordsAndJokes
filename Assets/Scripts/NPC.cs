using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    GameObject text;

    private void Awake()
    {
        text = GameObject.Find("TextPRESS");
        text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if (text != null)
                text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if(text != null)
                text.SetActive(false);
        }
    }
}
