using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestItem : MonoBehaviour
{
    public Quest quest_ { get; set; }

    public void SelectQuest()
    {
        QuestDialog.Instance.DisplayQuestDescription(quest_);
    }
}
