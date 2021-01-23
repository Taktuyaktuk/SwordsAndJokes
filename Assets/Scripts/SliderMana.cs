using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderMana : MonoBehaviour
{
    [SerializeField]
    Slider mSlider;
    private float mp;
    private float maxMp;
    private void Awake()
    {
        FindObjectOfType<Player>().GetComponent<Mana>().OnMaxManaChanged += mp =>
        {
            maxMp = mp;
            setSliderValue();
        };
        FindObjectOfType<Player>().GetComponent<Mana>().OnManaChanged += mana =>
        {
            mp = mana;
            setSliderValue();
        };
    }

    private void setSliderValue()
    {
        mSlider.maxValue = 100;
        mSlider.value = ((mp * 1f) * 100) / maxMp;
    }
}
