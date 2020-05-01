using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Activator : MonoBehaviour
{
    [SerializeField]
    bool AutoInteract = false;

    public bool Active { get; private set; }

    public event Action OnActivated;

    void Start()
    {
        
    }

    void Update()
    {

        UpdateColor();
        UpdateInteraction();
    }

   void UpdateColor()
   {
        Color targetColor = Color.white;

        if (Active)
            targetColor *= (Mathf.Sin(Time.timeSinceLevelLoad * 5f) + 9f) / 10f;

        GetComponent<Renderer>().material.color = targetColor;
   }

    void UpdateInteraction()
    {
        if (!Active)
            return;

        if (AutoInteract || Input.GetKeyDown(KeyCode.Space))
            if (OnActivated != null)
                OnActivated.Invoke();
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CheckIsPlayer(collision))
            return;
        Active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!CheckIsPlayer(collision))
            return;
        Active = false;
    }

    bool CheckIsPlayer(Collider2D collision)
    {
        return (collision.GetComponent<Player>() != null);
    }
}
