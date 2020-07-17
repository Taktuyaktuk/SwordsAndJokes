using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI HealthCounter;
    [SerializeField]
    TextMeshProUGUI LevelShow;
    [SerializeField]
    TextMeshProUGUI Exp;
    [SerializeField]
    TextMeshProUGUI BulletsCounter;

    void Awake()
    {
        FindObjectOfType<Player>().GetComponent<Entity>().OnHealthChanged += health =>
        {
            HealthCounter.text = health.ToString("N0") + " hp";
        };
        FindObjectOfType<Player>().GetComponent<LevelSystem>().OnLevelUp += Level =>
        {
            LevelShow.text = Level.ToString("N0") + " lvl";
        };
        FindObjectOfType<Player>().GetComponent<LevelSystem>().OnExpRange += (CurrentExp, NextLevel) =>
        {
            Exp.text = CurrentExp.ToString("N0") + "/";
            Exp.text += NextLevel.ToString("N0");
        };
        FindObjectOfType<PlayerShooting>().OnBulletsChanged += bullets =>
        {
            BulletsCounter.text = bullets.ToString() + " x arrows";
        };
    }
}
