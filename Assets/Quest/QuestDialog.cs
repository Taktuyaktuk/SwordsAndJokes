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

    //private Quest selectedQuest_;
    [SerializeField]
    private Text questDescription;

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
        gameObject.SetActive(true);
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
        string description = quest.Description;
        string questGoal = "";
        foreach(Objective obj in quest.Collect)
        {
            questGoal += "Zbierz:\n" + obj.Type + ": " + obj.CurrentAmout + "/" + obj.Amount; 
        }
        foreach (Objective obj in quest.Kill)
        {
            questGoal += "Zabij:\n" + obj.Type + ": " + obj.CurrentAmout + "/" + obj.Amount;
        }
        questDescription.text = string.Format("{0}\n\n{1}", description, questGoal);
    }
}
