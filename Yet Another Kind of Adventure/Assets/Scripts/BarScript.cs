using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]
    public Slider slider;

    [SerializeField]
    public Text value;

    public void SetMaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        value.text = health + "/" + health;
    }
    public void SetValue(int health)
    {
        slider.value = health;
        value.text = health + "/" + slider.maxValue;
    }
}
