using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    static readonly string SAVE_FILE = "player.json";
    string fileName;

    private void Start()
    {
        fileName = Path.Combine(Application.persistentDataPath, SAVE_FILE);
	Debug.Log(fileName);
        var player = FindObjectOfType<Player>();
        var entity = player.GetComponent<Entity>();
        var lvl = player.GetComponent<LevelSystem>();

        if (File.Exists(fileName))
        {
            string jsonFromFile = File.ReadAllText(fileName);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonFromFile);
            entity.Health = saveData.hp;
            lvl.Level = saveData.level;
            lvl.Experience = saveData.exp;
            player.transform.position = saveData.position;
            player.transform.rotation = saveData.rotation;
        }
        else
        {
            entity.Health = 5;
            lvl.Level = 1;
            lvl.Experience = 0;
            Save();
        }
    }

    private void Save()
    {
        var player = FindObjectOfType<Player>();
        var entity = player.GetComponent<Entity>();
        var lvl = player.GetComponent<LevelSystem>();
        SaveData saveData = new SaveData()
        {
            name = "player",
            hp = entity.Health,
            level = lvl.Level,
            exp = lvl.Experience,
            position = player.transform.position,
            rotation = player.transform.rotation
        };
        string JSON = JsonUtility.ToJson(saveData);
        File.WriteAllText(fileName, JSON);
    }

    private void Update()
    {
        Save();
    }
}
