using Boo.Lang.Environments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public Sprite[] emotionSprites;
    SpriteRenderer spRend;
    public int ID;

    public enum CharacterEmotion
    {
        happy,sad,neutral,angry
    }

    [SerializeField]
    CharacterEmotion myState;
    void Awake()
    {
        myState = CharacterEmotion.neutral;
        spRend = GetComponent<SpriteRenderer>();
    }

    public void ChangeState(string emotionName)
    {
        StartCoroutine(emotionName + "State");
    }

    IEnumerator HappyState()
    {
        spRend.sprite = emotionSprites[0];
        myState = CharacterEmotion.happy;
        yield return null;

    }

    IEnumerator AngryState()
    {
        spRend.sprite = emotionSprites[1];
        myState = CharacterEmotion.angry;
        yield return null;

    }

    IEnumerator NeutralState()
    {
        spRend.sprite = emotionSprites[2];
        myState = CharacterEmotion.neutral;
        yield return null;

    }
    IEnumerator SadState()
    {
        spRend.sprite = emotionSprites[3];
        myState = CharacterEmotion.sad;
        yield return null;

    }

    void Update()
    {
        
    }
}
