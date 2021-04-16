using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField]
    private BarScript healthbar, manabar;


    public float distanceBeforeRunning;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthbar.SetMaxValue(hpMax);
        healthbar.SetValue(hp);
        manabar.SetMaxValue(manaMax);
        manabar.SetValue(mana);
    }

    protected void FixedUpdate()
    {
        
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetMaxHealth(hpMax + 10);
            SetMaxMana(manaMax + 10);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetHealth(hp - 10);
            SetMana(mana - 10);
        }
    }

    public void MoveTo(Vector3 position)
    {
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, position) > distanceBeforeRunning)
        {
            step *= 2;
        }

        transform.LookAt(new Vector3(position.x, transform.position.y, position.z));
        transform.position = Vector3.MoveTowards(transform.position, position, step);
    }


    // Call it when modifying current health (eg: taking damage)
    protected override void SetHealth(int value)
    {
        hp = value;
        healthbar.SetValue(value);
    }

    // Call it when modifying max health (eg: Lvl up)
    protected override void SetMaxHealth(int value)
    {
        hpMax = value;
        hp = value;
        healthbar.SetMaxValue(value);
        healthbar.SetValue(value);
    }

    // Call it when modifying current mana (eg: casting a spell)
    protected override void SetMana(int value)
    {
        mana = value;
        manabar.SetValue(value);
    }

    // Call it when modifying max mana (eg: Lvl up)
    protected override void SetMaxMana(int value)
    {
        manaMax = value;
        mana = value;
        manabar.SetMaxValue(value);
        manabar.SetValue(value);
    }
}
