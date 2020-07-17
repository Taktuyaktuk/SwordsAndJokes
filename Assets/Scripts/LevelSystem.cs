using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    int InitLevel = 1;

    private int experience = 0;
    public int Experience
    {
        get
        {
            return experience;
        }
        set
        {
            experience = value;

            if (experience >= GetExperienceToNextLevel())
            {
                Level += 1;
                experience = 0;
            }

            if (OnExpRange != null)
                OnExpRange.Invoke(experience, GetExperienceToNextLevel());
        }
    }

    private int level = 0;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
            if (OnLevelUp != null)
                OnLevelUp.Invoke(Level);
        }
    }

    public Action<int> OnLevelUp;
    public Action<int, int> OnExpRange;

    void Start()
    {
        Experience = 0;
        //Level = InitLevel;
    }


    public int GetExperienceToNextLevel()
    {
        return Level * 2;
    }
}