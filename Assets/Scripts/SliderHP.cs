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
    private void Start()
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
        //Debug.Log(mSlider);
        mSlider.maxValue = lvl*5f;
        mSlider.value = hp*1f;
    }
}