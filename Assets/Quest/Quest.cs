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
    private int _level;

    [SerializeField]
    private int _xp;

    [SerializeField]
    private int _gold;

    [SerializeField]
    private CollectObjective[] _collect;

    [SerializeField]
    private KillObjective[] _kill;

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

    public CollectObjective[] Collect
    {
        get
        {
            return _collect;
        }
    }
    public KillObjective[] Kill
    {
        get
        {
            return _kill;
        }
    }

    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }

    public int Xp
    {
        get
        {
            return _xp;
        }
        set
        {
            _xp = value;
        }
    }

    public int Gold
    {
        get
        {
            return _gold;
        }
        set
        {
            _gold = value;
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