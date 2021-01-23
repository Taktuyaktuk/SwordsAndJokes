using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    //public bool isActive;
    //public bool isComplete
    //public string goldReward;

    [SerializeField]
    private string _title;

    [SerializeField]
    private string _description;

    [SerializeField]
    private CollectObjective[] _collectObjectives;

    [SerializeField]
    private KillObjective[] _killObjectives;

    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }
    
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }

    public CollectObjective[] CollectObjectives
    {
        get
        {
            return _collectObjectives;
        }
    }
    public KillObjective[] KillObjectives
    {
        get
        {
            return _killObjectives;
        }
    }
}

[System.Serializable]
public abstract class Objective
{
    [SerializeField]
    private int _amout;

    private int _currentAmout;

    [SerializeField]
    private string _type;

    public int Amount
    {
        get
        {
            return _amout;
        }
        set
        {
            _amout = value;
        }
    }

    public int CurrentAmout
    {
        get
        {
            return _currentAmout;
        }
        set
        {
            _currentAmout = value;
        }
    }

    public string Type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }
}

[System.Serializable]
public class CollectObjective : Objective
{
    public void UpdateItemCount(Item item)
    {
        if(Type.ToLower() == item.Name.ToLower())
        {

        }
    }
}

[System.Serializable]
public class KillObjective : Objective
{
    public void UpdateKillCount()
    {
    }
}