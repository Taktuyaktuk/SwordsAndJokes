using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChanger : MonoBehaviour
{
    [SerializeField] private string newScene;
   
    //start zmiany jarek 17.10.20
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    //end

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //start
            playerStorage.initialValue = playerPosition;
            //end
            SceneManager.LoadScene(newScene);
        }
    }
}
