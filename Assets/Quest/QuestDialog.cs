using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDialog : MonoBehaviour
{
    [SerializeField]
    private GameObject questPref_;

    [SerializeField]
    private Transform questList_;

    private Quest selectedQuest_;

    private static QuestDialog instance_;
    public static QuestDialog Instance
    {
        get
        {
            if(instance_ == null)
            {
                instance_ = FindObjectOfType<QuestDialog>();
            }
            return instance_;
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        Debug.Log("OPEN");
    }

    public void RenderQuestList(Quest quest)
    {
        GameObject g = Instantiate(questPref_, questList_);
        g.GetComponent<Text>().text = quest.Title;

        QuestItem qi = g.GetComponent<QuestItem>();
        qi.quest_ = quest;
    }

    public void DisplayQuestDescription(Quest quest)
    {
        selectedQuest_ = quest;
        Debug.Log(quest);
    }
}
