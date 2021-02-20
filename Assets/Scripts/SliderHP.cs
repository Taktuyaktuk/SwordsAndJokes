using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : MonoBehaviour
{
    [SerializeField]
    Slider mSlider;
    private float hp;
    private float maxHp;
    private void Start()
    {
        FindObjectOfType<Player>().GetComponent<Entity>().OnMaxHealthChanged += hp =>
        {
            maxHp = hp;
            setSliderValue();
        };
        FindObjectOfType<Player>().GetComponent<Entity>().OnHealthChanged += health =>
        {
            hp = health;
            setSliderValue();
        };
    }

    private void setSliderValue()
    {
        maxHp = FindObjectOfType<Player>().GetComponent<Entity>().MaxHealth;
        //Debug.Log("MAX HP" + maxHp);
        //Debug.Log("HP" + hp);
        mSlider.maxValue = 100;
        mSlider.value = ((hp * 1f) * 100) / maxHp;
    }
}