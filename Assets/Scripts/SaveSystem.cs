﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    static readonly string SAVE_FILE = "player.json";
    string fileName;
    SaveData saveData;

    float nextSave = 5;
    float countToSave = 0;

    private void Start()
    {
        fileName = Path.Combine(Application.persistentDataPath, SAVE_FILE);
        var player = FindObjectOfType<Player>();
        var entity = player.GetComponent<Entity>();
        var lvl = player.GetComponent<LevelSystem>();

        if (File.Exists(fileName))
        {
            string jsonFromFile = File.ReadAllText(fileName);
            saveData = JsonUtility.FromJson<SaveData>(jsonFromFile);
            float hp = saveData.hp;
            if ((Int32)saveData.hp == 0)
                hp = 10f;
            entity.Health = hp;
            lvl.Level = saveData.level;
            lvl.Experience = saveData.exp;
            //var m_Scene = SceneManager.GetActiveScene();
            //string sceneName = m_Scene.name;
            //var obj = saveData.postions.Find(x => x.sceneName == sceneName);
            //if (obj != null)
            //{
            //    player.transform.position = obj.position;
            //    player.transform.rotation = obj.rotation;
            //}
        }
        else
        {
            entity.Health = 5;
            lvl.Level = 1;
            lvl.Experience = 0;
            Save();
        }
    }

    public void Save()
    {
        countToSave = 0f;
        var player = FindObjectOfType<Player>();
        var entity = player.GetComponent<Entity>();
        var lvl = player.GetComponent<LevelSystem>();
        var m_Scene = SceneManager.GetActiveScene();
        string sceneName = m_Scene.name;

        if (saveData == null)
        {
            //List<SceneSave> items = new List<SceneSave>()
            //{
            //    new SceneSave{ sceneName = sceneName, position = player.transform.position, rotation = player.transform.rotation }
            //};
            saveData = new SaveData()
            {
                name = "player",
                hp = entity.Health,
                level = lvl.Level,
                exp = lvl.Experience
                //postions = items
            };
        }
        else
        {
            saveData.hp = entity.Health;
            saveData.level = lvl.Level;
            saveData.exp = lvl.Experience;
        }
        //var obj = saveData.postions.Find(x => x.sceneName == sceneName);
        //if (obj != null)
        //{
        //    obj.position = player.transform.position;
        //    obj.rotation = player.transform.rotation;
        //}
        //else
        //    saveData.postions.Add(new SceneSave { sceneName = sceneName, position = player.transform.position, rotation = player.transform.rotation });
        string JSON = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(fileName, JSON);
    }

    private void Update()
    {
        if (nextSave > countToSave)
            countToSave += 1f;
        else
            Save();
    }
}
