using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private int hpMax, hp;
    [SerializeField]
    private int manaMax, mana;
    
    [SerializeField]
    private int strength, agility, intelligence;

    [SerializeField]
    private BarScript healthbar, manabar;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxValue(hpMax);
        manabar.SetMaxValue(manaMax);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Call it when modifying current health (eg: taking damage)
    private void SetHealth(int value)
    {
        hp = value;
        healthbar.SetValue(value);
    }

    // Call it when modifying max health (eg: Lvl up)
    private void SetMaxHealth(int value)
    {
        hpMax = value;
        hp = value;
        healthbar.SetMaxValue(value);
    }

    // Call it when modifying current mana (eg: casting a spell)
    private void SetMana(int value)
    {
        hp = value;
    }

    // Call it when modifying max mana (eg: Lvl up)
    private void SetMaxMana(int value)
    {
        hpMax = value;
        hp = value;
    }
}
