using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Slider slider;

    public Text value;

    public void SetMaxValue(int maxValue)
    {
        slider.maxValue = maxValue;
        this.value.text = slider.value + "/" + maxValue;
    }
    public void SetValue(int value)
    {
        slider.value = value;
        this.value.text = value + "/" + slider.maxValue;
    }
}
