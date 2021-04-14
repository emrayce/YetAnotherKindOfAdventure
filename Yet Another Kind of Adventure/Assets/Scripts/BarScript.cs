using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]
    public Slider slider;

    private int value;

    public void SetMaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetValue(int health)
    {
        slider.value = health;
    }

    private void Start()
    {
        value = 100;
        SetMaxValue(100);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            value -= 10;
            SetValue(value);
        }
    }
}
