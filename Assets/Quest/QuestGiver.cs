using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField]
    private Quest[] quests;

    [SerializeField]
    private QuestDialog questDialog;

    private void Awake()
    {
        foreach(Quest quest in quests)
        {
            questDialog.RenderQuestList(quest);
        }
    }
}
