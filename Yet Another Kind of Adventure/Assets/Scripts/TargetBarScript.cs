using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBarScript : BarScript
{
    // The target unit that we display
    private Unit target;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            slider.value = target.GetHp();
            Debug.Log(slider.value);
        }
    }

    public void SetUnit(Unit unit)
    {
        target = unit;
        Debug.Log(unit.GetHp());
        SetMaxValue(target.GetHpMax());
        SetValue(target.GetHp());
    }
}
