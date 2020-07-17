using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SceneSave
{
    public string sceneName;
    public Vector3 position;
    public Quaternion rotation;
}

[Serializable]
public class SaveData
{
    public string name;
    public float hp;
    public int level;
    public int exp;
    public List<SceneSave> postions;
}