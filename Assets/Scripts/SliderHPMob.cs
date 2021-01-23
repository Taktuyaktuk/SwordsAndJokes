using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderHPMob : MonoBehaviour
{
    [SerializeField]
    Slider mSlider;
    private float hp;
    private float max;
    [SerializeField]
    private GameObject _character;
    private void Awake()
    {
        Init();
        _character.GetComponent<Entity>().OnHealthChanged += health =>
        {
            hp = health;
            setSliderValue();
        };
    }
    private void Init()
    {
        _character = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        max = _character.GetComponent<Entity>().Health;
        hp = _character.GetComponent<Entity>().Health;
        setSliderValue();
    }
    private void setSliderValue()
    {
        mSlider.maxValue = 100;
        mSlider.value = ((hp * 1f) * 100) / max;
    }
}
