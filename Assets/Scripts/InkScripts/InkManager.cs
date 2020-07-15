using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;


public class InkManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkJSONAsset;
    private Story story;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Text textPrefab;
    [SerializeField]
    private Button buttonPrefab;
    CharacterManager cm;
    InkGameManager gm;


   void Start()
    {
        cm = GetComponent<CharacterManager>();
        gm = GetComponent<InkGameManager>();
        StartStory();
    }

    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        story.BindExternalFunction("place_actors", (string leftName, string rightName) =>
        {
            cm.PlaceActors(leftName, rightName);
        });
        story.BindExternalFunction("change_emotion", (string emotion, int ID) =>
        {
            cm.ChangeActorEmotion(emotion, ID);
        });
        RefreshView();
    }

    void RefreshView()
    {
        RemoveChildren();

        while(story.canContinue)
        {
            string text = story.Continue().Trim();
            CreateContentView(text);
        }

        if(story.currentChoices.Count > 0)
        {
            for(int i =0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });
            }
        }
        else
        {
            Button choice = CreateChoiceView("End of Story. \nRestart?");
            choice.onClick.AddListener(delegate
            {
                StartStory();
            });
        }

        
    }

    void OnClickChoiceButton (Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void CreateContentView (string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
    }

    Button CreateChoiceView (string text)
    {
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(canvas.transform, false);

        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    void RemoveChildren ()
    {
        int childCount = canvas.transform.childCount;
        for(int i = childCount -1; i >=0; --i)
        {
            GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }
}
