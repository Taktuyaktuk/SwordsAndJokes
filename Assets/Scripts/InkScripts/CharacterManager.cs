using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public GameObject[] characters;
    public List<GameObject> actorsList = new List<GameObject>();
    [SerializeField]
    Vector3 leftActorPosition, rightActorPosition;

    List<Actor> activeActors = new List<Actor>();
    
    void Start()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            GameObject newActor = Instantiate(characters[i]);
            newActor.SetActive(false);
            newActor.name = characters[i].name;
            actorsList.Add(newActor);
        }
    }


    public void PlaceActors(string leftActorName,string rightActorName)
    {
        foreach (GameObject gO in actorsList)
        {
            if (gO.name == leftActorName)
            {
                
                gO.SetActive(true);
                gO.GetComponent<Actor>().ID = 0;
                activeActors.Add(gO.GetComponent<Actor>());
                gO.transform.position = leftActorPosition;
            }
            else if (gO.name == rightActorName)
            {
                gO.SetActive(true);
                gO.GetComponent<Actor>().ID = 0;
                activeActors.Add(gO.GetComponent<Actor>());
                gO.transform.position = rightActorPosition;
            }
        }
    }

    public void ChangeActorEmotion(string emotion,int ID)
    {
        foreach ( Actor actor in activeActors)
        {
            if(actor.gameObject.activeInHierarchy)
            {
                if(actor.ID == ID)
                {
                    actor.ChangeState(emotion);
                }
            }
        }
    }
}
