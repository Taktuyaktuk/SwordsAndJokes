using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : MonoBehaviour
{
    [SerializeField]
    Slider mSlider;
    private float hp;
    private float lvl;
    private void Awake()
    {
        FindObjectOfType<Player>().GetComponent<Entity>().OnHealthChanged += health =>
        {
            hp = health;
            setSliderValue();

        };
        FindObjectOfType<Player>().GetComponent<LevelSystem>().OnLevelUp += Level =>
        {
           
            lvl = Level;
            setSliderValue();
            
        };
    }

    private void setSliderValue()
    {
        float max = lvl * 5f;
        mSlider.maxValue = 100;
        mSlider.value = ((hp * 1f) * 100) / max;
    }
}