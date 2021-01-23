using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialog : MonoBehaviour
{
    public void Close()
    {
        gameObject.active = false;
    }

    public void Open()
    {
        Debug.Log("OPEN");
    }
}
