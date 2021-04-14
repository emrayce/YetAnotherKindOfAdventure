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

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = value;
        this.value.text = value + "/" + value;
    }
    public void SetValue(int value)
    {
        slider.value = value;
        this.value.text = value + "/" + slider.maxValue;
    }
}
