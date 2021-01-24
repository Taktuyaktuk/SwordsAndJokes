using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderHPMob : MonoBehaviour
{
    [SerializeField]
    Slider mSlider;
    //[SerializeField]
    private GameObject _character;
    private float hp;
    private float max;
    private Entity entity;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _character = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        entity = _character.GetComponent<Entity>();
        hp = entity.Health;
        max = entity.MaxHealth;
        entity.OnMaxHealthChanged += health =>
        {
            setSliderValue();
        };
        entity.OnHealthChanged += health =>
        {
            setSliderValue();
        };
        setSliderValue();
    }
    private void setSliderValue()
    {
        mSlider.maxValue = 100;
        mSlider.value = ((entity.Health * 1f) * 100) / entity.MaxHealth;
    }
}
