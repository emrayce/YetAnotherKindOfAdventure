﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBarScript : BarScript
{
    // The target unit that we display
    private Unit target;

    [SerializeField]
    private Text targetName;

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
            SetValue(target.GetHp());
        }
    }

    public void SetUnit(Unit unit)
    {
        target = unit;
        targetName.text = unit.name;
        SetMaxValue(target.GetHpMax());
        SetValue(target.GetHp());
    }
}
